namespace AllScreenshots.Sdk.Tests.Integration;

/// <summary>
/// Base class for integration tests.
/// </summary>
public abstract class IntegrationTestBase : IDisposable
{
    protected readonly AllScreenshotsClient Client;
    private bool _disposed;

    protected IntegrationTestBase()
    {
        var apiKey = Environment.GetEnvironmentVariable("ALLSCREENSHOTS_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException(
                "ALLSCREENSHOTS_API_KEY environment variable is not set. " +
                "Set this environment variable to run integration tests.");
        }

        Client = AllScreenshotsClient.CreateBuilder()
            .WithApiKey(apiKey)
            .WithTimeout(TimeSpan.FromMinutes(2))
            .Build();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            Client.Dispose();
        }

        _disposed = true;
    }
}
