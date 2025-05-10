using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainCreators;

public interface IChainCreator
{
    IInputCommandHandler CreateChain();
}