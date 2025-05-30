﻿using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.TreeInputCommandHandlers;

public class TreeGotoInputCommandHandler : BaseInputCommandHandler
{
   public override ICommandBuilder? HandleCommand(IEnumerator<string> request)
    {
        if (request.Current is not "goto")
        {
            return Next?.HandleCommand(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        string path = request.Current;
        var builder = new TreeGotoCommandBuilder();
        return builder
            .WithPath(path);
    }
}