using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Unit;

public class AllScreenshotsClientBuilderTests
{
    [Fact]
    public void Build_WithApiKey_CreatesClient()
    {
        var client = AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .Build();

        client.Should().NotBeNull();
        client.Screenshots.Should().NotBeNull();
        client.Bulk.Should().NotBeNull();
        client.Compose.Should().NotBeNull();
        client.Schedules.Should().NotBeNull();
        client.Usage.Should().NotBeNull();

        client.Dispose();
    }

    [Fact]
    public void Build_WithCustomTimeout_SetsTimeout()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithTimeout(TimeSpan.FromMinutes(5))
            .Build();

        action.Should().NotThrow();
    }

    [Fact]
    public void Build_WithCustomBaseUrl_SetsBaseUrl()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithBaseUrl("https://custom-api.example.com")
            .Build();

        action.Should().NotThrow();
    }

    [Fact]
    public void Build_WithMaxRetries_SetsMaxRetries()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithMaxRetries(5)
            .Build();

        action.Should().NotThrow();
    }

    [Fact]
    public void Build_WithRetryDelay_SetsRetryDelay()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithRetryDelay(TimeSpan.FromSeconds(2))
            .Build();

        action.Should().NotThrow();
    }

    [Fact]
    public void Build_WithUserAgent_SetsUserAgent()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithUserAgent("custom-agent/1.0")
            .Build();

        action.Should().NotThrow();
    }

    [Fact]
    public void Build_WithoutApiKey_ThrowsArgumentException()
    {
        Environment.SetEnvironmentVariable("ALLSCREENSHOTS_API_KEY", null);

        var action = () => AllScreenshotsClient.CreateBuilder().Build();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*API key is required*");
    }

    [Fact]
    public void Build_WithInvalidBaseUrl_ThrowsArgumentException()
    {
        var action = () => AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithBaseUrl("not-a-url")
            .Build();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*BaseUrl must be a valid absolute URL*");
    }

    [Fact]
    public void Build_ChainedConfiguration_AppliesAll()
    {
        using var client = AllScreenshotsClient.CreateBuilder()
            .WithApiKey("test-api-key")
            .WithBaseUrl("https://custom-api.example.com")
            .WithTimeout(TimeSpan.FromMinutes(3))
            .WithMaxRetries(5)
            .WithRetryDelay(TimeSpan.FromSeconds(2))
            .WithMaxRetryDelay(TimeSpan.FromMinutes(1))
            .WithUserAgent("custom-agent/1.0")
            .Build();

        client.Should().NotBeNull();
    }
}
