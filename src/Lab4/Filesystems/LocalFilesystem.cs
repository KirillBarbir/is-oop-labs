using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands.TreeListOutputers;
using Itmo.ObjectOrientedProgramming.Lab4.FileOutputers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

public class LocalFilesystem : IFilesystem
{
    private readonly Dictionary<string, IFileOutputer> _supportedFileOutputModes = new();

    private readonly Dictionary<string, ITreeListOutputer> _supportedTreeListModes = new();

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

        File.Move(sourcePath, newPath);
    }

    public void FileShow(string? sourcePath, string outputMode)
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

    public void TreeList(int depth, string outputMode)
    {
        if (_absolutePath is null)
        {
            return;
        }

        _supportedTreeListModes.TryGetValue(outputMode, out ITreeListOutputer? outputer);
        outputer?.Output(depth, _absolutePath);
    }

    public void SetPath(string newPath)
    {
        _absolutePath = newPath;
    }

    public void AddFileOutputerMode(string mode, IFileOutputer fileOutputer)
    {
        _supportedFileOutputModes.TryAdd(mode, fileOutputer);
    }

    public void AddTreeListMode(string mode, ITreeListOutputer outputer)
    {
        _supportedTreeListModes.TryAdd(mode, outputer);
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