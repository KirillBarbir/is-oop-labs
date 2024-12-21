using Lab5.Application.Extensions;
using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

IServiceCollection collection = new ServiceCollection();
collection.AddApplication().AddConsolePresentation().AddInfrastructureDataAccess(configuration =>
{
    configuration.Host = "localhost";
    configuration.Port = 5432;
    configuration.Username = "postgres";
    configuration.Password = "1";
    configuration.Database = "postgres";
    configuration.SslMode = "Prefer";
});
ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

// scope.UseInfrastructureDataAccess();
ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();
while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}
