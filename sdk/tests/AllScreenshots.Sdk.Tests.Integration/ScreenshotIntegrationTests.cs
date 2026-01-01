using System.Diagnostics;
using AllScreenshots.Sdk.Exceptions;
using AllScreenshots.Sdk.Models;
using FluentAssertions;

namespace AllScreenshots.Sdk.Tests.Integration;

/// <summary>
/// Integration tests for screenshot functionality.
/// These tests require a valid API key in the ALLSCREENSHOTS_API_KEY environment variable.
/// </summary>
public class ScreenshotIntegrationTests : IntegrationTestBase
{
    private readonly List<TestResult> _testResults = new();

    /// <summary>
    /// IT-001: Basic Desktop Screenshot
    /// </summary>
    [Fact]
    public async Task IT001_BasicDesktopScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();
        byte[]? imageBytes = null;

        try
        {
            imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = false
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            // Verify PNG header
            imageBytes.Take(8).Should().ContainInOrder(new byte[] { 0x89, 0x50, 0x4E, 0x47 });

            _testResults.Add(new TestResult
            {
                TestId = "IT-001",
                TestName = "Basic Desktop Screenshot",
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-001",
                TestName = "Basic Desktop Screenshot",
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-002: Basic Mobile Screenshot
    /// </summary>
    [Fact]
    public async Task IT002_BasicMobileScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = false
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            _testResults.Add(new TestResult
            {
                TestId = "IT-002",
                TestName = "Basic Mobile Screenshot",
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-002",
                TestName = "Basic Mobile Screenshot",
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-003: Basic Tablet Screenshot
    /// </summary>
    [Fact]
    public async Task IT003_BasicTabletScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Device = "iPad",
                FullPage = false
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            _testResults.Add(new TestResult
            {
                TestId = "IT-003",
                TestName = "Basic Tablet Screenshot",
                Url = "https://github.com",
                Device = "iPad",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-003",
                TestName = "Basic Tablet Screenshot",
                Url = "https://github.com",
                Device = "iPad",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-004: Full Page Desktop Screenshot
    /// </summary>
    [Fact]
    public async Task IT004_FullPageDesktopScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = true
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            _testResults.Add(new TestResult
            {
                TestId = "IT-004",
                TestName = "Full Page Desktop",
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = true,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-004",
                TestName = "Full Page Desktop",
                Url = "https://github.com",
                Device = "Desktop HD",
                FullPage = true,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-005: Full Page Mobile Screenshot
    /// </summary>
    [Fact]
    public async Task IT005_FullPageMobileScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = true
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            _testResults.Add(new TestResult
            {
                TestId = "IT-005",
                TestName = "Full Page Mobile",
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = true,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-005",
                TestName = "Full Page Mobile",
                Url = "https://github.com",
                Device = "iPhone 14",
                FullPage = true,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-006: Complex Page Screenshot
    /// </summary>
    [Fact]
    public async Task IT006_ComplexPageScreenshot()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var imageBytes = await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://github.com/anthropics/claude-code",
                Device = "Desktop HD",
                FullPage = false
            });

            stopwatch.Stop();

            imageBytes.Should().NotBeEmpty();
            imageBytes.Length.Should().BeGreaterThan(1000);

            _testResults.Add(new TestResult
            {
                TestId = "IT-006",
                TestName = "Complex Page",
                Url = "https://github.com/anthropics/claude-code",
                Device = "Desktop HD",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ImageBytes = imageBytes
            });
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-006",
                TestName = "Complex Page",
                Url = "https://github.com/anthropics/claude-code",
                Device = "Desktop HD",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-007: Invalid URL
    /// </summary>
    [Fact]
    public async Task IT007_InvalidUrl()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var action = async () => await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "not-a-valid-url",
                Device = "Desktop HD",
                FullPage = false
            });

            await action.Should().ThrowAsync<ValidationException>();

            stopwatch.Stop();

            _testResults.Add(new TestResult
            {
                TestId = "IT-007",
                TestName = "Invalid URL",
                Url = "not-a-valid-url",
                Device = "Desktop HD",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds
            });
        }
        catch (Exception ex) when (ex is not ValidationException)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-007",
                TestName = "Invalid URL",
                Url = "not-a-valid-url",
                Device = "Desktop HD",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    /// <summary>
    /// IT-008: Unreachable URL
    /// </summary>
    [Fact]
    public async Task IT008_UnreachableUrl()
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var action = async () => await Client.Screenshots.CaptureAsync(new ScreenshotRequest
            {
                Url = "https://this-domain-does-not-exist-12345.com",
                Device = "Desktop HD",
                FullPage = false
            });

            await action.Should().ThrowAsync<AllScreenshotsException>();

            stopwatch.Stop();

            _testResults.Add(new TestResult
            {
                TestId = "IT-008",
                TestName = "Unreachable URL",
                Url = "https://this-domain-does-not-exist-12345.com",
                Device = "Desktop HD",
                FullPage = false,
                Passed = true,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds
            });
        }
        catch (Exception ex) when (ex is not AllScreenshotsException)
        {
            stopwatch.Stop();
            _testResults.Add(new TestResult
            {
                TestId = "IT-008",
                TestName = "Unreachable URL",
                Url = "https://this-domain-does-not-exist-12345.com",
                Device = "Desktop HD",
                FullPage = false,
                Passed = false,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                ErrorMessage = ex.Message
            });
            throw;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _testResults.Count > 0)
        {
            try
            {
                TestReportGenerator.GenerateReport(_testResults);
            }
            catch
            {
                // Ignore report generation errors
            }
        }

        base.Dispose(disposing);
    }
}

/// <summary>
/// Test result data.
/// </summary>
public class TestResult
{
    public required string TestId { get; init; }
    public required string TestName { get; init; }
    public required string Url { get; init; }
    public required string Device { get; init; }
    public required bool FullPage { get; init; }
    public required bool Passed { get; init; }
    public required long ExecutionTimeMs { get; init; }
    public byte[]? ImageBytes { get; init; }
    public string? ErrorMessage { get; init; }
}
