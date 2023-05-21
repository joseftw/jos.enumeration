using System.Collections.Generic;

namespace JOS.Enumeration.Database.Tests;

public class TestConfiguration : Dictionary<string, string>
{
    public TestConfiguration()
    {
        this["ASPNETCORE_ENVIRONMENT"] = "TestRunner";
        this["Postgres:ConnectionString"] =
            "Host=127.0.0.1;Port=5432;Username=ma;Password=ma;Database=jos_enumeration_test";
    }

    public string PostgresConnectionString => this["Postgres:ConnectionString"];
}
