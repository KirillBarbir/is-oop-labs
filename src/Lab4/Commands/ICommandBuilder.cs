using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommandBuilder
{
    ICommand? Build();

    ICommandBuilder WithConnectedPath(AbsolutePath path);

    ICommandBuilder WithMode(ModeWrapper mode);
}