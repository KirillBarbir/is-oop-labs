using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommand : ICommand
{
    private readonly IDictionary<string, IFilesystem>? _filesystems;

    private readonly ModeWrapper _modeWrapper;

    private readonly string _newPath;

    private readonly string _newMode;

    public ConnectCommand(IDictionary<string, IFilesystem>? filesystems, ModeWrapper modeWrapper, string newPath, string newMode)
    {
        _filesystems = filesystems;
        _modeWrapper = modeWrapper;
        _newPath = newPath;
        _newMode = newMode;
    }

    public void Execute()
    {
        _modeWrapper.SetMode(_newMode);
        if (_filesystems is null)
        {
            return;
        }

        _filesystems.TryGetValue(_newMode, out IFilesystem? filesystem);
        filesystem?.SetPath(_newPath);
    }
}