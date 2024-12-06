using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

public class FileShowCommandFlaggedBuilder : FileShowCommandBuilder, IFlaggedCommandBuilder<FileShowCommandBuilder>
{
    public FileShowCommandBuilder WithFlag(string? flag)
    {
        if (flag is not null) WithOutputMode(flag);
        return this;
    }
}