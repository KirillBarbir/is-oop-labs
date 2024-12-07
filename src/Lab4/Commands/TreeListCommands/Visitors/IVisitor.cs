using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

public interface IVisitor
{
    void Visit(FileFilesystemElement fileFilesystemElement);

    void Visit(DirectoryFilesystemElement directoryFilesystemElement);
}