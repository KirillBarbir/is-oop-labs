namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

public interface IFilesystem
{
    void FileCopy(string? sourcePath, string? destinationPath);

    void DeleteFile(string? filePath);

    void FileMove(string? sourcePath, string? destinationPath);

    void FileRename(string? sourcePath, string name);

    void FileShow(string? sourcePath, string outputMode);

    void TreeGoto(string newPath);

    void TreeList(int depth, string outputMode);

    void SetPath(string newPath);
}