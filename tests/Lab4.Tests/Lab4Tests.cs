using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.AbsolutePaths;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FileInputCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;
using Xunit;

namespace Lab4.Tests;

public class Lab4Tests
{
    [Fact]
    public void ConnectTest()
    {
        // Arrange
        var handler = new ConnectInputCommandHandler();
        string[] args = ["connect", "C:", "-m", "local"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        var mode = new ModeWrapper();
        var expectedCommand = new ConnectCommand(absolutePath, mode, "path", "local");
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void DisconnectTest()
    {
        // Arrange
        var handler = new DisconnectInputCommandHandler();
        string[] args = ["disconnect"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new DisconnectCommand(absolutePath, mode);
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void TreeGotoTest()
    {
        // Arrange
        var decider = new TreeGotoExecutorDecider();
        var innerHandler = new TreeGotoInputCommandHandler(decider);
        var handler = new TreeInputCommandsHandler(innerHandler);
        string[] args = ["tree", "goto", "C:\\Users"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new TreeGotoCommand(absolutePath, "C:\\Users", new LocalTreeGotoExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void TreeListTest()
    {
        // Arrange
        var decider = new TreeListExecutorDecider();
        var innerHandler = new TreeListInputCommandHandler(decider);
        var handler = new TreeInputCommandsHandler(innerHandler);
        string[] args = ["tree", "list", "-d", "3"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new TreeListCommand(absolutePath, 3, new LocalTreeListExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileShowTest()
    {
        // Arrange
        var decider = new FileShowExecutorDecider();
        var innerHandler = new FileShowInputCommandHandler(decider);
        var handler = new FileInputCommandsHandler(innerHandler);
        string[] args = ["file", "show", "C:\\Users", "-m", "console"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileShowCommand("C:\\Users", "console", new LocalFileShowExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileMoveTest()
    {
        // Arrange
        var decider = new FileMoveExecutorDecider();
        var innerHandler = new FileMoveInputCommandHandler(decider);
        var handler = new FileInputCommandsHandler(innerHandler);
        string[] args = ["file", "move", "C:\\Users", "C:\\Program Files"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileMoveCommand("C:\\Users", "C:\\Program Files", new LocalFileMoveExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileCopyTest()
    {
        // Arrange
        var decider = new FileCopyExecutorDecider();
        var innerHandler = new FileCopyInputCommandHandler(decider);
        var handler = new FileInputCommandsHandler(innerHandler);
        string[] args = ["file", "copy", "C:\\Users", "C:\\Program Files"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileCopyCommand("C:\\Users", "C:\\Program Files", new LocalFileCopyExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileDeleteTest()
    {
        // Arrange
        var decider = new FileDeleteExecutorDecider();
        var innerHandler = new FileDeleteInputCommandHandler(decider);
        var handler = new FileInputCommandsHandler(innerHandler);
        string[] args = ["file", "delete", "C:\\Users"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileDeleteCommand("C:\\Users", new LocalFileDeleteExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }

    [Fact]
    public void FileRenameTest()
    {
        // Arrange
        var decider = new FileRenameExecutorDecider();
        var innerHandler = new FileRenameInputCommandHandler(decider);
        var handler = new FileInputCommandsHandler(innerHandler);
        string[] args = ["file", "rename", "C:\\Users", "newName"];
        var absolutePathDecider = new AbsolutePathDecider();
        var absolutePath = new AbsolutePath(absolutePathDecider);
        absolutePath.SetPath("C:");
        var mode = new ModeWrapper();
        mode.SetMode("local");
        var expectedCommand = new FileRenameCommand("C:\\Users", "newName", new LocalFileRenameExecutor());
        using IEnumerator<string> enumerator = ((IEnumerable<string>)args).GetEnumerator();
        enumerator.MoveNext();

        // Act
        ICommandBuilder? builder = handler.HandleCommand(enumerator);
        ICommand? command = builder?.WithConnectedPath(absolutePath).WithMode(mode).Build();

        // Assert
        Assert.Equivalent(expectedCommand, command);
    }
}