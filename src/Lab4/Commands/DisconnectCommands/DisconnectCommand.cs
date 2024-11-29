namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    private readonly AbsolutePath _absolutePath;

    private readonly ModeWrapper _modeWrapper;

    public DisconnectCommand(AbsolutePath absolutePath, ModeWrapper modeWrapper)
    {
        _absolutePath = absolutePath;
        _modeWrapper = modeWrapper;
    }

    public void Execute()
    {
        _absolutePath.SetPath(null);
        _modeWrapper.SetMode(null);
    }
}