using System.Net.Http.Headers;
using System.Reflection;
using AllScreenshots.Sdk.Configuration;

namespace AllScreenshots.Sdk.Http;

/// <summary>
/// Factory for creating configured HttpClient instances.
/// </summary>
internal static class HttpClientFactory
{
    private static readonly string SdkVersion = GetSdkVersion();

    /// <summary>
    /// Creates a configured HttpClient for the Allscreenshots API.
    /// </summary>
    /// <param name="options">Client options.</param>
    /// <returns>Configured HttpClient.</returns>
    public static HttpClient Create(AllScreenshotsClientOptions options)
    {
        var retryHandler = new RetryHandler(options)
        {
            InnerHandler = new HttpClientHandler()
        };

        var client = new HttpClient(retryHandler)
        {
            BaseAddress = new Uri(options.BaseUrl.TrimEnd('/') + "/"),
            Timeout = options.Timeout
        };

        // Set default headers
        client.DefaultRequestHeaders.Add("X-API-Key", options.GetEffectiveApiKey());
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var userAgent = options.UserAgent ?? $"allscreenshots-sdk-dotnet/{SdkVersion}";
        client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

        return client;
    }

    private static string GetSdkVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var version = assembly.GetName().Version;
        return version?.ToString(3) ?? "1.0.0";
    }
}
