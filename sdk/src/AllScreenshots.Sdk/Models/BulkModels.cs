using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Request to create a bulk screenshot job.
/// </summary>
public class BulkRequest
{
    /// <summary>
    /// URLs to capture (max 100).
    /// </summary>
    [JsonPropertyName("urls")]
    public required List<BulkUrlRequest> Urls { get; set; }

    /// <summary>
    /// Default options applied to all screenshots.
    /// </summary>
    [JsonPropertyName("defaults")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BulkDefaults? Defaults { get; set; }

    /// <summary>
    /// Webhook URL to receive the result.
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// Secret for webhook verification.
    /// </summary>
    [JsonPropertyName("webhookSecret")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WebhookSecret { get; set; }
}

/// <summary>
/// Single URL in a bulk request.
/// </summary>
public class BulkUrlRequest
{
    /// <summary>
    /// URL to capture.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Options specific to this URL.
    /// </summary>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BulkUrlOptions? Options { get; set; }
}

/// <summary>
/// Options for a single URL in bulk request.
/// </summary>
public class BulkUrlOptions
{
    /// <summary>
    /// Custom viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset name.
    /// </summary>
    [JsonPropertyName("device")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Device { get; set; }

    /// <summary>
    /// Output format.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    /// <summary>
    /// Whether to capture full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Image quality (1-100).
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Delay before capturing (0-30000ms).
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Delay { get; set; }

    /// <summary>
    /// CSS selector to wait for.
    /// </summary>
    [JsonPropertyName("waitFor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitFor { get; set; }

    /// <summary>
    /// Wait condition.
    /// </summary>
    [JsonPropertyName("waitUntil")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitUntil { get; set; }

    /// <summary>
    /// Timeout in milliseconds.
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Enable dark mode.
    /// </summary>
    [JsonPropertyName("darkMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Custom CSS to inject.
    /// </summary>
    [JsonPropertyName("customCss")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CustomCss { get; set; }

    /// <summary>
    /// Block ads.
    /// </summary>
    [JsonPropertyName("blockAds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Block cookie banners.
    /// </summary>
    [JsonPropertyName("blockCookieBanners")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockCookieBanners { get; set; }

    /// <summary>
    /// Blocking level.
    /// </summary>
    [JsonPropertyName("blockLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BlockLevel { get; set; }
}

/// <summary>
/// Default options for bulk screenshots.
/// </summary>
public class BulkDefaults
{
    /// <summary>
    /// Custom viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset name.
    /// </summary>
    [JsonPropertyName("device")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Device { get; set; }

    /// <summary>
    /// Output format.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    /// <summary>
    /// Whether to capture full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Image quality (1-100).
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Delay before capturing (0-30000ms).
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Delay { get; set; }

    /// <summary>
    /// CSS selector to wait for.
    /// </summary>
    [JsonPropertyName("waitFor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitFor { get; set; }

    /// <summary>
    /// Wait condition.
    /// </summary>
    [JsonPropertyName("waitUntil")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitUntil { get; set; }

    /// <summary>
    /// Timeout in milliseconds.
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Enable dark mode.
    /// </summary>
    [JsonPropertyName("darkMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Custom CSS to inject.
    /// </summary>
    [JsonPropertyName("customCss")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CustomCss { get; set; }

    /// <summary>
    /// Block ads.
    /// </summary>
    [JsonPropertyName("blockAds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Block cookie banners.
    /// </summary>
    [JsonPropertyName("blockCookieBanners")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockCookieBanners { get; set; }

    /// <summary>
    /// Blocking level.
    /// </summary>
    [JsonPropertyName("blockLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BlockLevel { get; set; }
}

/// <summary>
/// Response when a bulk job is created.
/// </summary>
public class BulkResponse
{
    /// <summary>
    /// Unique bulk job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Total number of jobs.
    /// </summary>
    [JsonPropertyName("totalJobs")]
    public int TotalJobs { get; set; }

    /// <summary>
    /// Number of completed jobs.
    /// </summary>
    [JsonPropertyName("completedJobs")]
    public int CompletedJobs { get; set; }

    /// <summary>
    /// Number of failed jobs.
    /// </summary>
    [JsonPropertyName("failedJobs")]
    public int FailedJobs { get; set; }

    /// <summary>
    /// Progress percentage (0-100).
    /// </summary>
    [JsonPropertyName("progress")]
    public int Progress { get; set; }

    /// <summary>
    /// Individual job information.
    /// </summary>
    [JsonPropertyName("jobs")]
    public List<BulkJobInfo>? Jobs { get; set; }

    /// <summary>
    /// When the bulk job was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// When the bulk job completed.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTimeOffset? CompletedAt { get; set; }
}

/// <summary>
/// Basic bulk job info.
/// </summary>
public class BulkJobInfo
{
    /// <summary>
    /// Job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// URL being captured.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Job status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}

/// <summary>
/// Summary of a bulk job.
/// </summary>
public class BulkJobSummary
{
    /// <summary>
    /// Unique bulk job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Total number of jobs.
    /// </summary>
    [JsonPropertyName("totalJobs")]
    public int TotalJobs { get; set; }

    /// <summary>
    /// Number of completed jobs.
    /// </summary>
    [JsonPropertyName("completedJobs")]
    public int CompletedJobs { get; set; }

    /// <summary>
    /// Number of failed jobs.
    /// </summary>
    [JsonPropertyName("failedJobs")]
    public int FailedJobs { get; set; }

    /// <summary>
    /// Progress percentage (0-100).
    /// </summary>
    [JsonPropertyName("progress")]
    public int Progress { get; set; }

    /// <summary>
    /// When the bulk job was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// When the bulk job completed.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTimeOffset? CompletedAt { get; set; }
}

/// <summary>
/// Detailed bulk job status.
/// </summary>
public class BulkStatusResponse
{
    /// <summary>
    /// Unique bulk job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Total number of jobs.
    /// </summary>
    [JsonPropertyName("totalJobs")]
    public int TotalJobs { get; set; }

    /// <summary>
    /// Number of completed jobs.
    /// </summary>
    [JsonPropertyName("completedJobs")]
    public int CompletedJobs { get; set; }

    /// <summary>
    /// Number of failed jobs.
    /// </summary>
    [JsonPropertyName("failedJobs")]
    public int FailedJobs { get; set; }

    /// <summary>
    /// Progress percentage (0-100).
    /// </summary>
    [JsonPropertyName("progress")]
    public int Progress { get; set; }

    /// <summary>
    /// Detailed job information.
    /// </summary>
    [JsonPropertyName("jobs")]
    public List<BulkJobDetailInfo>? Jobs { get; set; }

    /// <summary>
    /// When the bulk job was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// When the bulk job completed.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTimeOffset? CompletedAt { get; set; }
}

/// <summary>
/// Detailed information about a job in a bulk request.
/// </summary>
public class BulkJobDetailInfo
{
    /// <summary>
    /// Job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// URL being captured.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Job status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// URL to download the result.
    /// </summary>
    [JsonPropertyName("resultUrl")]
    public string? ResultUrl { get; set; }

    /// <summary>
    /// Storage URL.
    /// </summary>
    [JsonPropertyName("storageUrl")]
    public string? StorageUrl { get; set; }

    /// <summary>
    /// Output format.
    /// </summary>
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    /// <summary>
    /// Image width.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Image height.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// File size in bytes.
    /// </summary>
    [JsonPropertyName("fileSize")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Render time in milliseconds.
    /// </summary>
    [JsonPropertyName("renderTimeMs")]
    public long? RenderTimeMs { get; set; }

    /// <summary>
    /// Error code if failed.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Error message if failed.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// When the job was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// When the job completed.
    /// </summary>
    [JsonPropertyName("completedAt")]
    public DateTimeOffset? CompletedAt { get; set; }
}
