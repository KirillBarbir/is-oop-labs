namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class BasicCommandBuilder : ICommandBuilder
{
    protected AbsolutePath? AbsolutePath { get; set; }

    protected ModeWrapper? Mode { get; set; }

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