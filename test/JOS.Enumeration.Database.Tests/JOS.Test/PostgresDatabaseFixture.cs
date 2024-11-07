using JOS.Enumeration.Database.Tests.JOS.Database;

namespace JOS.Enumeration.Database.Tests.JOS.Test;

public abstract class PostgresDatabaseFixture : DatabaseFixture
{
    public abstract PostgresDatabaseOptions PostgresDatabaseOptions { get; }
}
