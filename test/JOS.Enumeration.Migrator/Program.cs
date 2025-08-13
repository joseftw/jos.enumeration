using JOS.Enumeration.Migrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.CommandLine;

var builder =
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((_, configurationBuilder) =>
        {
            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddJsonFile("appsettings.Development.json", optional: true);
            configurationBuilder.AddEnvironmentVariables();
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
var rootCommand = new RootCommand("JOS.Enumeration.Migrator");
rootCommand.SetAction(async (parseResult, token)=>
{
    await using var scope = app.Services.CreateAsyncScope();
    var dbContexts = scope.ServiceProvider.GetServices<DbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    foreach(var dbContext in dbContexts)
    {
        var dbContextName = dbContext.GetType().Name;
        logger.LogInformation("Migrating {DbContextName}...", dbContextName);
        await dbContext.Database.MigrateAsync();
        logger.LogInformation("Migration of {DbContextName} done", dbContextName);
    }
});

return await rootCommand.Parse(args).InvokeAsync();
