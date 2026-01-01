using System.Net;
using AllScreenshots.Sdk.Configuration;

namespace AllScreenshots.Sdk.Http;

/// <summary>
/// HTTP handler that implements retry logic with exponential backoff.
/// </summary>
internal class RetryHandler : DelegatingHandler
{
    private readonly AllScreenshotsClientOptions _options;
    private readonly Random _jitter = new();

    /// <summary>
    /// HTTP status codes that should trigger a retry.
    /// </summary>
    private static readonly HashSet<HttpStatusCode> RetryableStatusCodes = new()
    {
        HttpStatusCode.RequestTimeout,
        HttpStatusCode.TooManyRequests,
        HttpStatusCode.InternalServerError,
        HttpStatusCode.BadGateway,
        HttpStatusCode.ServiceUnavailable,
        HttpStatusCode.GatewayTimeout
    };

    public RetryHandler(AllScreenshotsClientOptions options)
    {
        _options = options;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var attempt = 0;
        Exception? lastException = null;

        while (true)
        {
            attempt++;

            try
            {
                var response = await base.SendAsync(CloneRequest(request), cancellationToken);

                if (response.IsSuccessStatusCode || !ShouldRetry(response, attempt))
                {
                    return response;
                }

                // Get retry delay from Retry-After header or calculate exponential backoff
                var delay = GetRetryDelay(response, attempt);

                await Task.Delay(delay, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                lastException = ex;

                if (attempt > _options.MaxRetries)
                {
                    throw;
                }

                var delay = CalculateBackoffDelay(attempt);
                await Task.Delay(delay, cancellationToken);
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                // This is a timeout, not a cancellation
                lastException = ex;

                if (attempt > _options.MaxRetries)
                {
                    throw;
                }

                var delay = CalculateBackoffDelay(attempt);
                await Task.Delay(delay, cancellationToken);
            }
        }
    }

    private bool ShouldRetry(HttpResponseMessage response, int attempt)
    {
        if (attempt > _options.MaxRetries)
        {
            return false;
        }

        return RetryableStatusCodes.Contains(response.StatusCode);
    }

    private TimeSpan GetRetryDelay(HttpResponseMessage response, int attempt)
    {
        // Check for Retry-After header
        if (response.Headers.RetryAfter != null)
        {
            if (response.Headers.RetryAfter.Delta.HasValue)
            {
                return response.Headers.RetryAfter.Delta.Value;
            }

            if (response.Headers.RetryAfter.Date.HasValue)
            {
                var delay = response.Headers.RetryAfter.Date.Value - DateTimeOffset.UtcNow;
                if (delay > TimeSpan.Zero)
                {
                    return delay;
                }
            }
        }

        return CalculateBackoffDelay(attempt);
    }

    private TimeSpan CalculateBackoffDelay(int attempt)
    {
        // Exponential backoff with jitter
        var exponentialDelay = TimeSpan.FromTicks(
            _options.RetryDelay.Ticks * (long)Math.Pow(2, attempt - 1));

        if (exponentialDelay > _options.MaxRetryDelay)
        {
            exponentialDelay = _options.MaxRetryDelay;
        }

        // Add jitter (0-25% of the delay)
        var jitterMs = _jitter.Next(0, (int)(exponentialDelay.TotalMilliseconds * 0.25));
        return exponentialDelay + TimeSpan.FromMilliseconds(jitterMs);
    }

    private static HttpRequestMessage CloneRequest(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri)
        {
            Version = request.Version
        };

        // Clone headers
        foreach (var header in request.Headers)
        {
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        // Clone content
        if (request.Content != null)
        {
            var contentBytes = request.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            clone.Content = new ByteArrayContent(contentBytes);

            foreach (var header in request.Content.Headers)
            {
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        return clone;
    }
}
