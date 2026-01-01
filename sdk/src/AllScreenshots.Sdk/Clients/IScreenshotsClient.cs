using AllScreenshots.Sdk.Models;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Client for screenshot operations.
/// </summary>
public interface IScreenshotsClient
{
    /// <summary>
    /// Takes a screenshot synchronously and returns the image bytes.
    /// </summary>
    /// <param name="request">Screenshot request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Image bytes.</returns>
    /// <example>
    /// <code>
    /// var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
    /// {
    ///     Url = "https://github.com",
    ///     Device = "Desktop HD"
    /// });
    /// File.WriteAllBytes("screenshot.png", imageBytes);
    /// </code>
    /// </example>
    Task<byte[]> CaptureAsync(ScreenshotRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Takes a screenshot asynchronously and returns a job ID.
    /// </summary>
    /// <param name="request">Screenshot request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Async job response with job ID.</returns>
    /// <example>
    /// <code>
    /// var job = await client.Screenshots.CaptureAsyncAsync(new ScreenshotRequest
    /// {
    ///     Url = "https://github.com",
    ///     Device = "Desktop HD"
    /// });
    /// Console.WriteLine($"Job ID: {job.Id}");
    /// </code>
    /// </example>
    Task<AsyncJobCreatedResponse> CaptureAsyncAsync(ScreenshotRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all screenshot jobs.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of jobs.</returns>
    Task<List<JobResponse>> ListJobsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a job by ID.
    /// </summary>
    /// <param name="id">Job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Job details.</returns>
    Task<JobResponse> GetJobAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the result image for a completed job.
    /// </summary>
    /// <param name="id">Job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Image bytes.</returns>
    Task<byte[]> GetJobResultAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a job.
    /// </summary>
    /// <param name="id">Job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated job details.</returns>
    Task<JobResponse> CancelJobAsync(string id, CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of the screenshots client.
/// </summary>
internal class ScreenshotsClient : BaseClient, IScreenshotsClient
{
    public ScreenshotsClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<byte[]> CaptureAsync(ScreenshotRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        return await PostBytesAsync("v1/screenshots", request, cancellationToken);
    }

    public async Task<AsyncJobCreatedResponse> CaptureAsyncAsync(ScreenshotRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        return await PostAsync<ScreenshotRequest, AsyncJobCreatedResponse>("v1/screenshots/async", request, cancellationToken);
    }

    public async Task<List<JobResponse>> ListJobsAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<List<JobResponse>>("v1/screenshots/jobs", cancellationToken);
    }

    public async Task<JobResponse> GetJobAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Job ID is required");
        }

        return await GetAsync<JobResponse>($"v1/screenshots/jobs/{Uri.EscapeDataString(id)}", cancellationToken);
    }

    public async Task<byte[]> GetJobResultAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Job ID is required");
        }

        return await GetBytesAsync($"v1/screenshots/jobs/{Uri.EscapeDataString(id)}/result", cancellationToken);
    }

    public async Task<JobResponse> CancelJobAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Job ID is required");
        }

        return await PostAsync<JobResponse>($"v1/screenshots/jobs/{Uri.EscapeDataString(id)}/cancel", cancellationToken);
    }

    private static void ValidateRequest(ScreenshotRequest request)
    {
        var errors = new List<Exceptions.ValidationError>();

        if (string.IsNullOrEmpty(request.Url))
        {
            errors.Add(new Exceptions.ValidationError("url", "URL is required"));
        }
        else if (!request.Url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                 !request.Url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(new Exceptions.ValidationError("url", "URL must start with http:// or https://"));
        }

        if (request.Quality.HasValue && (request.Quality < 1 || request.Quality > 100))
        {
            errors.Add(new Exceptions.ValidationError("quality", "Quality must be between 1 and 100"));
        }

        if (request.Delay.HasValue && (request.Delay < 0 || request.Delay > 30000))
        {
            errors.Add(new Exceptions.ValidationError("delay", "Delay must be between 0 and 30000"));
        }

        if (request.Timeout.HasValue && (request.Timeout < 1000 || request.Timeout > 60000))
        {
            errors.Add(new Exceptions.ValidationError("timeout", "Timeout must be between 1000 and 60000"));
        }

        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException("Invalid screenshot request", errors);
        }
    }
}
