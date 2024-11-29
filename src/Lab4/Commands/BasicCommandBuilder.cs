using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class BasicCommandBuilder : ICommandBuilder
{
    protected AbsolutePath? AbsolutePath { get; private set; }

    protected ModeWrapper? Mode { get; private set; }

    public abstract ICommand? Build();

    public ICommandBuilder WithConnectedPath(AbsolutePath path)
    {
        AbsolutePath = path;
        return this;
    }

    public ICommandBuilder WithMode(ModeWrapper mode)
    {
        Mode = mode;
        return this;
    }
}