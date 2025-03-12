using Xunit;

namespace JOS.Enumeration.Database.Tests;

[CollectionDefinition(Name)]
public class DatabaseTestCollection : ICollectionFixture<JosEnumerationDatabaseFixture>
{
    public const string Name = "Database Test";
}
