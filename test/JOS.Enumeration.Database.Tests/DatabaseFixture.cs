using System.Threading.Tasks;
using Xunit;

namespace JOS.Enumeration.Database.Tests;

public abstract class DatabaseFixture : IAsyncLifetime
{
    public abstract ValueTask InitializeAsync();

    public abstract ValueTask DisposeAsync();
}
