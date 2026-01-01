using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using AllScreenshots.Sdk.Exceptions;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Base client with common HTTP functionality.
/// </summary>
internal abstract class BaseClient
{
    /// <summary>
    /// HTTP client for making requests.
    /// </summary>
    protected readonly HttpClient HttpClient;

    /// <summary>
    /// JSON serializer options.
    /// </summary>
    protected static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    /// <summary>
    /// Creates a new BaseClient.
    /// </summary>
    /// <param name="httpClient">HTTP client.</param>
    protected BaseClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    /// <summary>
    /// Sends a GET request and deserializes the response.
    /// </summary>
    /// <typeparam name="T">Response type.</typeparam>
    /// <param name="path">Request path.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deserialized response.</returns>
    protected async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(path, cancellationToken);
        return await HandleResponseAsync<T>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request and returns raw bytes.
    /// </summary>
    /// <param name="path">Request path.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Response bytes.</returns>
    protected async Task<byte[]> GetBytesAsync(string path, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(path, cancellationToken);
        await EnsureSuccessAsync(response, cancellationToken);
        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Sends a POST request with JSON body and deserializes the response.
    /// </summary>
    /// <typeparam name="TRequest">Request type.</typeparam>
    /// <typeparam name="TResponse">Response type.</typeparam>
    /// <param name="path">Request path.</param>
    /// <param name="request">Request body.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deserialized response.</returns>
    protected async Task<TResponse> PostAsync<TRequest, TResponse>(
        string path,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsJsonAsync(path, request, JsonOptions, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a POST request with JSON body and returns raw bytes.
    /// </summary>
    /// <typeparam name="TRequest">Request type.</typeparam>
    /// <param name="path">Request path.</param>
    /// <param name="request">Request body.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Response bytes.</returns>
    protected async Task<byte[]> PostBytesAsync<TRequest>(
        string path,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsJsonAsync(path, request, JsonOptions, cancellationToken);
        await EnsureSuccessAsync(response, cancellationToken);
        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Sends a POST request without a body and deserializes the response.
    /// </summary>
    /// <typeparam name="TResponse">Response type.</typeparam>
    /// <param name="path">Request path.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deserialized response.</returns>
    protected async Task<TResponse> PostAsync<TResponse>(
        string path,
        CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(path, null, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a PUT request with JSON body and deserializes the response.
    /// </summary>
    /// <typeparam name="TRequest">Request type.</typeparam>
    /// <typeparam name="TResponse">Response type.</typeparam>
    /// <param name="path">Request path.</param>
    /// <param name="request">Request body.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deserialized response.</returns>
    protected async Task<TResponse> PutAsync<TRequest, TResponse>(
        string path,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PutAsJsonAsync(path, request, JsonOptions, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a DELETE request.
    /// </summary>
    /// <param name="path">Request path.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected async Task DeleteAsync(string path, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.DeleteAsync(path, cancellationToken);
        await EnsureSuccessAsync(response, cancellationToken);
    }

    /// <summary>
    /// Handles the HTTP response and deserializes it.
    /// </summary>
    /// <typeparam name="T">Response type.</typeparam>
    /// <param name="response">HTTP response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deserialized response.</returns>
    private async Task<T> HandleResponseAsync<T>(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        await EnsureSuccessAsync(response, cancellationToken);

        var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions, cancellationToken);
        return result ?? throw new AllScreenshotsException("Empty response from server");
    }

    /// <summary>
    /// Ensures the response is successful, throwing appropriate exceptions if not.
    /// </summary>
    /// <param name="response">HTTP response.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    private async Task EnsureSuccessAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        var statusCode = (int)response.StatusCode;
        ApiErrorResponse? error = null;

        try
        {
            error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(JsonOptions, cancellationToken);
        }
        catch
        {
            // Ignore deserialization errors
        }

        var message = error?.ErrorMessage ?? error?.Message ?? response.ReasonPhrase ?? "Unknown error";

        throw response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => new AuthenticationException(message),
            HttpStatusCode.BadRequest => CreateValidationException(message, error),
            HttpStatusCode.NotFound => new NotFoundException(message),
            HttpStatusCode.TooManyRequests => CreateRateLimitException(message, response),
            HttpStatusCode.PaymentRequired => new QuotaExceededException(message),
            >= HttpStatusCode.InternalServerError => new ServerException(message, statusCode),
            _ => new AllScreenshotsException(message, statusCode, error?.ErrorCode)
        };
    }

    private static ValidationException CreateValidationException(string message, ApiErrorResponse? error)
    {
        var errors = error?.Errors?
            .Where(e => e.Field != null && e.Message != null)
            .Select(e => new ValidationError(e.Field!, e.Message!))
            .ToList();

        return new ValidationException(message, errors);
    }

    private static RateLimitException CreateRateLimitException(string message, HttpResponseMessage response)
    {
        DateTimeOffset? retryAfter = null;

        if (response.Headers.RetryAfter?.Delta != null)
        {
            retryAfter = DateTimeOffset.UtcNow + response.Headers.RetryAfter.Delta.Value;
        }
        else if (response.Headers.RetryAfter?.Date != null)
        {
            retryAfter = response.Headers.RetryAfter.Date.Value;
        }

        return new RateLimitException(message, retryAfter);
    }
}
