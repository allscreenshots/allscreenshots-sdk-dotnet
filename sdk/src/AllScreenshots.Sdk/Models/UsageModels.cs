using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Usage response.
/// </summary>
public class UsageResponse
{
    /// <summary>
    /// Current tier.
    /// </summary>
    [JsonPropertyName("tier")]
    public string Tier { get; set; } = string.Empty;

    /// <summary>
    /// Current period usage.
    /// </summary>
    [JsonPropertyName("currentPeriod")]
    public PeriodUsageResponse? CurrentPeriod { get; set; }

    /// <summary>
    /// Quota information.
    /// </summary>
    [JsonPropertyName("quota")]
    public QuotaResponse? Quota { get; set; }

    /// <summary>
    /// Usage history.
    /// </summary>
    [JsonPropertyName("history")]
    public List<PeriodUsageResponse>? History { get; set; }

    /// <summary>
    /// Total usage.
    /// </summary>
    [JsonPropertyName("totals")]
    public TotalsResponse? Totals { get; set; }
}

/// <summary>
/// Quota status response.
/// </summary>
public class QuotaStatusResponse
{
    /// <summary>
    /// Current tier.
    /// </summary>
    [JsonPropertyName("tier")]
    public string Tier { get; set; } = string.Empty;

    /// <summary>
    /// Screenshot quota.
    /// </summary>
    [JsonPropertyName("screenshots")]
    public QuotaDetailResponse? Screenshots { get; set; }

    /// <summary>
    /// Bandwidth quota.
    /// </summary>
    [JsonPropertyName("bandwidth")]
    public BandwidthQuotaResponse? Bandwidth { get; set; }

    /// <summary>
    /// When the current period ends.
    /// </summary>
    [JsonPropertyName("periodEnds")]
    public string? PeriodEnds { get; set; }
}

/// <summary>
/// Quota response.
/// </summary>
public class QuotaResponse
{
    /// <summary>
    /// Screenshot limit.
    /// </summary>
    [JsonPropertyName("screenshotsLimit")]
    public int? ScreenshotsLimit { get; set; }

    /// <summary>
    /// Bandwidth limit in bytes.
    /// </summary>
    [JsonPropertyName("bandwidthLimitBytes")]
    public long? BandwidthLimitBytes { get; set; }
}

/// <summary>
/// Quota detail response.
/// </summary>
public class QuotaDetailResponse
{
    /// <summary>
    /// Quota limit.
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    /// <summary>
    /// Amount used.
    /// </summary>
    [JsonPropertyName("used")]
    public int Used { get; set; }

    /// <summary>
    /// Amount remaining.
    /// </summary>
    [JsonPropertyName("remaining")]
    public int Remaining { get; set; }

    /// <summary>
    /// Percentage used.
    /// </summary>
    [JsonPropertyName("percentUsed")]
    public int PercentUsed { get; set; }
}

/// <summary>
/// Bandwidth quota response.
/// </summary>
public class BandwidthQuotaResponse
{
    /// <summary>
    /// Limit in bytes.
    /// </summary>
    [JsonPropertyName("limitBytes")]
    public long LimitBytes { get; set; }

    /// <summary>
    /// Formatted limit.
    /// </summary>
    [JsonPropertyName("limitFormatted")]
    public string? LimitFormatted { get; set; }

    /// <summary>
    /// Used in bytes.
    /// </summary>
    [JsonPropertyName("usedBytes")]
    public long UsedBytes { get; set; }

    /// <summary>
    /// Formatted used.
    /// </summary>
    [JsonPropertyName("usedFormatted")]
    public string? UsedFormatted { get; set; }

    /// <summary>
    /// Remaining in bytes.
    /// </summary>
    [JsonPropertyName("remainingBytes")]
    public long RemainingBytes { get; set; }

    /// <summary>
    /// Formatted remaining.
    /// </summary>
    [JsonPropertyName("remainingFormatted")]
    public string? RemainingFormatted { get; set; }

    /// <summary>
    /// Percentage used.
    /// </summary>
    [JsonPropertyName("percentUsed")]
    public int PercentUsed { get; set; }
}

/// <summary>
/// Period usage response.
/// </summary>
public class PeriodUsageResponse
{
    /// <summary>
    /// Period start.
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// Period end.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

    /// <summary>
    /// Screenshot count.
    /// </summary>
    [JsonPropertyName("screenshotsCount")]
    public int ScreenshotsCount { get; set; }

    /// <summary>
    /// Bandwidth in bytes.
    /// </summary>
    [JsonPropertyName("bandwidthBytes")]
    public long BandwidthBytes { get; set; }

    /// <summary>
    /// Formatted bandwidth.
    /// </summary>
    [JsonPropertyName("bandwidthFormatted")]
    public string? BandwidthFormatted { get; set; }
}

/// <summary>
/// Totals response.
/// </summary>
public class TotalsResponse
{
    /// <summary>
    /// Total screenshots.
    /// </summary>
    [JsonPropertyName("screenshotsCount")]
    public long ScreenshotsCount { get; set; }

    /// <summary>
    /// Total bandwidth in bytes.
    /// </summary>
    [JsonPropertyName("bandwidthBytes")]
    public long BandwidthBytes { get; set; }

    /// <summary>
    /// Formatted total bandwidth.
    /// </summary>
    [JsonPropertyName("bandwidthFormatted")]
    public string? BandwidthFormatted { get; set; }
}
