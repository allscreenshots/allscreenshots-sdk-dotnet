# Allscreenshots .NET SDK integration guide

You are integrating with the Allscreenshots API using the official .NET SDK. Use this guide to help developers capture screenshots programmatically.

## Installation

```bash
dotnet add package AllScreenshots.Sdk
```

## Basic usage

```csharp
using AllScreenshots.Sdk;
using AllScreenshots.Sdk.Models;

// Create client (API key from ALLSCREENSHOTS_API_KEY environment variable)
using var client = new AllScreenshotsClient();

// Or with explicit API key
using var client = new AllScreenshotsClient(options =>
{
    options.ApiKey = "your-api-key";
});

// Capture a screenshot
var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
{
    Url = "https://example.com",
    Device = "Desktop HD",
    FullPage = false
});

File.WriteAllBytes("screenshot.png", imageBytes);
```

## Device presets

Common device presets: `"Desktop HD"`, `"iPhone 14"`, `"iPad"`, `"Pixel 7"`

## Key features

### Synchronous screenshot

```csharp
var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
{
    Url = "https://example.com",
    Device = "Desktop HD"
});
```

### Asynchronous screenshot (for long-running captures)

```csharp
var job = await client.Screenshots.CaptureAsyncAsync(request);
// Poll job.Id until status is COMPLETED
var result = await client.Screenshots.GetJobResultAsync(job.Id);
```

### Bulk screenshots

```csharp
var bulk = await client.Bulk.CreateAsync(new BulkRequest
{
    Urls = urls.Select(u => new BulkUrlRequest { Url = u }).ToList(),
    Defaults = new BulkDefaults { Device = "Desktop HD" }
});
```

### Compose multiple screenshots

```csharp
var result = await client.Compose.CreateAsync(new ComposeRequest
{
    Captures = new List<CaptureItem>
    {
        new() { Url = "https://example.com", Device = "Desktop HD" },
        new() { Url = "https://example.com", Device = "iPhone 14" }
    },
    Output = new ComposeOutputConfig { Layout = "HORIZONTAL" }
});
```

## Error handling

```csharp
try
{
    await client.Screenshots.CaptureAsync(request);
}
catch (ValidationException ex)
{
    // Invalid request
}
catch (AuthenticationException)
{
    // Invalid API key
}
catch (RateLimitException ex)
{
    // Wait until ex.RetryAfter
}
catch (QuotaExceededException)
{
    // Quota exceeded
}
```

## Common options

- `Url` (required): URL to capture
- `Device`: Device preset name
- `FullPage`: Capture entire page (bool)
- `Format`: "png", "jpeg", "webp", "pdf"
- `Quality`: 1-100
- `DarkMode`: Enable dark mode
- `Delay`: Wait before capture (ms)
- `WaitFor`: CSS selector to wait for
- `BlockAds`, `BlockCookieBanners`: Block common overlays

## Best practices

1. Use environment variable for API key
2. Dispose client when done (`using var client = ...`)
3. Handle specific exceptions for better UX
4. Use async screenshots for complex pages
5. Use bulk API for multiple URLs
