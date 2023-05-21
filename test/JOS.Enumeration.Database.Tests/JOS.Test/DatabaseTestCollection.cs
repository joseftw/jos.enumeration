using Xunit;

namespace JOS.Enumeration.Database.Tests.JOS.Test;

[CollectionDefinition(Name)]
public class DatabaseTestCollection : ICollectionFixture<JosEnumerationDatabaseFixture>
{
    public const string Name = "Database Test";
}
