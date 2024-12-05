namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    private readonly ModeWrapper _modeWrapper;

    public DisconnectCommand(ModeWrapper modeWrapper)
    {
        _modeWrapper = modeWrapper;
    }

    public void Execute()
    {
        _modeWrapper.SetMode(null);
    }
}