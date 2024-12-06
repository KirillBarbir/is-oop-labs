namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.TreeListOutputers;

public interface ITreeListOutputer
{
    void Output(int depth, string path, string directorySymbol = "<>", string fileSymbol = "|@");
}