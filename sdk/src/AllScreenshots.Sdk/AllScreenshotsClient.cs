using AllScreenshots.Sdk.Clients;
using AllScreenshots.Sdk.Configuration;
using AllScreenshots.Sdk.Http;

namespace AllScreenshots.Sdk;

/// <summary>
/// Main client for the Allscreenshots API.
/// </summary>
/// <example>
/// Basic usage:
/// <code>
/// // Using environment variable ALLSCREENSHOTS_API_KEY
/// using var client = new AllScreenshotsClient();
///
/// // Or with explicit API key
/// using var client = new AllScreenshotsClient(options =>
/// {
///     options.ApiKey = "your-api-key";
/// });
///
/// // Take a screenshot
/// var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
/// {
///     Url = "https://github.com",
///     Device = "Desktop HD"
/// });
/// </code>
/// </example>
public sealed class AllScreenshotsClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private bool _disposed;

    /// <summary>
    /// Client for screenshot operations.
    /// </summary>
    public IScreenshotsClient Screenshots { get; }

    /// <summary>
    /// Client for bulk screenshot operations.
    /// </summary>
    public IBulkClient Bulk { get; }

    /// <summary>
    /// Client for compose operations.
    /// </summary>
    public IComposeClient Compose { get; }

    /// <summary>
    /// Client for schedule operations.
    /// </summary>
    public ISchedulesClient Schedules { get; }

    /// <summary>
    /// Client for usage and quota operations.
    /// </summary>
    public IUsageClient Usage { get; }

    /// <summary>
    /// Creates a new AllScreenshotsClient using the ALLSCREENSHOTS_API_KEY environment variable.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown if API key is not configured.</exception>
    public AllScreenshotsClient()
        : this(new AllScreenshotsClientOptions())
    {
    }

    /// <summary>
    /// Creates a new AllScreenshotsClient with the specified options.
    /// </summary>
    /// <param name="options">Client options.</param>
    /// <exception cref="ArgumentException">Thrown if options are invalid.</exception>
    public AllScreenshotsClient(AllScreenshotsClientOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        options.Validate();

        _httpClient = HttpClientFactory.Create(options);
        Screenshots = new ScreenshotsClient(_httpClient);
        Bulk = new BulkClient(_httpClient);
        Compose = new ComposeClient(_httpClient);
        Schedules = new SchedulesClient(_httpClient);
        Usage = new UsageClient(_httpClient);
    }

    /// <summary>
    /// Creates a new AllScreenshotsClient with configuration action.
    /// </summary>
    /// <param name="configure">Configuration action.</param>
    /// <exception cref="ArgumentException">Thrown if options are invalid.</exception>
    public AllScreenshotsClient(Action<AllScreenshotsClientOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var options = new AllScreenshotsClientOptions();
        configure(options);
        options.Validate();

        _httpClient = HttpClientFactory.Create(options);
        Screenshots = new ScreenshotsClient(_httpClient);
        Bulk = new BulkClient(_httpClient);
        Compose = new ComposeClient(_httpClient);
        Schedules = new SchedulesClient(_httpClient);
        Usage = new UsageClient(_httpClient);
    }

    /// <summary>
    /// Creates a new AllScreenshotsClient using a builder pattern.
    /// </summary>
    /// <returns>Client builder.</returns>
    public static AllScreenshotsClientBuilder CreateBuilder() => new();

    /// <summary>
    /// Disposes the client and releases resources.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _httpClient.Dispose();
        _disposed = true;
    }
}

/// <summary>
/// Builder for creating AllScreenshotsClient instances.
/// </summary>
/// <example>
/// <code>
/// using var client = AllScreenshotsClient.CreateBuilder()
///     .WithApiKey("your-api-key")
///     .WithTimeout(TimeSpan.FromMinutes(5))
///     .Build();
/// </code>
/// </example>
public sealed class AllScreenshotsClientBuilder
{
    private readonly AllScreenshotsClientOptions _options = new();

    /// <summary>
    /// Sets the API key.
    /// </summary>
    /// <param name="apiKey">API key.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithApiKey(string apiKey)
    {
        _options.ApiKey = apiKey;
        return this;
    }

    /// <summary>
    /// Sets the base URL.
    /// </summary>
    /// <param name="baseUrl">Base URL.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithBaseUrl(string baseUrl)
    {
        _options.BaseUrl = baseUrl;
        return this;
    }

    /// <summary>
    /// Sets the request timeout.
    /// </summary>
    /// <param name="timeout">Timeout.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithTimeout(TimeSpan timeout)
    {
        _options.Timeout = timeout;
        return this;
    }

    /// <summary>
    /// Sets the maximum number of retries.
    /// </summary>
    /// <param name="maxRetries">Maximum retries.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithMaxRetries(int maxRetries)
    {
        _options.MaxRetries = maxRetries;
        return this;
    }

    /// <summary>
    /// Sets the initial retry delay.
    /// </summary>
    /// <param name="delay">Initial delay.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithRetryDelay(TimeSpan delay)
    {
        _options.RetryDelay = delay;
        return this;
    }

    /// <summary>
    /// Sets the maximum retry delay.
    /// </summary>
    /// <param name="maxDelay">Maximum delay.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithMaxRetryDelay(TimeSpan maxDelay)
    {
        _options.MaxRetryDelay = maxDelay;
        return this;
    }

    /// <summary>
    /// Sets a custom user agent.
    /// </summary>
    /// <param name="userAgent">User agent string.</param>
    /// <returns>This builder.</returns>
    public AllScreenshotsClientBuilder WithUserAgent(string userAgent)
    {
        _options.UserAgent = userAgent;
        return this;
    }

    /// <summary>
    /// Builds the client.
    /// </summary>
    /// <returns>Configured client.</returns>
    /// <exception cref="ArgumentException">Thrown if options are invalid.</exception>
    public AllScreenshotsClient Build()
    {
        return new AllScreenshotsClient(_options);
    }
}
