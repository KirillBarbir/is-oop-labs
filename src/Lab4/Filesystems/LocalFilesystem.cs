using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.FileOutputers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

public class LocalFilesystem : IFilesystem
{
#pragma warning disable SK1500
    private readonly Dictionary<string, IFileOutputer> _supportedFileOutputModes =
        new Dictionary<string, IFileOutputer>();

// String is definitely IEquitable
#pragma warning restore SK1500
    private string? _absolutePath;

    public void FileCopy(string? sourcePath, string? destinationPath)
    {
        sourcePath = CreateAbsolutePath(sourcePath);
        destinationPath = CreateAbsolutePath(destinationPath);
        if (sourcePath is null || destinationPath is null)
        {
            return;
        }

        if (!Directory.Exists(destinationPath) || !File.Exists(sourcePath))
        {
            return;
        }

        string[] splitSourcePath = sourcePath.Split('\\');
        if (File.Exists(destinationPath + "\\" + splitSourcePath[^1]))
        {
            return;
        }

        File.Copy(sourcePath, destinationPath + "\\" + splitSourcePath[^1]);
    }

    public void DeleteFile(string? filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        filePath = CreateAbsolutePath(filePath);
        if (filePath is null || !File.Exists(filePath))
        {
            return;
        }

        File.Delete(filePath);
    }

    public void FileMove(string? sourcePath, string? destinationPath)
    {
        sourcePath = CreateAbsolutePath(sourcePath);
        destinationPath = CreateAbsolutePath(destinationPath);
        if (sourcePath is null || destinationPath is null)
        {
            return;
        }

        if (!Directory.Exists(destinationPath) || !File.Exists(sourcePath))
        {
            return;
        }

        string[] splitSourcePath = sourcePath.Split('\\');
        if (File.Exists(destinationPath + "\\" + splitSourcePath[^1]))
        {
            return;
        }

        File.Copy(sourcePath, destinationPath + "\\" + splitSourcePath[^1]);
        File.Delete(sourcePath);
    }

    public void FileRename(string? sourcePath, string name)
    {
        sourcePath = CreateAbsolutePath(sourcePath);
        if (sourcePath is null)
        {
            return;
        }

        if (!File.Exists(sourcePath))
        {
            return;
        }

        string[] splitSourcePath = sourcePath.Split('\\');
        splitSourcePath[^1] = name;
        string newPath = string.Join('\\', splitSourcePath);

        if (File.Exists(newPath))
        {
            return;
        }

        File.Copy(sourcePath, newPath);
        File.Delete(sourcePath);
    }

    public void OutputFile(string? sourcePath, string outputMode)
    {
        sourcePath = CreateAbsolutePath(sourcePath);
        if (sourcePath is null)
        {
            return;
        }

        if (!File.Exists(sourcePath))
        {
            return;
        }

        _supportedFileOutputModes.TryGetValue(outputMode, out IFileOutputer? fileOutputer);
        fileOutputer?.Output(sourcePath);
    }

    public void TreeGoto(string newPath)
    {
        _absolutePath = CreateAbsolutePath(newPath);
    }

    public void TreeList(int depth)
    {
        var factory = new ElementFactory();
        if (_absolutePath is null)
        {
            return;
        }

        IElement? element = factory.CreateElement(_absolutePath);
        var visitor = new ConsoleVisitor(depth);
        element?.Accept(visitor);
    }

    public void SetPath(string newPath)
    {
        _absolutePath = newPath;
    }

    public void AddFileOutputerMode(string mode, IFileOutputer fileOutputer)
    {
        _supportedFileOutputModes.TryAdd(mode, fileOutputer);
    }

    private string? CreateAbsolutePath(string? newPath = null)
    {
        if (newPath is null)
        {
            return _absolutePath;
        }

        if (_absolutePath is null)
        {
            return null;
        }

        return newPath.StartsWith(_absolutePath) ? newPath : _absolutePath + "\\" + newPath;
    }
}