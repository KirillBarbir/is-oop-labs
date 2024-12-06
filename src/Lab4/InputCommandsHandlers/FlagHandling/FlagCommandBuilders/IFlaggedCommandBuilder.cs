using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

public interface IFlaggedCommandBuilder<T> : ICommandBuilder
{
    T WithFlag(string? flag);
}