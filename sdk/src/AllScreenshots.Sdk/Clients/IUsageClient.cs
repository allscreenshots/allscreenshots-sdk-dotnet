using AllScreenshots.Sdk.Models;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Client for usage and quota operations.
/// </summary>
public interface IUsageClient
{
    /// <summary>
    /// Gets usage statistics.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Usage statistics.</returns>
    /// <example>
    /// <code>
    /// var usage = await client.Usage.GetUsageAsync();
    /// Console.WriteLine($"Current period screenshots: {usage.CurrentPeriod?.ScreenshotsCount}");
    /// </code>
    /// </example>
    Task<UsageResponse> GetUsageAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets quota status.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Quota status.</returns>
    /// <example>
    /// <code>
    /// var quota = await client.Usage.GetQuotaAsync();
    /// Console.WriteLine($"Screenshots remaining: {quota.Screenshots?.Remaining}");
    /// </code>
    /// </example>
    Task<QuotaStatusResponse> GetQuotaAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of the usage client.
/// </summary>
internal class UsageClient : BaseClient, IUsageClient
{
    public UsageClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<UsageResponse> GetUsageAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<UsageResponse>("v1/usage", cancellationToken);
    }

    public async Task<QuotaStatusResponse> GetQuotaAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<QuotaStatusResponse>("v1/usage/quota", cancellationToken);
    }
}
