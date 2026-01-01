using AllScreenshots.Sdk.Configuration;
using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Unit.Configuration;

public class AllScreenshotsClientOptionsTests
{
    [Fact]
    public void Validate_WithApiKey_DoesNotThrow()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "test-api-key"
        };

        var action = () => options.Validate();

        action.Should().NotThrow();
    }

    [Fact]
    public void Validate_WithEnvironmentVariable_DoesNotThrow()
    {
        Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, "env-api-key");
        try
        {
            var options = new AllScreenshotsClientOptions();

            var action = () => options.Validate();

            action.Should().NotThrow();
        }
        finally
        {
            Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, null);
        }
    }

    [Fact]
    public void Validate_WithoutApiKey_ThrowsArgumentException()
    {
        Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, null);

        var options = new AllScreenshotsClientOptions();

        var action = () => options.Validate();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*API key is required*");
    }

    [Fact]
    public void Validate_WithEmptyBaseUrl_ThrowsArgumentException()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "test-api-key",
            BaseUrl = ""
        };

        var action = () => options.Validate();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*BaseUrl cannot be empty*");
    }

    [Fact]
    public void Validate_WithInvalidBaseUrl_ThrowsArgumentException()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "test-api-key",
            BaseUrl = "not-a-url"
        };

        var action = () => options.Validate();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*BaseUrl must be a valid absolute URL*");
    }

    [Fact]
    public void Validate_WithZeroTimeout_ThrowsArgumentException()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "test-api-key",
            Timeout = TimeSpan.Zero
        };

        var action = () => options.Validate();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*Timeout must be positive*");
    }

    [Fact]
    public void Validate_WithNegativeMaxRetries_ThrowsArgumentException()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "test-api-key",
            MaxRetries = -1
        };

        var action = () => options.Validate();

        action.Should().Throw<ArgumentException>()
            .WithMessage("*MaxRetries cannot be negative*");
    }

    [Fact]
    public void GetEffectiveApiKey_WithApiKey_ReturnsApiKey()
    {
        var options = new AllScreenshotsClientOptions
        {
            ApiKey = "explicit-api-key"
        };

        var result = options.GetEffectiveApiKey();

        result.Should().Be("explicit-api-key");
    }

    [Fact]
    public void GetEffectiveApiKey_WithEnvironmentVariable_ReturnsEnvVar()
    {
        Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, "env-api-key");
        try
        {
            var options = new AllScreenshotsClientOptions();

            var result = options.GetEffectiveApiKey();

            result.Should().Be("env-api-key");
        }
        finally
        {
            Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, null);
        }
    }

    [Fact]
    public void GetEffectiveApiKey_WithBoth_PrefersExplicitApiKey()
    {
        Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, "env-api-key");
        try
        {
            var options = new AllScreenshotsClientOptions
            {
                ApiKey = "explicit-api-key"
            };

            var result = options.GetEffectiveApiKey();

            result.Should().Be("explicit-api-key");
        }
        finally
        {
            Environment.SetEnvironmentVariable(AllScreenshotsClientOptions.ApiKeyEnvironmentVariable, null);
        }
    }

    [Fact]
    public void DefaultValues_AreCorrect()
    {
        var options = new AllScreenshotsClientOptions();

        options.BaseUrl.Should().Be("https://api.allscreenshots.com");
        options.Timeout.Should().Be(TimeSpan.FromSeconds(120));
        options.MaxRetries.Should().Be(3);
        options.RetryDelay.Should().Be(TimeSpan.FromSeconds(1));
        options.MaxRetryDelay.Should().Be(TimeSpan.FromSeconds(30));
    }
}
