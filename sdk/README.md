# Allscreenshots .NET SDK

Official .NET SDK for the [Allscreenshots API](https://allscreenshots.com) - capture screenshots programmatically.

## Installation

### NuGet Package Manager

```bash
dotnet add package AllScreenshots.Sdk
```

### Package Manager Console

```powershell
Install-Package AllScreenshots.Sdk
```

## Quick start

```csharp
using AllScreenshots.Sdk;
using AllScreenshots.Sdk.Models;

// Create client (reads API key from ALLSCREENSHOTS_API_KEY environment variable)
using var client = new AllScreenshotsClient();

// Take a screenshot
var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
{
    Url = "https://github.com",
    Device = "Desktop HD"
});

// Save to file
File.WriteAllBytes("screenshot.png", imageBytes);
```

## Configuration

### Using environment variable (recommended)

Set the `ALLSCREENSHOTS_API_KEY` environment variable:

```bash
export ALLSCREENSHOTS_API_KEY=your-api-key
```

```csharp
using var client = new AllScreenshotsClient();
```

### Using explicit API key

```csharp
using var client = new AllScreenshotsClient(options =>
{
    options.ApiKey = "your-api-key";
});
```

### Using builder pattern

```csharp
using var client = AllScreenshotsClient.CreateBuilder()
    .WithApiKey("your-api-key")
    .WithTimeout(TimeSpan.FromMinutes(5))
    .WithMaxRetries(5)
    .Build();
```

### Configuration options

| Option | Default | Description |
|--------|---------|-------------|
| `ApiKey` | `ALLSCREENSHOTS_API_KEY` env var | API key for authentication |
| `BaseUrl` | `https://api.allscreenshots.com` | API base URL |
| `Timeout` | 120 seconds | Request timeout |
| `MaxRetries` | 3 | Maximum retry attempts for transient failures |
| `RetryDelay` | 1 second | Initial delay between retries |
| `MaxRetryDelay` | 30 seconds | Maximum delay between retries |

### Dependency injection

```csharp
services.AddAllScreenshots(options =>
{
    options.ApiKey = configuration["AllScreenshots:ApiKey"];
});
```

## API reference

### Screenshots

#### Capture (synchronous)

```csharp
var imageBytes = await client.Screenshots.CaptureAsync(new ScreenshotRequest
{
    Url = "https://github.com",
    Device = "Desktop HD",
    FullPage = true,
    Format = "png",
    Quality = 90
});
```

#### Capture (asynchronous)

```csharp
var job = await client.Screenshots.CaptureAsyncAsync(new ScreenshotRequest
{
    Url = "https://github.com",
    Device = "Desktop HD"
});

Console.WriteLine($"Job ID: {job.Id}");

// Poll for completion
JobResponse status;
do
{
    await Task.Delay(1000);
    status = await client.Screenshots.GetJobAsync(job.Id);
} while (status.Status == "PROCESSING" || status.Status == "QUEUED");

// Get result
var imageBytes = await client.Screenshots.GetJobResultAsync(job.Id);
```

#### Screenshot options

| Option | Type | Description |
|--------|------|-------------|
| `Url` | string | URL to capture (required) |
| `Device` | string | Device preset (e.g., "Desktop HD", "iPhone 14", "iPad") |
| `Viewport` | ViewportConfig | Custom viewport dimensions |
| `FullPage` | bool | Capture entire page |
| `Format` | string | Output format: "png", "jpeg", "webp", "pdf" |
| `Quality` | int | Image quality (1-100) |
| `Delay` | int | Delay before capture (0-30000ms) |
| `WaitFor` | string | CSS selector to wait for |
| `WaitUntil` | string | Wait condition: "load", "domcontentloaded", "networkidle" |
| `Timeout` | int | Timeout (1000-60000ms) |
| `DarkMode` | bool | Enable dark mode |
| `CustomCss` | string | CSS to inject |
| `HideSelectors` | List\<string\> | Selectors to hide |
| `BlockAds` | bool | Block advertisements |
| `BlockCookieBanners` | bool | Block cookie consent banners |

### Bulk screenshots

```csharp
var bulk = await client.Bulk.CreateAsync(new BulkRequest
{
    Urls = new List<BulkUrlRequest>
    {
        new() { Url = "https://github.com" },
        new() { Url = "https://google.com" },
        new() { Url = "https://microsoft.com" }
    },
    Defaults = new BulkDefaults
    {
        Device = "Desktop HD",
        FullPage = false
    }
});

Console.WriteLine($"Bulk job ID: {bulk.Id}");

// Get status
var status = await client.Bulk.GetAsync(bulk.Id);
Console.WriteLine($"Progress: {status.Progress}%");
```

### Compose (multi-screenshot layouts)

```csharp
var result = await client.Compose.CreateAsync(new ComposeRequest
{
    Captures = new List<CaptureItem>
    {
        new() { Url = "https://github.com", Device = "Desktop HD", Label = "Desktop" },
        new() { Url = "https://github.com", Device = "iPhone 14", Label = "Mobile" }
    },
    Output = new ComposeOutputConfig
    {
        Layout = "HORIZONTAL",
        Spacing = 20,
        Background = "#ffffff"
    }
});

Console.WriteLine($"Composed image URL: {result.Result?.Url}");
```

### Schedules

```csharp
// Create a schedule
var schedule = await client.Schedules.CreateAsync(new CreateScheduleRequest
{
    Name = "Daily screenshot",
    Url = "https://github.com",
    Schedule = "0 9 * * *", // Daily at 9 AM
    Timezone = "America/New_York",
    Options = new ScheduleScreenshotOptions
    {
        Device = "Desktop HD"
    }
});

// List schedules
var schedules = await client.Schedules.ListAsync();

// Pause/resume
await client.Schedules.PauseAsync(schedule.Id);
await client.Schedules.ResumeAsync(schedule.Id);

// Trigger manually
await client.Schedules.TriggerAsync(schedule.Id);

// Get history
var history = await client.Schedules.GetHistoryAsync(schedule.Id, limit: 10);
```

### Usage and quota

```csharp
// Get usage statistics
var usage = await client.Usage.GetUsageAsync();
Console.WriteLine($"Current period: {usage.CurrentPeriod?.ScreenshotsCount} screenshots");

// Get quota status
var quota = await client.Usage.GetQuotaAsync();
Console.WriteLine($"Remaining: {quota.Screenshots?.Remaining} screenshots");
```

## Error handling

The SDK throws typed exceptions for different error conditions:

```csharp
try
{
    var imageBytes = await client.Screenshots.CaptureAsync(request);
}
catch (ValidationException ex)
{
    // Invalid request parameters
    foreach (var error in ex.Errors)
    {
        Console.WriteLine($"{error.Field}: {error.Message}");
    }
}
catch (AuthenticationException)
{
    // Invalid or missing API key
}
catch (RateLimitException ex)
{
    // Rate limit exceeded
    Console.WriteLine($"Retry after: {ex.RetryAfter}");
}
catch (QuotaExceededException)
{
    // Monthly quota exceeded
}
catch (NotFoundException)
{
    // Resource not found
}
catch (ServerException)
{
    // Server-side error
}
catch (NetworkException)
{
    // Network connectivity error
}
catch (AllScreenshotsException ex)
{
    // Other API errors
    Console.WriteLine($"Error: {ex.Message}, Code: {ex.ErrorCode}");
}
```

## Retry logic

The SDK automatically retries transient failures with exponential backoff:

- Connection errors
- Timeouts
- 5xx server errors
- 429 rate limit errors (respects Retry-After header)

Configure retry behavior:

```csharp
using var client = AllScreenshotsClient.CreateBuilder()
    .WithApiKey("your-api-key")
    .WithMaxRetries(5)
    .WithRetryDelay(TimeSpan.FromSeconds(2))
    .WithMaxRetryDelay(TimeSpan.FromMinutes(1))
    .Build();
```

## Requirements

- .NET 8.0 or later

## License

Apache License 2.0. See [LICENSE](LICENSE) for details.
