using Lab5.Application.Extensions;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

IServiceCollection x = new ServiceCollection();
x.AddApplication().AddConsolePresentation();
ServiceProvider provider = x.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

// scope.UseInfrastructureDataAccess();
ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();
while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}
