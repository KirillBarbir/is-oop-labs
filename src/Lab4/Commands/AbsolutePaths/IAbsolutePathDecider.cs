namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

public interface IAbsolutePathDecider
{
    IAbsolutePathExecutor? Decide(string? mode);
}