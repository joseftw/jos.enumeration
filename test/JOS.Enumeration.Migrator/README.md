Create migration:

```
dotnet ef migrations add Initial --project test/JOS.Enumeration.Database.Tests/JOS.Enumeration.Database.Tests.csproj --startup-project test/JOS.Enumeration.Migrator --context JosEnumerationDbContext --output-dir "JOS.Database/Migrations/Postgres"
```
