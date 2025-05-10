using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

public class ConnectCommandFlaggedBuilder : ConnectCommandBuilder, IFlaggedCommandBuilder<ConnectCommandBuilder>
{
    public ConnectCommandBuilder WithFlag(string? flag)
    {
        if (flag is not null) WithNewMode(flag);
        return this;
    }
}