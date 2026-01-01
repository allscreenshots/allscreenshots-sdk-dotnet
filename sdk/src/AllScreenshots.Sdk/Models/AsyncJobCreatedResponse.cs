using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Response when an async job is created.
/// </summary>
public class AsyncJobCreatedResponse
{
    /// <summary>
    /// Unique job identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Current job status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// URL to check job status.
    /// </summary>
    [JsonPropertyName("statusUrl")]
    public string? StatusUrl { get; set; }

    /// <summary>
    /// When the job was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }
}
