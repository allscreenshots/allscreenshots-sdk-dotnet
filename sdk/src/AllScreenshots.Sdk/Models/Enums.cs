using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Image format for screenshot output.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ImageFormat
{
    /// <summary>PNG format</summary>
    [JsonPropertyName("png")]
    Png,

    /// <summary>JPEG format</summary>
    [JsonPropertyName("jpeg")]
    Jpeg,

    /// <summary>JPG format (alias for JPEG)</summary>
    [JsonPropertyName("jpg")]
    Jpg,

    /// <summary>WebP format</summary>
    [JsonPropertyName("webp")]
    Webp,

    /// <summary>PDF format</summary>
    [JsonPropertyName("pdf")]
    Pdf
}

/// <summary>
/// Wait condition for page loading.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WaitUntil
{
    /// <summary>Wait for the load event</summary>
    [JsonPropertyName("load")]
    Load,

    /// <summary>Wait for DOMContentLoaded event</summary>
    [JsonPropertyName("domcontentloaded")]
    DomContentLoaded,

    /// <summary>Wait for network to be idle</summary>
    [JsonPropertyName("networkidle")]
    NetworkIdle,

    /// <summary>Wait for commit</summary>
    [JsonPropertyName("commit")]
    Commit
}

/// <summary>
/// Ad/content blocking level.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlockLevel
{
    /// <summary>No blocking</summary>
    [JsonPropertyName("none")]
    None,

    /// <summary>Light blocking</summary>
    [JsonPropertyName("light")]
    Light,

    /// <summary>Normal blocking</summary>
    [JsonPropertyName("normal")]
    Normal,

    /// <summary>Pro blocking</summary>
    [JsonPropertyName("pro")]
    Pro,

    /// <summary>Pro Plus blocking</summary>
    [JsonPropertyName("pro_plus")]
    ProPlus,

    /// <summary>Ultimate blocking</summary>
    [JsonPropertyName("ultimate")]
    Ultimate
}

/// <summary>
/// Response type for screenshot requests.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ResponseType
{
    /// <summary>Return binary image data</summary>
    [JsonPropertyName("BINARY")]
    Binary,

    /// <summary>Return JSON response</summary>
    [JsonPropertyName("JSON")]
    Json
}

/// <summary>
/// Job status.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobStatus
{
    /// <summary>Job is queued</summary>
    [JsonPropertyName("QUEUED")]
    Queued,

    /// <summary>Job is processing</summary>
    [JsonPropertyName("PROCESSING")]
    Processing,

    /// <summary>Job completed successfully</summary>
    [JsonPropertyName("COMPLETED")]
    Completed,

    /// <summary>Job failed</summary>
    [JsonPropertyName("FAILED")]
    Failed,

    /// <summary>Job was cancelled</summary>
    [JsonPropertyName("CANCELLED")]
    Cancelled
}

/// <summary>
/// Compose layout type.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LayoutType
{
    /// <summary>Grid layout</summary>
    [JsonPropertyName("GRID")]
    Grid,

    /// <summary>Horizontal layout</summary>
    [JsonPropertyName("HORIZONTAL")]
    Horizontal,

    /// <summary>Vertical layout</summary>
    [JsonPropertyName("VERTICAL")]
    Vertical,

    /// <summary>Masonry layout</summary>
    [JsonPropertyName("MASONRY")]
    Masonry,

    /// <summary>Mondrian layout</summary>
    [JsonPropertyName("MONDRIAN")]
    Mondrian,

    /// <summary>Partitioning layout</summary>
    [JsonPropertyName("PARTITIONING")]
    Partitioning,

    /// <summary>Auto layout</summary>
    [JsonPropertyName("AUTO")]
    Auto
}

/// <summary>
/// Alignment for compose output.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Alignment
{
    /// <summary>Align to top</summary>
    [JsonPropertyName("top")]
    Top,

    /// <summary>Align to center</summary>
    [JsonPropertyName("center")]
    Center,

    /// <summary>Align to bottom</summary>
    [JsonPropertyName("bottom")]
    Bottom
}
