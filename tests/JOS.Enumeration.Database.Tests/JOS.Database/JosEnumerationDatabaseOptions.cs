namespace JOS.Enumeration.Database.Tests.JOS.Database;

public class JosEnumerationDatabaseOptions : PostgresDatabaseOptions
{
    public override string MigrationsAssembly => "JOS.Enumeration.Database.Tests";
}
