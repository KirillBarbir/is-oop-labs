using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class LocalTreeGotoExecutor : ITreeGotoExecutor
{
    public void TreeGoto(AbsolutePath path, string newPath)
    {
        string? newAbsolutePath = path.CreateAbsolutePath(newPath);
        path.SetPath(newAbsolutePath);
    }
}