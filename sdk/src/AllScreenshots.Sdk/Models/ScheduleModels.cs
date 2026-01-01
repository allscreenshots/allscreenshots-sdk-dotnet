using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Models;

/// <summary>
/// Request to create a schedule.
/// </summary>
public class CreateScheduleRequest
{
    /// <summary>
    /// Schedule name (max 255 chars).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// URL to capture.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Cron expression for the schedule.
    /// </summary>
    [JsonPropertyName("schedule")]
    public required string Schedule { get; set; }

    /// <summary>
    /// Timezone for the schedule.
    /// </summary>
    [JsonPropertyName("timezone")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Timezone { get; set; }

    /// <summary>
    /// Screenshot options.
    /// </summary>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScheduleScreenshotOptions? Options { get; set; }

    /// <summary>
    /// Webhook URL for notifications.
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
    /// Retention period in days (1-365).
    /// </summary>
    [JsonPropertyName("retentionDays")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RetentionDays { get; set; }

    /// <summary>
    /// When the schedule starts.
    /// </summary>
    [JsonPropertyName("startsAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? StartsAt { get; set; }

    /// <summary>
    /// When the schedule ends.
    /// </summary>
    [JsonPropertyName("endsAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? EndsAt { get; set; }
}

/// <summary>
/// Request to update a schedule.
/// </summary>
public class UpdateScheduleRequest
{
    /// <summary>
    /// Schedule name (max 255 chars).
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    /// URL to capture.
    /// </summary>
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    /// <summary>
    /// Cron expression for the schedule.
    /// </summary>
    [JsonPropertyName("schedule")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Schedule { get; set; }

    /// <summary>
    /// Timezone for the schedule.
    /// </summary>
    [JsonPropertyName("timezone")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Timezone { get; set; }

    /// <summary>
    /// Screenshot options.
    /// </summary>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScheduleScreenshotOptions? Options { get; set; }

    /// <summary>
    /// Webhook URL for notifications.
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
    /// Retention period in days (1-365).
    /// </summary>
    [JsonPropertyName("retentionDays")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RetentionDays { get; set; }

    /// <summary>
    /// When the schedule starts.
    /// </summary>
    [JsonPropertyName("startsAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? StartsAt { get; set; }

    /// <summary>
    /// When the schedule ends.
    /// </summary>
    [JsonPropertyName("endsAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? EndsAt { get; set; }
}

/// <summary>
/// Screenshot options for schedules.
/// </summary>
public class ScheduleScreenshotOptions
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
    /// Image quality (1-100).
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quality { get; set; }

    /// <summary>
    /// Delay before capture (0-30000ms).
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
/// Schedule response.
/// </summary>
public class ScheduleResponse
{
    /// <summary>
    /// Schedule identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Schedule name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// URL to capture.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Cron expression.
    /// </summary>
    [JsonPropertyName("schedule")]
    public string Schedule { get; set; } = string.Empty;

    /// <summary>
    /// Human-readable schedule description.
    /// </summary>
    [JsonPropertyName("scheduleDescription")]
    public string? ScheduleDescription { get; set; }

    /// <summary>
    /// Schedule timezone.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Current status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Screenshot options.
    /// </summary>
    [JsonPropertyName("options")]
    public Dictionary<string, object>? Options { get; set; }

    /// <summary>
    /// Webhook URL.
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    public string? WebhookUrl { get; set; }

    /// <summary>
    /// Retention period in days.
    /// </summary>
    [JsonPropertyName("retentionDays")]
    public int? RetentionDays { get; set; }

    /// <summary>
    /// When the schedule starts.
    /// </summary>
    [JsonPropertyName("startsAt")]
    public DateTimeOffset? StartsAt { get; set; }

    /// <summary>
    /// When the schedule ends.
    /// </summary>
    [JsonPropertyName("endsAt")]
    public DateTimeOffset? EndsAt { get; set; }

    /// <summary>
    /// Last execution time.
    /// </summary>
    [JsonPropertyName("lastExecutedAt")]
    public DateTimeOffset? LastExecutedAt { get; set; }

    /// <summary>
    /// Next scheduled execution.
    /// </summary>
    [JsonPropertyName("nextExecutionAt")]
    public DateTimeOffset? NextExecutionAt { get; set; }

    /// <summary>
    /// Total execution count.
    /// </summary>
    [JsonPropertyName("executionCount")]
    public int ExecutionCount { get; set; }

    /// <summary>
    /// Successful execution count.
    /// </summary>
    [JsonPropertyName("successCount")]
    public int SuccessCount { get; set; }

    /// <summary>
    /// Failed execution count.
    /// </summary>
    [JsonPropertyName("failureCount")]
    public int FailureCount { get; set; }

    /// <summary>
    /// When the schedule was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// When the schedule was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>
/// Schedule list response.
/// </summary>
public class ScheduleListResponse
{
    /// <summary>
    /// List of schedules.
    /// </summary>
    [JsonPropertyName("schedules")]
    public List<ScheduleResponse> Schedules { get; set; } = new();

    /// <summary>
    /// Total count.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

/// <summary>
/// Schedule history response.
/// </summary>
public class ScheduleHistoryResponse
{
    /// <summary>
    /// Schedule identifier.
    /// </summary>
    [JsonPropertyName("scheduleId")]
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>
    /// Total executions.
    /// </summary>
    [JsonPropertyName("totalExecutions")]
    public long TotalExecutions { get; set; }

    /// <summary>
    /// Execution history.
    /// </summary>
    [JsonPropertyName("executions")]
    public List<ScheduleExecutionResponse> Executions { get; set; } = new();
}

/// <summary>
/// Schedule execution response.
/// </summary>
public class ScheduleExecutionResponse
{
    /// <summary>
    /// Execution identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// When the execution occurred.
    /// </summary>
    [JsonPropertyName("executedAt")]
    public DateTimeOffset? ExecutedAt { get; set; }

    /// <summary>
    /// Execution status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Result URL.
    /// </summary>
    [JsonPropertyName("resultUrl")]
    public string? ResultUrl { get; set; }

    /// <summary>
    /// Storage URL.
    /// </summary>
    [JsonPropertyName("storageUrl")]
    public string? StorageUrl { get; set; }

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
    /// When the result expires.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTimeOffset? ExpiresAt { get; set; }
}
