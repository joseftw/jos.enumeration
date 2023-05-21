using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace JOS.Enumeration.Database.Tests;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidatedOptions<T>(
        this IServiceCollection services, string key) where T : class
    {
        return AddValidatedOptions<T>(services, key, RequiredConfigurationValidator.Validate);
    }

    public static IServiceCollection AddValidatedOptions<T>(
        this IServiceCollection services, string key, Func<T, bool> validator) where T : class
    {
        services.AddOptions<T>()
                .BindConfiguration(key)
                .Validate(validator);

        return services.AddSingleton<T>(x => x.GetRequiredService<IOptions<T>>().Value);
    }
}
