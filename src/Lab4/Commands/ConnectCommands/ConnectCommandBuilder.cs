namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommandBuilder : BasicCommandBuilder
{
    private string? _newPath;
    private string? _newMode;

    public override ICommand? Build()
    {
        if (Mode is null || _newPath is null || _newMode is null)
        {
            return null;
        }

        return new ConnectCommand(Filesystems, Mode, _newPath, _newMode);
    }

    public ConnectCommandBuilder WithNewPath(string newPath)
    {
        _newPath = newPath;
        return this;
    }

    public ConnectCommandBuilder WithNewMode(string newMode)
    {
        _newMode = newMode;
        return this;
    }
}