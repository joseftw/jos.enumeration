using System.Threading.Tasks;
using Xunit;

namespace JOS.Enumeration.Database.Tests.JOS.Test;

public abstract class DatabaseFixture : IAsyncLifetime
{
    public abstract ValueTask InitializeAsync();

    public abstract ValueTask DisposeAsync();
}
