namespace Lab5.Presentation.Console.Scenarios.User;

public interface IUserScenario
{
    string Name { get; }

    void Run(long id);
}