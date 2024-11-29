using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public interface ITreeListExecutor
{
    void Print(AbsolutePath absolutePath, int depth);
}