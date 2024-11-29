using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public interface ITreeGotoExecutor
{
    void TreeGoto(AbsolutePath path, string newPath);
}