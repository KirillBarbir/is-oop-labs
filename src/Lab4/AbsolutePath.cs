namespace Itmo.ObjectOrientedProgramming.Lab4;

public class AbsolutePath
{
    private string _path;

    public AbsolutePath(string path)
    {
        _path = path;
    }

    public string CreateAbsolutePath(string path)
    {
        return _path.StartsWith(path) ? path : _path + path; // TODO: inspect
    }

    public void SetPath(string path) // TODO: inspect
    {
        _path = CreateAbsolutePath(path);
    }
}