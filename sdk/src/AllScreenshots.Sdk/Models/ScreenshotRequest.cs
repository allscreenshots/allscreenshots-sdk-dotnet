using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Request to capture a screenshot.
/// </summary>
public class ScreenshotRequest
{
    /// <summary>
    /// URL to capture. Must start with http:// or https://.
    /// </summary>
    /// <example>https://github.com</example>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Custom viewport configuration.
    /// </summary>
    [JsonPropertyName("viewport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewportConfig? Viewport { get; set; }

    /// <summary>
    /// Device preset name (e.g., "Desktop HD", "iPhone 14", "iPad").
    /// </summary>
    [JsonPropertyName("device")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Device { get; set; }

    /// <summary>
    /// Output format for the screenshot.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    /// <summary>
    /// Whether to capture the full page.
    /// </summary>
    [JsonPropertyName("fullPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Image quality (1-100). Applies to JPEG and WebP formats.
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Delay in milliseconds before capturing (0-30000).
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Delay { get; set; }

    /// <summary>
    /// CSS selector to wait for before capturing.
    /// </summary>
    [JsonPropertyName("waitFor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitFor { get; set; }

    /// <summary>
    /// Wait condition for page loading.
    /// </summary>
    [JsonPropertyName("waitUntil")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitUntil { get; set; }

    /// <summary>
    /// Timeout in milliseconds (1000-60000).
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Whether to enable dark mode.
    /// </summary>
    [JsonPropertyName("darkMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Custom CSS to inject before capturing (max 10000 chars).
    /// </summary>
    [JsonPropertyName("customCss")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CustomCss { get; set; }

    /// <summary>
    /// CSS selectors to hide before capturing (max 50).
    /// </summary>
    [JsonPropertyName("hideSelectors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? HideSelectors { get; set; }

    /// <summary>
    /// CSS selector of element to capture (max 500 chars).
    /// </summary>
    [JsonPropertyName("selector")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Selector { get; set; }

    /// <summary>
    /// Whether to block ads.
    /// </summary>
    [JsonPropertyName("blockAds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Whether to block cookie banners.
    /// </summary>
    [JsonPropertyName("blockCookieBanners")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockCookieBanners { get; set; }

    /// <summary>
    /// Ad/content blocking level.
    /// </summary>
    [JsonPropertyName("blockLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BlockLevel { get; set; }

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

    /// <summary>
    /// Response type (BINARY or JSON).
    /// </summary>
    [JsonPropertyName("responseType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ResponseType { get; set; }
}
