namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

public interface IAbsolutePathExecutor
{
    string? CreateAbsolutePath(string? path = null);

    void SetPath(string? path);
}