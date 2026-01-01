using AllScreenshots.Sdk.Models;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Client for bulk screenshot operations.
/// </summary>
public interface IBulkClient
{
    /// <summary>
    /// Creates a bulk screenshot job.
    /// </summary>
    /// <param name="request">Bulk request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Bulk job response.</returns>
    /// <example>
    /// <code>
    /// var bulk = await client.Bulk.CreateAsync(new BulkRequest
    /// {
    ///     Urls = new List&lt;BulkUrlRequest&gt;
    ///     {
    ///         new() { Url = "https://github.com" },
    ///         new() { Url = "https://google.com" }
    ///     },
    ///     Defaults = new BulkDefaults { Device = "Desktop HD" }
    /// });
    /// </code>
    /// </example>
    Task<BulkResponse> CreateAsync(BulkRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all bulk jobs.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of bulk job summaries.</returns>
    Task<List<BulkJobSummary>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a bulk job status with detailed information.
    /// </summary>
    /// <param name="id">Bulk job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Bulk job status.</returns>
    Task<BulkStatusResponse> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a bulk job.
    /// </summary>
    /// <param name="id">Bulk job ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated bulk job summary.</returns>
    Task<BulkJobSummary> CancelAsync(string id, CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of the bulk client.
/// </summary>
internal class BulkClient : BaseClient, IBulkClient
{
    public BulkClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<BulkResponse> CreateAsync(BulkRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        return await PostAsync<BulkRequest, BulkResponse>("v1/screenshots/bulk", request, cancellationToken);
    }

    public async Task<List<BulkJobSummary>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<List<BulkJobSummary>>("v1/screenshots/bulk", cancellationToken);
    }

    public async Task<BulkStatusResponse> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Bulk job ID is required");
        }

        return await GetAsync<BulkStatusResponse>($"v1/screenshots/bulk/{Uri.EscapeDataString(id)}", cancellationToken);
    }

    public async Task<BulkJobSummary> CancelAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Bulk job ID is required");
        }

        return await PostAsync<BulkJobSummary>($"v1/screenshots/bulk/{Uri.EscapeDataString(id)}/cancel", cancellationToken);
    }

    private static void ValidateRequest(BulkRequest request)
    {
        var errors = new List<Exceptions.ValidationError>();

        if (request.Urls == null || request.Urls.Count == 0)
        {
            errors.Add(new Exceptions.ValidationError("urls", "At least one URL is required"));
        }
        else if (request.Urls.Count > 100)
        {
            errors.Add(new Exceptions.ValidationError("urls", "Maximum 100 URLs allowed"));
        }
        else
        {
            for (var i = 0; i < request.Urls.Count; i++)
            {
                var urlRequest = request.Urls[i];
                if (string.IsNullOrEmpty(urlRequest.Url))
                {
                    errors.Add(new Exceptions.ValidationError($"urls[{i}].url", "URL is required"));
                }
                else if (!urlRequest.Url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                         !urlRequest.Url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    errors.Add(new Exceptions.ValidationError($"urls[{i}].url", "URL must start with http:// or https://"));
                }
            }
        }

        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException("Invalid bulk request", errors);
        }
    }
}
