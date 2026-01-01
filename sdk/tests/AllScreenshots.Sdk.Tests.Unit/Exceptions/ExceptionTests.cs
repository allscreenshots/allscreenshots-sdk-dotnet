using AllScreenshots.Sdk.Exceptions;
using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Unit.Exceptions;

public class ExceptionTests
{
    [Fact]
    public void AllScreenshotsException_SetsProperties()
    {
        var exception = new AllScreenshotsException("Test message", 400, "TEST_ERROR");

        exception.Message.Should().Be("Test message");
        exception.StatusCode.Should().Be(400);
        exception.ErrorCode.Should().Be("TEST_ERROR");
    }

    [Fact]
    public void AllScreenshotsException_WithInnerException_PreservesIt()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new AllScreenshotsException("Test", innerException: inner);

        exception.InnerException.Should().BeSameAs(inner);
    }

    [Fact]
    public void AuthenticationException_HasCorrectProperties()
    {
        var exception = new AuthenticationException("Unauthorized");

        exception.StatusCode.Should().Be(401);
        exception.ErrorCode.Should().Be("AUTHENTICATION_FAILED");
    }

    [Fact]
    public void ValidationException_ContainsErrors()
    {
        var errors = new List<ValidationError>
        {
            new("url", "URL is required"),
            new("device", "Invalid device")
        };

        var exception = new ValidationException("Validation failed", errors);

        exception.StatusCode.Should().Be(400);
        exception.ErrorCode.Should().Be("VALIDATION_ERROR");
        exception.Errors.Should().HaveCount(2);
        exception.Errors[0].Field.Should().Be("url");
        exception.Errors[0].Message.Should().Be("URL is required");
    }

    [Fact]
    public void NotFoundException_HasCorrectProperties()
    {
        var exception = new NotFoundException("Job not found", "Job", "123");

        exception.StatusCode.Should().Be(404);
        exception.ErrorCode.Should().Be("NOT_FOUND");
        exception.ResourceType.Should().Be("Job");
        exception.ResourceId.Should().Be("123");
    }

    [Fact]
    public void RateLimitException_HasRetryAfter()
    {
        var retryAfter = DateTimeOffset.UtcNow.AddMinutes(5);
        var exception = new RateLimitException("Rate limit exceeded", retryAfter);

        exception.StatusCode.Should().Be(429);
        exception.ErrorCode.Should().Be("RATE_LIMIT_EXCEEDED");
        exception.RetryAfter.Should().Be(retryAfter);
    }

    [Fact]
    public void QuotaExceededException_HasCorrectProperties()
    {
        var exception = new QuotaExceededException("Quota exceeded");

        exception.StatusCode.Should().Be(402);
        exception.ErrorCode.Should().Be("QUOTA_EXCEEDED");
    }

    [Fact]
    public void ServerException_HasCorrectProperties()
    {
        var exception = new ServerException("Internal server error", 503);

        exception.StatusCode.Should().Be(503);
        exception.ErrorCode.Should().Be("SERVER_ERROR");
    }

    [Fact]
    public void NetworkException_HasNoStatusCode()
    {
        var exception = new NetworkException("Connection failed");

        exception.StatusCode.Should().BeNull();
        exception.ErrorCode.Should().Be("NETWORK_ERROR");
    }
}
