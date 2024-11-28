namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public record FileDeleteCommand(string Path, IFileDeleteExecutor? Executor) : ICommand // TODO: change to class
{
    // public string Path { get; set; }

    // public IFileDeleteExecutor Executor { get; set; }
    public void Execute()
    {
        if (Executor is null)
        {
            return;
        }

        Executor.DeleteFile(Path);
    }
}