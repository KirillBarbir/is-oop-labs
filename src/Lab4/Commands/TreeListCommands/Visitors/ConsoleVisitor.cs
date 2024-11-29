using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

public class ConsoleVisitor : IVisitor
{
    private readonly int _maxDepth;
    private int _depth;

    public ConsoleVisitor(int maxDepth)
    {
        _maxDepth = maxDepth;
    }

    public void Visit(FileElement fileElement)
    {
        IndentOutput("@|" + fileElement.Name);
    }

    public void Visit(DirectoryElement directoryElement)
    {
        IndentOutput("<>" + directoryElement.Name);
        if (_depth == _maxDepth)
        {
            return;
        }

        ++_depth;

        foreach (IElement? subElement in directoryElement.Elements)
        {
            if (subElement is null)
            {
                continue;
            }

            subElement.Accept(this);
        }

        --_depth;
    }

    private void IndentOutput(string text)
    {
        string indent = string.Empty;
        for (int i = 0; i < _depth; i++)
        {
            indent += "__";
        }

        Console.WriteLine(indent + text);
    }
}