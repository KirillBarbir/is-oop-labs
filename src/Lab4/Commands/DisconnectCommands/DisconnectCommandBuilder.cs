namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommandBuilder : BasicCommandBuilder
{
    public override ICommand? Build()
    {
        if (AbsolutePath is null || Mode is null)
        {
            return null;
        }

        return new DisconnectCommand(AbsolutePath, Mode);
    }
}