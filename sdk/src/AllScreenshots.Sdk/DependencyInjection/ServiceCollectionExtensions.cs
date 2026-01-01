using AllScreenshots.Sdk.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllScreenshots.Sdk.DependencyInjection;

/// <summary>
/// Extension methods for adding AllScreenshots services to the DI container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the AllScreenshots client to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>The service collection.</returns>
    /// <example>
    /// <code>
    /// services.AddAllScreenshots();
    /// </code>
    /// </example>
    public static IServiceCollection AddAllScreenshots(this IServiceCollection services)
    {
        return services.AddAllScreenshots(_ => { });
    }

    /// <summary>
    /// Adds the AllScreenshots client to the service collection with configuration.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configure">Configuration action.</param>
    /// <returns>The service collection.</returns>
    /// <example>
    /// <code>
    /// services.AddAllScreenshots(options =>
    /// {
    ///     options.ApiKey = "your-api-key";
    ///     options.Timeout = TimeSpan.FromMinutes(5);
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddAllScreenshots(
        this IServiceCollection services,
        Action<AllScreenshotsClientOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configure);

        services.AddSingleton(sp =>
        {
            var options = new AllScreenshotsClientOptions();
            configure(options);
            return new AllScreenshotsClient(options);
        });

        return services;
    }
}
