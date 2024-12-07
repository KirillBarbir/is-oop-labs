using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Outputers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

public class LocalVisitor : IVisitor
{
    private readonly string _directorySymbol;
    private readonly string _fileSymbol;
    private readonly int _maxDepth;
    private readonly IOutputer _outputer;
    private int _depth;

    public LocalVisitor(int maxDepth, string directorySymbol, string fileSymbol, IOutputer outputer)
    {
        _maxDepth = maxDepth;
        _directorySymbol = directorySymbol;
        _fileSymbol = fileSymbol;
        _outputer = outputer;
    }

    public void Visit(FileFilesystemElement fileFilesystemElement)
    {
        IndentOutput(_fileSymbol + fileFilesystemElement.Name);
    }

    public void Visit(DirectoryFilesystemElement directoryFilesystemElement)
    {
        IndentOutput(_directorySymbol + directoryFilesystemElement.Name);
        if (_depth == _maxDepth)
        {
            return;
        }

        ++_depth;

        foreach (IFilesystemElement? subElement in directoryFilesystemElement.Elements.Value)
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

        _outputer.Output(indent + text);
    }
}