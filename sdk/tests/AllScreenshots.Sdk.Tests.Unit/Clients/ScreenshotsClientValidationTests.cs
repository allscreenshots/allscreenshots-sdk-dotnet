using AllScreenshots.Sdk.Exceptions;
using AllScreenshots.Sdk.Models;
using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Unit.Clients;

public class ScreenshotsClientValidationTests
{
    [Fact]
    public async Task CaptureAsync_WithEmptyUrl_ThrowsValidationException()
    {
        // Create a client with a test API key
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = ""
            });

            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(err => err.Field == "url"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }

    [Fact]
    public async Task CaptureAsync_WithInvalidUrl_ThrowsValidationException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "not-a-valid-url"
            });

            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(err => err.Field == "url" && err.Message.Contains("http")));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }

    [Fact]
    public async Task CaptureAsync_WithInvalidQuality_ThrowsValidationException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Quality = 150
            });

            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(err => err.Field == "quality"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }

    [Fact]
    public async Task CaptureAsync_WithInvalidDelay_ThrowsValidationException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Delay = 50000
            });

            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(err => err.Field == "delay"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }

    [Fact]
    public async Task CaptureAsync_WithInvalidTimeout_ThrowsValidationException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Timeout = 100
            });

            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(err => err.Field == "timeout"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }

    [Fact]
    public async Task GetJobAsync_WithEmptyId_ThrowsValidationException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", "test-key");
        try
        {
            using var client = new AllScreenshotsClient();

            var action = async () => await client.Screenshots.GetJobAsync("");

            await action.Should().ThrowAsync<ValidationException>();
        }
        finally
        {
            Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);
        }
    }
}
