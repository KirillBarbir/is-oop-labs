namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public class FilesystemElementsFactory
{
    public IFilesystemElement? CreateElement(string path)
    {
        if (File.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileFilesystemElement(name);
        }

        if (Directory.Exists(path))
        {
            string name = Path.GetFileName(path);

            using IEnumerator<string> paths = Directory.EnumerateFileSystemEntries(path).GetEnumerator();
            var elements = new List<IFilesystemElement?>();
            while (paths.MoveNext())
            {
                elements.Add(CreateElement(paths.Current));
            }

            var lazy = new Lazy<IReadOnlyCollection<IFilesystemElement?>>(elements);
            return new DirectoryFilesystemElement(lazy, name);
        }

        return null;
    }
}