using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Viewport configuration for screenshot capture.
/// </summary>
public class ViewportConfig
{
    /// <summary>
    /// Width of the viewport in pixels (100-4096).
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Height of the viewport in pixels (100-4096).
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Device scale factor (1-3).
    /// </summary>
    [JsonPropertyName("deviceScaleFactor")]
    public int? DeviceScaleFactor { get; set; }
}
