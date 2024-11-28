namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommand : ICommand
{
    private readonly AbsolutePath _absolutePath;

    private readonly ModeWrapper _modeWrapper;

    private readonly string _newPath;

    private readonly string _newMode;

    public ConnectCommand(AbsolutePath absolutePath, ModeWrapper modeWrapper, string newPath, string newMode)
    {
        _absolutePath = absolutePath;
        _modeWrapper = modeWrapper;
        _newPath = newPath;
        _newMode = newMode;
    }

    public void Execute()
    {
        _absolutePath.SetPath(_newPath);
        _modeWrapper.SetMode(_newMode);
    }
}