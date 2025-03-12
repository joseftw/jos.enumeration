namespace JOS.Enumeration.Database.Tests;

public class JosEnumerationDatabaseOptions : PostgresDatabaseOptions
{
    public override string MigrationsAssembly => "JOS.Enumeration.Database.Tests";
}
