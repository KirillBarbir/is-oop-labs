namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;

public class LocalAbsolutePathExecutor : IAbsolutePathExecutor
{
    private string? _path;

    public string? CreateAbsolutePath(string? path = null)
    {
        if (path == null)
        {
            return _path;
        }

        if (_path is null)
        {
            return null;
        }

        return path.StartsWith(_path) ? path : _path + path;
    }

    public void SetPath(string? path)
    {
        _path = path;
    }
}