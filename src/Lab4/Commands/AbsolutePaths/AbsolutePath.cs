namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

public class AbsolutePath
{
    private readonly IAbsolutePathDecider _decider;

    private IAbsolutePathExecutor? _executor;

    public AbsolutePath(IAbsolutePathDecider decider)
    {
        _decider = decider;
    }

    public string? CreateAbsolutePath(string? path = null)
    {
        return _executor?.CreateAbsolutePath(path);
    }

    public void SetPath(string? path)
    {
        _executor?.SetPath(path);
    }

    public void ChangeMode(string? mode)
    {
        _executor = _decider.Decide(mode);
    }
}