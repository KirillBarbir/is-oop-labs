using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.ChainCreators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;
using Xunit;

namespace Lab4.Tests;

public class Lab4Tests
{
    [Fact]
    public void ConnectTest()
    {
        // Arrange
        string[] args = ["connect", "C:", "-m", "local"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        var mode = new ModeWrapper();
        var expectedCommand = new ConnectCommand(supportedFilesystems, mode, "path", "local");
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void DisconnectTest()
    {
        // Arrange
        string[] args = ["disconnect"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new DisconnectCommand(mode);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void TreeGotoTest()
    {
        // Arrange
        string[] args = ["tree", "goto", "C:\\Users"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new TreeGotoCommand("C:\\Users", supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void TreeListTest()
    {
        // Arrange
        string[] args = ["tree", "list", "-d", "3"];
        var creator = new ChainCreator();

        var supportedFilesystems = new Dictionary<string, IFilesystem>();

        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new TreeListCommand(3, supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileShowTest()
    {
        // Arrange
        string[] args = ["file", "show", "C:\\Users", "-m", "console"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileShowCommand("C:\\Users", "console", supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileMoveTest()
    {
        // Arrange
        string[] args = ["file", "move", "C:\\Users", "C:\\Program Files"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileMoveCommand(
            "C:\\Users",
            "C:\\Program Files",
            supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileCopyTest()
    {
        // Arrange
        string[] args = ["file", "copy", "C:\\Users", "C:\\Program Files"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileCopyCommand(
            "C:\\Users",
            "C:\\Program Files",
            supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileDeleteTest()
    {
        // Arrange
        string[] args = ["file", "delete", "C:\\Users"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileDeleteCommand("C:\\Users", supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileRenameTest()
    {
        // Arrange
        string[] args = ["file", "rename", "C:\\Users", "newName"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();

// String is definitely IEquitable
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileRenameCommand("C:\\Users", "newName", supportedFilesystems["local"]);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void InvalidInputTest()
    {
        // Arrange
        string[] args = ["   ", "  ", "   ", "mnjelbkl"];
        var creator = new ChainCreator();
        var supportedFilesystems = new Dictionary<string, IFilesystem>();
        supportedFilesystems.Add("local", new LocalFilesystem());
        supportedFilesystems["local"].SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        FileRenameCommand? expectedCommand = null;
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = creator.CreateChain().HandleCommand(enumerator);
        ICommand? command = builder?.WithFilesystemModes(supportedFilesystems).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }
}