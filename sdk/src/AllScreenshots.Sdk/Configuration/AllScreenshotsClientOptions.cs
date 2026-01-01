namespace AllScreenshots.Sdk.Configuration;

/// <summary>
/// Configuration options for the Allscreenshots client.
/// </summary>
public class AllScreenshotsClientOptions
{
    /// <summary>
    /// Default base URL for the API.
    /// </summary>
    public const string DefaultBaseUrl = "https://api.allscreenshots.com";

    /// <summary>
    /// Environment variable name for the API key.
    /// </summary>
    public const string ApiKeyEnvironmentVariable = "ALLSCREENSHOTS_API_KEY";

    /// <summary>
    /// API key for authentication. If not provided, will attempt to read from
    /// ALLSCREENSHOTS_API_KEY environment variable.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Base URL for the API. Defaults to https://api.allscreenshots.com.
    /// </summary>
    public string BaseUrl { get; set; } = DefaultBaseUrl;

    /// <summary>
    /// Request timeout. Defaults to 120 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);

    /// <summary>
    /// Maximum number of retries for transient failures. Defaults to 3.
    /// </summary>
    public int MaxRetries { get; set; } = 3;

    /// <summary>
    /// Initial delay for retry backoff. Defaults to 1 second.
    /// </summary>
    public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(1);

    /// <summary>
    /// Maximum delay between retries. Defaults to 30 seconds.
    /// </summary>
    public TimeSpan MaxRetryDelay { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// User agent string to send with requests.
    /// </summary>
    public string? UserAgent { get; set; }

    /// <summary>
    /// Validates the configuration options.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown if configuration is invalid.</exception>
    internal void Validate()
    {
        var apiKey = ApiKey ?? Environment.GetEnvironmentVariable(ApiKeyEnvironmentVariable);

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException(
                $"API key is required. Either set {nameof(ApiKey)} or the {ApiKeyEnvironmentVariable} environment variable.");
        }

        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new ArgumentException($"{nameof(BaseUrl)} cannot be empty.");
        }

        if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out _))
        {
            throw new ArgumentException($"{nameof(BaseUrl)} must be a valid absolute URL.");
        }

        if (Timeout <= TimeSpan.Zero)
        {
            throw new ArgumentException($"{nameof(Timeout)} must be positive.");
        }

        if (MaxRetries < 0)
        {
            throw new ArgumentException($"{nameof(MaxRetries)} cannot be negative.");
        }
    }

    /// <summary>
    /// Gets the effective API key (from property or environment variable).
    /// </summary>
    internal string GetEffectiveApiKey()
    {
        return ApiKey ?? Environment.GetEnvironmentVariable(ApiKeyEnvironmentVariable)
            ?? throw new InvalidOperationException("API key not configured.");
    }
}
