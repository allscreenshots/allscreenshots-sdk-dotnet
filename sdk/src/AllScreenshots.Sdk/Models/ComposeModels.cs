using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Request to compose multiple screenshots.
/// </summary>
public class ComposeRequest
{
    /// <summary>
    /// Multiple URLs to capture (max 20).
    /// </summary>
    [JsonPropertyName("captures")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<CaptureItem>? Captures { get; set; }

    /// <summary>
    /// Single URL (use with variants).
    /// </summary>
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    /// <summary>
    /// Different configurations for the same URL (max 20).
    /// </summary>
    [JsonPropertyName("variants")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<VariantConfig>? Variants { get; set; }

    /// <summary>
    /// Default capture options.
    /// </summary>
    [JsonPropertyName("defaults")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CaptureDefaults? Defaults { get; set; }

    /// <summary>
    /// Output configuration.
    /// </summary>
    [JsonPropertyName("output")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ComposeOutputConfig? Output { get; set; }

    /// <summary>
    /// Whether to process asynchronously.
    /// </summary>
    [JsonPropertyName("async")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Async { get; set; }

    /// <summary>
    /// Webhook URL for result notification.
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// Webhook secret for verification.
    /// </summary>
    [JsonPropertyName("webhookSecret")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WebhookSecret { get; set; }

    /// <summary>
    /// Whether using captures mode.
    /// </summary>
    [JsonPropertyName("capturesMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CapturesMode { get; set; }

    /// <summary>
    /// Whether using variants mode.
    /// </summary>
    [JsonPropertyName("variantsMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? VariantsMode { get; set; }
}

/// <summary>
/// Single capture item.
/// </summary>
public class CaptureItem
{
    /// <summary>
    /// URL to capture.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Capture identifier.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    /// <summary>
    /// Label for the capture.
    /// </summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    /// Viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset.
    /// </summary>
    [JsonPropertyName("device")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Device { get; set; }

    /// <summary>
    /// Capture full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Enable dark mode.
    /// </summary>
    [JsonPropertyName("darkMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Delay before capture.
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Delay { get; set; }
}

/// <summary>
/// Variant configuration for same URL.
/// </summary>
public class VariantConfig
{
    /// <summary>
    /// Variant identifier.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    /// <summary>
    /// Variant label.
    /// </summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    /// Viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset.
    /// </summary>
    [JsonPropertyName("device")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Device { get; set; }

    /// <summary>
    /// Capture full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Enable dark mode.
    /// </summary>
    [JsonPropertyName("darkMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Delay before capture.
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Delay { get; set; }

    /// <summary>
    /// Custom CSS to inject.
    /// </summary>
    [JsonPropertyName("customCss")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CustomCss { get; set; }
}

/// <summary>
/// Default options for captures.
/// </summary>
public class CaptureDefaults
{
    /// <summary>
    /// Viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset.
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
    /// Capture full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Image quality.
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Delay before capture.
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
    /// Selectors to hide.
    /// </summary>
    [JsonPropertyName("hideSelectors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? HideSelectors { get; set; }

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
/// Output configuration for compose.
/// </summary>
public class ComposeOutputConfig
{
    /// <summary>
    /// Layout type.
    /// </summary>
    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Layout { get; set; }

    /// <summary>
    /// Output format.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    /// <summary>
    /// Image quality (1-100).
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Number of columns (1-10).
    /// </summary>
    [JsonPropertyName("columns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Columns { get; set; }

    /// <summary>
    /// Spacing between images (0-100).
    /// </summary>
    [JsonPropertyName("spacing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Spacing { get; set; }

    /// <summary>
    /// Padding around the canvas (0-100).
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Padding { get; set; }

    /// <summary>
    /// Background color (#RRGGBB, #RRGGBBAA, or "transparent").
    /// </summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>
    /// Vertical alignment.
    /// </summary>
    [JsonPropertyName("alignment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Alignment { get; set; }

    /// <summary>
    /// Maximum width (100-10000).
    /// </summary>
    [JsonPropertyName("maxWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxWidth { get; set; }

    /// <summary>
    /// Maximum height (100-10000).
    /// </summary>
    [JsonPropertyName("maxHeight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxHeight { get; set; }

    /// <summary>
    /// Thumbnail width (50-2000).
    /// </summary>
    [JsonPropertyName("thumbnailWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Label configuration.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LabelConfig? Labels { get; set; }

    /// <summary>
    /// Border configuration.
    /// </summary>
    [JsonPropertyName("border")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BorderConfig? Border { get; set; }

    /// <summary>
    /// Shadow configuration.
    /// </summary>
    [JsonPropertyName("shadow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ShadowConfig? Shadow { get; set; }
}

/// <summary>
/// Label configuration.
/// </summary>
public class LabelConfig
{
    /// <summary>
    /// Whether labels are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Label position.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Position { get; set; }

    /// <summary>
    /// Font size.
    /// </summary>
    [JsonPropertyName("fontSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FontSize { get; set; }

    /// <summary>
    /// Font color.
    /// </summary>
    [JsonPropertyName("fontColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FontColor { get; set; }

    /// <summary>
    /// Background color.
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BackgroundColor { get; set; }
}

/// <summary>
/// Border configuration.
/// </summary>
public class BorderConfig
{
    /// <summary>
    /// Whether borders are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Border width.
    /// </summary>
    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }

    /// <summary>
    /// Border color.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>
    /// Border radius.
    /// </summary>
    [JsonPropertyName("radius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Radius { get; set; }
}

/// <summary>
/// Shadow configuration.
/// </summary>
public class ShadowConfig
{
    /// <summary>
    /// Whether shadows are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Shadow X offset.
    /// </summary>
    [JsonPropertyName("offsetX")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OffsetX { get; set; }

    /// <summary>
    /// Shadow Y offset.
    /// </summary>
    [JsonPropertyName("offsetY")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? OffsetY { get; set; }

    /// <summary>
    /// Shadow blur radius.
    /// </summary>
    [JsonPropertyName("blur")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Blur { get; set; }

    /// <summary>
    /// Shadow color.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }
}

/// <summary>
/// Compose response.
/// </summary>
public class ComposeResponse
{
    /// <summary>
    /// Result URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Storage URL.
    /// </summary>
    [JsonPropertyName("storageUrl")]
    public string? StorageUrl { get; set; }

    /// <summary>
    /// When the result expires.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTimeOffset? ExpiresAt { get; set; }

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
    /// Output format.
    /// </summary>
    [JsonPropertyName("format")]
    public string? Format { get; set; }

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
    /// Layout type used.
    /// </summary>
    [JsonPropertyName("layout")]
    public string? Layout { get; set; }

    /// <summary>
    /// Additional metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public ComposeMetadata? Metadata { get; set; }
}

/// <summary>
/// Compose metadata.
/// </summary>
public class ComposeMetadata
{
    /// <summary>
    /// Capture information.
    /// </summary>
    [JsonPropertyName("captures")]
    public List<CaptureMetadata>? Captures { get; set; }
}

/// <summary>
/// Metadata for a single capture.
/// </summary>
public class CaptureMetadata
{
    /// <summary>
    /// Capture identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Capture label.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Captured URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

/// <summary>
/// Compose job status response.
/// </summary>
public class ComposeJobStatusResponse
{
    /// <summary>
    /// Job identifier.
    /// </summary>
    [JsonPropertyName("jobId")]
    public string JobId { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Progress percentage.
    /// </summary>
    [JsonPropertyName("progress")]
    public int Progress { get; set; }

    /// <summary>
    /// Total captures.
    /// </summary>
    [JsonPropertyName("totalCaptures")]
    public int TotalCaptures { get; set; }

    /// <summary>
    /// Completed captures.
    /// </summary>
    [JsonPropertyName("completedCaptures")]
    public int CompletedCaptures { get; set; }

    /// <summary>
    /// Result when completed.
    /// </summary>
    [JsonPropertyName("result")]
    public ComposeResponse? Result { get; set; }

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

/// <summary>
/// Compose job summary.
/// </summary>
public class ComposeJobSummaryResponse
{
    /// <summary>
    /// Job identifier.
    /// </summary>
    [JsonPropertyName("jobId")]
    public string JobId { get; set; } = string.Empty;

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Total captures.
    /// </summary>
    [JsonPropertyName("totalCaptures")]
    public int TotalCaptures { get; set; }

    /// <summary>
    /// Completed captures.
    /// </summary>
    [JsonPropertyName("completedCaptures")]
    public int CompletedCaptures { get; set; }

    /// <summary>
    /// Failed captures.
    /// </summary>
    [JsonPropertyName("failedCaptures")]
    public int FailedCaptures { get; set; }

    /// <summary>
    /// Progress percentage.
    /// </summary>
    [JsonPropertyName("progress")]
    public int Progress { get; set; }

    /// <summary>
    /// Layout type.
    /// </summary>
    [JsonPropertyName("layoutType")]
    public string? LayoutType { get; set; }

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

/// <summary>
/// Layout preview response.
/// </summary>
public class LayoutPreviewResponse
{
    /// <summary>
    /// Requested layout.
    /// </summary>
    [JsonPropertyName("layout")]
    public string? Layout { get; set; }

    /// <summary>
    /// Resolved layout.
    /// </summary>
    [JsonPropertyName("resolvedLayout")]
    public string? ResolvedLayout { get; set; }

    /// <summary>
    /// Canvas width.
    /// </summary>
    [JsonPropertyName("canvasWidth")]
    public int CanvasWidth { get; set; }

    /// <summary>
    /// Canvas height.
    /// </summary>
    [JsonPropertyName("canvasHeight")]
    public int CanvasHeight { get; set; }

    /// <summary>
    /// Placements.
    /// </summary>
    [JsonPropertyName("placements")]
    public List<PlacementPreview>? Placements { get; set; }

    /// <summary>
    /// Additional metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object>? Metadata { get; set; }
}

/// <summary>
/// Placement preview.
/// </summary>
public class PlacementPreview
{
    /// <summary>
    /// Index.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// X position.
    /// </summary>
    [JsonPropertyName("x")]
    public int X { get; set; }

    /// <summary>
    /// Y position.
    /// </summary>
    [JsonPropertyName("y")]
    public int Y { get; set; }

    /// <summary>
    /// Width.
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Height.
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// Label.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }
}
