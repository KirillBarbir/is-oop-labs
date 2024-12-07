namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommandBuilder : BasicCommandBuilder
{
    public override ICommand? Build()
    {
        if (Mode is null)
        {
            return null;
        }

        return new DisconnectCommand(Mode);
    }
}