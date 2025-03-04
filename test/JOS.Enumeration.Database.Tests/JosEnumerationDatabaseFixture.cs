using JOS.Enumeration.Database.Tests.EntityFramework;
using JOS.Enumeration.Database.Tests.JOS.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JOS.Enumeration.Database.Tests;

public class JosEnumerationDatabaseFixture : PostgresDatabaseFixture
{
    public JosEnumerationDatabaseFixture()
    {
        PostgresDatabaseOptions = new JosEnumerationDatabaseOptions
        {
            ConnectionString = new TestConfiguration().PostgresConnectionString
        };
    }

    public override JosEnumerationDatabaseOptions PostgresDatabaseOptions { get; }
    public override async ValueTask InitializeAsync()
    {
        var enumerationDbContext = new JosEnumerationDbContext(PostgresDatabaseOptions);
        await enumerationDbContext.Database.MigrateAsync();
    }

    public override ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
