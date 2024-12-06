using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class BasicCommandBuilder : ICommandBuilder
{
    protected IDictionary<string, IFilesystem>? Filesystems { get; private set; }

    protected ModeWrapper? Mode { get; private set; }

    public abstract ICommand? Build();

    public ICommandBuilder WithFilesystemModes(IDictionary<string, IFilesystem> filesystems)
    {
        Filesystems = filesystems;
        return this;
    }

    public ICommandBuilder WithMode(ModeWrapper mode)
    {
        Mode = mode;
        return this;
    }
}