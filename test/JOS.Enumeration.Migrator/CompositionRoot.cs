using Microsoft.Extensions.DependencyInjection;

namespace JOS.Enumeration.Migrator;

public static class CompositionRoot
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddDatabase();

        return services;
    }
}
