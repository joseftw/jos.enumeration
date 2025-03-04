namespace JOS.Enumeration.Database.Tests;

public abstract class PostgresDatabaseFixture : DatabaseFixture
{
    public abstract PostgresDatabaseOptions PostgresDatabaseOptions { get; }
}
