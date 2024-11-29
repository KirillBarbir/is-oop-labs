namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;

public class ElementFactory
{
    public IElement? CreateElement(string path)
    {
        if (File.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileElement(name);
        }

        if (Directory.Exists(path))
        {
            string name = Path.GetFileName(path);

            using IEnumerator<string> paths = Directory.EnumerateFileSystemEntries(path).GetEnumerator();
            var elements = new List<IElement?>();
            elements.Add(CreateElement(paths.Current));
            while (paths.MoveNext())
            {
                elements.Add(CreateElement(paths.Current));
            }

            return new DirectoryElement(elements, name);
        }

        return null;
    }
}