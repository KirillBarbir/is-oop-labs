using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User.UserScenarios;

public class ShowAccountHistoryScenario : IUserScenario
{
    private readonly IShowAccountHistoryService _service;

    public ShowAccountHistoryScenario(IShowAccountHistoryService service)
    {
        _service = service;
    }

    public string Name => "Show operation history";

    public void Run(long id)
    {
        IEnumerable<Operation> operations = _service.ShowHistory(id);
        var table = new Table();
        table.AddColumn("Amount");
        table.AddColumn("Operation type");
        foreach (Operation operation in operations)
        {
            table.AddRow(operation.Amount.ToString(), operation.OperationType.ToString());
        }

        AnsiConsole.Write(table);

        AnsiConsole.Ask<string>("Enter anything to proceed...");
    }
}