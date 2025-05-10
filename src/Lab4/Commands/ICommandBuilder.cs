using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommandBuilder
{
    ICommand? Build();

    public ICommandBuilder WithFilesystemModes(IDictionary<string, IFilesystem> filesystems);

    ICommandBuilder WithMode(ModeWrapper mode);
}