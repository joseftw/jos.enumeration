using Microsoft.EntityFrameworkCore;

namespace JOS.Enumeration.Database.Tests;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder ConfigureDbContext(
        this DbContextOptionsBuilder builder, PostgresDatabaseOptions postgresDatabaseOptions)
    {
        return builder.UseNpgsql(postgresDatabaseOptions.ConnectionString, optionsBuilder =>
        {
            optionsBuilder.MigrationsAssembly(postgresDatabaseOptions.MigrationsAssembly);
        });
    }
}
