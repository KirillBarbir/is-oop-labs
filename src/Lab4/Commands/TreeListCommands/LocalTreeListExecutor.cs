using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class LocalTreeListExecutor : ITreeListExecutor
{
    public void Print(AbsolutePath absolutePath, int depth)
    {
        var factory = new ElementFactory();
        string? path = absolutePath.CreateAbsolutePath();
        if (path is null)
        {
            return;
        }

        IElement? element = factory.CreateElement(path);
        var visitor = new ConsoleVisitor(depth);

        element?.Accept(visitor);
    }
}