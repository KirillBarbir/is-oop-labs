using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public class FileElement : IElement
{
    public FileElement(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}