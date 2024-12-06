using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

public class ConsoleVisitor : IVisitor
{
    private readonly string _directorySymbol;
    private readonly string _fileSymbol;
    private readonly int _maxDepth;
    private int _depth;

    public ConsoleVisitor(int maxDepth, string directorySymbol, string fileSymbol)
    {
        _maxDepth = maxDepth;
        _directorySymbol = directorySymbol;
        _fileSymbol = fileSymbol;
    }

    public void Visit(FileElement fileElement)
    {
        IndentOutput(_fileSymbol + fileElement.Name);
    }

    public void Visit(DirectoryElement directoryElement)
    {
        IndentOutput(_directorySymbol + directoryElement.Name);
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