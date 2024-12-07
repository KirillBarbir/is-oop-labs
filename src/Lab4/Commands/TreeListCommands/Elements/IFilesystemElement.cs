using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public interface IFilesystemElement
{
    public string Name { get; }

    public void Accept(IVisitor visitor);
}