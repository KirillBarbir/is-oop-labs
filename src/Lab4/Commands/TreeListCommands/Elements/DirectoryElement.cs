using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public class DirectoryElement : IElement
{
    public DirectoryElement(IReadOnlyCollection<IElement?> elements, string name)
    {
        Elements = elements;
        Name = name;
    }

    public IReadOnlyCollection<IElement?> Elements { get; }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}