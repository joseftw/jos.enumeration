using Microsoft.EntityFrameworkCore;

namespace JOS.Enumeration.Database.Tests.JOS.Database;

public abstract class PostgresDatabaseOptions
{
    public abstract string MigrationsAssembly { get; }
    public required string ConnectionString { get; init; }

    public DbContextOptions DbContextOptions
    {
        get
        {
            return DbContextOptionsBuilder.Options;
        }
    }

    public DbContextOptionsBuilder DbContextOptionsBuilder
    {
        get
        {
            var builder = new DbContextOptionsBuilder();
            builder.ConfigureDbContext(this);
            return builder;
        }
    }
}
