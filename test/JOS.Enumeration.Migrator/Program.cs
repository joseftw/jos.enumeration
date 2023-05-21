using JOS.Enumeration.Migrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, configurationBuilder) =>
    {
        configurationBuilder.AddEnvironmentVariables("JOS_Enumeration_");
        configurationBuilder.AddCommandLine(args);
    });
builder.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = true;
    options.ValidateOnBuild = true;
});

builder.ConfigureServices(services =>
{
    CompositionRoot.ConfigureServices(services);
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
var scope = app.Services.CreateAsyncScope();

await using(scope)
{
    var dbContexts = scope.ServiceProvider.GetServices<DbContext>();

    foreach(var dbContext in dbContexts)
    {
        var dbContextName = dbContext.GetType().Name;
        logger.LogInformation("Migrating {DbContextName}...", dbContextName);
        await dbContext.Database.MigrateAsync();
        logger.LogInformation("Migration of {DbContextName} done", dbContextName);
    }
}

namespace JOS.Enumeration.Migrator
{
    public class Program
    {
        public const string ServiceName = "JOS.Enumeration.Migrator";
    }
}