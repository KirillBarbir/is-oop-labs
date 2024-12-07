using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public class DirectoryFilesystemElement : IFilesystemElement
{
    public DirectoryFilesystemElement(Lazy<IReadOnlyCollection<IFilesystemElement?>> elements, string name)
    {
        Elements = elements;
        Name = name;
    }

    public Lazy<IReadOnlyCollection<IFilesystemElement?>> Elements { get; }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}