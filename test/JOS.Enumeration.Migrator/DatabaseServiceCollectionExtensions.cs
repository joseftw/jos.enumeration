using JOS.Enumeration.Database.Tests;
using JOS.Enumeration.Database.Tests.EntityFramework;
using JOS.Enumeration.Database.Tests.JOS.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JOS.Enumeration.Migrator;

public static class DatabaseServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services.AddValidatedOptions<JosEnumerationDatabaseOptions>("Postgres");
        services.AddScoped<PostgresDatabaseOptions>(x => x.GetRequiredService<JosEnumerationDatabaseOptions>());

        services.AddDbContext<JosEnumerationDbContext>();
        services.AddScoped<DbContext>(x => x.GetRequiredService<JosEnumerationDbContext>());
    }
}
