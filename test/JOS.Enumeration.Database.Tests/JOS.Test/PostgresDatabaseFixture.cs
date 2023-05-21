using System.Threading.Tasks;
using JOS.Enumeration.Database.Tests.JOS.Database;
using Npgsql;
using Respawn;
using Respawn.Graph;

namespace JOS.Enumeration.Database.Tests.JOS.Test;

public abstract class PostgresDatabaseFixture : DatabaseFixture
{
    public abstract PostgresDatabaseOptions PostgresDatabaseOptions { get; }
    protected abstract Table[] TablesToIgnore { get; }
    
    public async Task ResetDatabase()
    {
        await using var npsqlConnection = new NpgsqlConnection(PostgresDatabaseOptions.ConnectionString);
        await npsqlConnection.OpenAsync();
        var respawner = await Respawner.CreateAsync(npsqlConnection,
            new RespawnerOptions
            {
                DbAdapter = DbAdapter.Postgres,
                SchemasToInclude = new[] { "public" },
                TablesToIgnore = TablesToIgnore
            });
        await respawner.ResetAsync(npsqlConnection);
    }
}
