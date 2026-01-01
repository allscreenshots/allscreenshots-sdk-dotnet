using System.Text.Json.Serialization;

namespace AllScreenshots.Sdk.Exceptions;

/// <summary>
/// Base exception for all Allscreenshots SDK errors.
/// </summary>
public class AllScreenshotsException : Exception
{
    /// <summary>
    /// HTTP status code, if applicable.
    /// </summary>
    public int? StatusCode { get; }

    /// <summary>
    /// Error code from the API.
    /// </summary>
    public string? ErrorCode { get; }

    /// <summary>
    /// Creates a new AllScreenshotsException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="statusCode">HTTP status code.</param>
    /// <param name="errorCode">API error code.</param>
    /// <param name="innerException">Inner exception.</param>
    public AllScreenshotsException(
        string message,
        int? statusCode = null,
        string? errorCode = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}

/// <summary>
/// Exception thrown when authentication fails.
/// </summary>
public class AuthenticationException : AllScreenshotsException
{
    /// <summary>
    /// Creates a new AuthenticationException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public AuthenticationException(string message, Exception? innerException = null)
        : base(message, 401, "AUTHENTICATION_FAILED", innerException)
    {
    }
}

/// <summary>
/// Exception thrown when input validation fails.
/// </summary>
public class ValidationException : AllScreenshotsException
{
    /// <summary>
    /// Validation errors.
    /// </summary>
    public IReadOnlyList<ValidationError> Errors { get; }

    /// <summary>
    /// Creates a new ValidationException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="errors">Validation errors.</param>
    public ValidationException(string message, IEnumerable<ValidationError>? errors = null)
        : base(message, 400, "VALIDATION_ERROR")
    {
        Errors = errors?.ToList() ?? new List<ValidationError>();
    }
}

/// <summary>
/// Validation error details.
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Field that failed validation.
    /// </summary>
    public string Field { get; }

    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Creates a new ValidationError.
    /// </summary>
    /// <param name="field">Field name.</param>
    /// <param name="message">Error message.</param>
    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }
}

/// <summary>
/// Exception thrown when a resource is not found.
/// </summary>
public class NotFoundException : AllScreenshotsException
{
    /// <summary>
    /// Resource type.
    /// </summary>
    public string? ResourceType { get; }

    /// <summary>
    /// Resource identifier.
    /// </summary>
    public string? ResourceId { get; }

    /// <summary>
    /// Creates a new NotFoundException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="resourceType">Resource type.</param>
    /// <param name="resourceId">Resource identifier.</param>
    public NotFoundException(string message, string? resourceType = null, string? resourceId = null)
        : base(message, 404, "NOT_FOUND")
    {
        ResourceType = resourceType;
        ResourceId = resourceId;
    }
}

/// <summary>
/// Exception thrown when rate limit is exceeded.
/// </summary>
public class RateLimitException : AllScreenshotsException
{
    /// <summary>
    /// When rate limit resets.
    /// </summary>
    public DateTimeOffset? RetryAfter { get; }

    /// <summary>
    /// Creates a new RateLimitException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="retryAfter">When to retry.</param>
    public RateLimitException(string message, DateTimeOffset? retryAfter = null)
        : base(message, 429, "RATE_LIMIT_EXCEEDED")
    {
        RetryAfter = retryAfter;
    }
}

/// <summary>
/// Exception thrown when quota is exceeded.
/// </summary>
public class QuotaExceededException : AllScreenshotsException
{
    /// <summary>
    /// Creates a new QuotaExceededException.
    /// </summary>
    /// <param name="message">Error message.</param>
    public QuotaExceededException(string message)
        : base(message, 402, "QUOTA_EXCEEDED")
    {
    }
}

/// <summary>
/// Exception thrown on server errors.
/// </summary>
public class ServerException : AllScreenshotsException
{
    /// <summary>
    /// Creates a new ServerException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="statusCode">HTTP status code.</param>
    /// <param name="innerException">Inner exception.</param>
    public ServerException(string message, int statusCode = 500, Exception? innerException = null)
        : base(message, statusCode, "SERVER_ERROR", innerException)
    {
    }
}

/// <summary>
/// Exception thrown on network errors.
/// </summary>
public class NetworkException : AllScreenshotsException
{
    /// <summary>
    /// Creates a new NetworkException.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public NetworkException(string message, Exception? innerException = null)
        : base(message, null, "NETWORK_ERROR", innerException)
    {
    }
}

/// <summary>
/// API error response.
/// </summary>
internal class ApiErrorResponse
{
    /// <summary>
    /// Error code.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Alternative message field.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Validation errors.
    /// </summary>
    [JsonPropertyName("errors")]
    public List<ApiValidationError>? Errors { get; set; }
}

/// <summary>
/// API validation error.
/// </summary>
internal class ApiValidationError
{
    /// <summary>
    /// Field name.
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
