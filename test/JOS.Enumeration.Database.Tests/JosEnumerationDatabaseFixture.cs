using System.Threading.Tasks;
using JOS.Enumeration.Database.Tests.EntityFramework;
using JOS.Enumeration.Database.Tests.JOS.Database;
using JOS.Enumeration.Database.Tests.JOS.Test;
using Microsoft.EntityFrameworkCore;
using Respawn.Graph;

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
    protected override Table[] TablesToIgnore => new[] { new Table("__EFMigrationsHistory") };

    public override async Task InitializeAsync()
    {
        var enumerationDbContext = new JosEnumerationDbContext(PostgresDatabaseOptions);
        await enumerationDbContext.Database.MigrateAsync();
    }

    public override Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}