using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

public interface IVisitor
{
    void Visit(FileElement fileElement);

    void Visit(DirectoryElement directoryElement);
}