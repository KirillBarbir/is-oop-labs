using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.TreeListOutputers;

public class ConsoleTreeListOutputer : ITreeListOutputer
{
    public void Output(int depth, string path, string directorySymbol = "<>", string fileSymbol = "|@")
    {
        var factory = new ElementFactory();
        IElement? element = factory.CreateElement(path);
        var visitor = new ConsoleVisitor(depth, directorySymbol, fileSymbol);
        element?.Accept(visitor);
    }
}