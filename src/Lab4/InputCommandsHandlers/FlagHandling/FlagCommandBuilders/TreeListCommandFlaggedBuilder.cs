using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

public class TreeListCommandFlaggedBuilder : TreeListCommandBuilder, IFlaggedCommandBuilder<TreeListCommandBuilder>
{
    public TreeListCommandBuilder WithFlag(string? flag)
    {
        if (flag is not null) WithDepth(int.Parse(flag));
        return this;
    }
}