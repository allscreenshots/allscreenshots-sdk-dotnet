using System.Text.Json;
using AllScreenshots.Sdk.Models;
using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Unit.Models;

public class ScreenshotRequestTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    [Fact]
    public void Serialize_BasicRequest_HasCorrectJson()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com"
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().Contain("\"url\":\"https://github.com\"");
    }

    [Fact]
    public void Serialize_WithDevice_IncludesDevice()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com",
            Device = "Desktop HD"
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().Contain("\"device\":\"Desktop HD\"");
    }

    [Fact]
    public void Serialize_WithFullPage_IncludesFullPage()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com",
            FullPage = true
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().Contain("\"fullPage\":true");
    }

    [Fact]
    public void Serialize_WithViewport_IncludesViewport()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com",
            Viewport = new ViewportConfig
            {
                Width = 1920,
                Height = 1080,
                DeviceScaleFactor = 2
            }
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().Contain("\"viewport\":");
        json.Should().Contain("\"width\":1920");
        json.Should().Contain("\"height\":1080");
        json.Should().Contain("\"deviceScaleFactor\":2");
    }

    [Fact]
    public void Serialize_NullValues_AreExcluded()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com"
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().NotContain("\"device\":");
        json.Should().NotContain("\"fullPage\":");
        json.Should().NotContain("\"viewport\":");
    }

    [Fact]
    public void Serialize_WithHideSelectors_IncludesArray()
    {
        var request = new ScreenshotRequest
        {
            Url = "https://github.com",
            HideSelectors = new List<string> { ".cookie-banner", "#ads" }
        };

        var json = JsonSerializer.Serialize(request, JsonOptions);

        json.Should().Contain("\"hideSelectors\":");
        json.Should().Contain("\".cookie-banner\"");
        json.Should().Contain("\"#ads\"");
    }

    [Fact]
    public void Deserialize_FromJson_CreatesCorrectObject()
    {
        var json = """{"url":"https://github.com","device":"Desktop HD","fullPage":true}""";

        var request = JsonSerializer.Deserialize<ScreenshotRequest>(json, JsonOptions);

        request.Should().NotBeNull();
        request!.Url.Should().Be("https://github.com");
        request.Device.Should().Be("Desktop HD");
        request.FullPage.Should().BeTrue();
    }
}
