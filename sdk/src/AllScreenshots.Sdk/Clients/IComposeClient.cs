using AllScreenshots.Sdk.Models;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Client for compose (multi-screenshot) operations.
/// </summary>
public interface IComposeClient
{
    /// <summary>
    /// Composes multiple screenshots into one image.
    /// </summary>
    /// <param name="request">Compose request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Compose response (sync) or job status (async).</returns>
    /// <example>
    /// <code>
    /// var result = await client.Compose.CreateAsync(new ComposeRequest
    /// {
    ///     Captures = new List&lt;CaptureItem&gt;
    ///     {
    ///         new() { Url = "https://github.com", Device = "Desktop HD" },
    ///         new() { Url = "https://github.com", Device = "iPhone 14" }
    ///     },
    ///     Output = new ComposeOutputConfig { Layout = "HORIZONTAL" }
    /// });
    /// </code>
    /// </example>
    Task<ComposeJobStatusResponse> CreateAsync(ComposeRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Previews layout placement without capturing.
    /// </summary>
    /// <param name="layout">Layout type.</param>
    /// <param name="imageCount">Number of images.</param>
    /// <param name="canvasWidth">Canvas width.</param>
    /// <param name="canvasHeight">Canvas height.</param>
    /// <param name="aspectRatios">Aspect ratios for images.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Layout preview.</returns>
    Task<LayoutPreviewResponse> PreviewLayoutAsync(
        string layout,
        int imageCount,
        int? canvasWidth = null,
        int? canvasHeight = null,
        string? aspectRatios = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all compose jobs.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of compose job summaries.</returns>
    Task<List<ComposeJobSummaryResponse>> ListJobsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a compose job status.
    /// </summary>
    /// <param name="jobId">Job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Compose job status.</returns>
    Task<ComposeJobStatusResponse> GetJobAsync(string jobId, CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of the compose client.
/// </summary>
internal class ComposeClient : BaseClient, IComposeClient
{
    public ComposeClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ComposeJobStatusResponse> CreateAsync(ComposeRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        return await PostAsync<ComposeRequest, ComposeJobStatusResponse>("v1/screenshots/compose", request, cancellationToken);
    }

    public async Task<LayoutPreviewResponse> PreviewLayoutAsync(
        string layout,
        int imageCount,
        int? canvasWidth = null,
        int? canvasHeight = null,
        string? aspectRatios = null,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(layout))
        {
            throw new Exceptions.ValidationException("Layout is required");
        }

        if (imageCount < 1 || imageCount > 20)
        {
            throw new Exceptions.ValidationException("Image count must be between 1 and 20");
        }

        var query = $"layout={Uri.EscapeDataString(layout)}&image_count={imageCount}";

        if (canvasWidth.HasValue)
        {
            query += $"&canvas_width={canvasWidth.Value}";
        }

        if (canvasHeight.HasValue)
        {
            query += $"&canvas_height={canvasHeight.Value}";
        }

        if (!string.IsNullOrEmpty(aspectRatios))
        {
            query += $"&aspect_ratios={Uri.EscapeDataString(aspectRatios)}";
        }

        return await GetAsync<LayoutPreviewResponse>($"v1/screenshots/compose/preview?{query}", cancellationToken);
    }

    public async Task<List<ComposeJobSummaryResponse>> ListJobsAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<List<ComposeJobSummaryResponse>>("v1/screenshots/compose/jobs", cancellationToken);
    }

    public async Task<ComposeJobStatusResponse> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(jobId))
        {
            throw new Exceptions.ValidationException("Job ID is required");
        }

        return await GetAsync<ComposeJobStatusResponse>($"v1/screenshots/compose/jobs/{Uri.EscapeDataString(jobId)}", cancellationToken);
    }

    private static void ValidateRequest(ComposeRequest request)
    {
        var errors = new List<Exceptions.ValidationError>();

        var hasCaptures = request.Captures != null && request.Captures.Count > 0;
        var hasVariants = request.Variants != null && request.Variants.Count > 0 && !string.IsNullOrEmpty(request.Url);

        if (!hasCaptures && !hasVariants)
        {
            errors.Add(new Exceptions.ValidationError("captures", "Either captures or url with variants is required"));
        }

        if (hasCaptures && request.Captures!.Count > 20)
        {
            errors.Add(new Exceptions.ValidationError("captures", "Maximum 20 captures allowed"));
        }

        if (hasVariants && request.Variants!.Count > 20)
        {
            errors.Add(new Exceptions.ValidationError("variants", "Maximum 20 variants allowed"));
        }

        if (hasCaptures)
        {
            for (var i = 0; i < request.Captures!.Count; i++)
            {
                var capture = request.Captures[i];
                if (string.IsNullOrEmpty(capture.Url))
                {
                    errors.Add(new Exceptions.ValidationError($"captures[{i}].url", "URL is required"));
                }
                else if (!capture.Url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                         !capture.Url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    errors.Add(new Exceptions.ValidationError($"captures[{i}].url", "URL must start with http:// or https://"));
                }
            }
        }

        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException("Invalid compose request", errors);
        }
    }
}
