using Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling.FlagCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers.FlagHandling;

public class GenericFlagHandler<TBase, T> where T : class, IFlaggedCommandBuilder<TBase>
{
    private readonly string _flag;
    private readonly T _builder;
    private readonly string _defaultValue;

    public GenericFlagHandler(string flag, T builder, string defaultValue)
    {
        _flag = flag;
        _builder = builder;
        _defaultValue = defaultValue;
    }

    protected GenericFlagHandler<TBase, T>? Next { get; private set; }

    public GenericFlagHandler<TBase, T> AddNext(GenericFlagHandler<TBase, T> nextFlagHandler)
    {
        if (Next is null)
        {
            Next = nextFlagHandler;
        }
        else
        {
            Next.AddNext(nextFlagHandler);
        }

        return this;
    }

    public T? Handle(IEnumerator<string> request)
    {
        if (request.Current != _flag)
        {
            if (Next != null) return Next.Handle(request);
            _builder.WithFlag(_defaultValue);
            return _builder;
        }

        if (!request.MoveNext())
        {
            _builder.WithFlag(_defaultValue);
            return _builder;
        }

        _builder.WithFlag(request.Current);
        return _builder;
    }
}