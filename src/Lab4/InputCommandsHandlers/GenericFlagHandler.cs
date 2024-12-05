namespace Itmo.ObjectOrientedProgramming.Lab4.InputCommandsHandlers;

public class GenericFlagHandler<T>
{/*
    private readonly string _flag;
    private readonly T _defaultValue;

    public GenericFlagHandler(string flag, T defaultValue)
    {
        _flag = flag;
        _defaultValue = defaultValue;
    }

    protected GenericFlagHandler<T>? Next { get; private set; }

    public GenericFlagHandler<T> AddNext(GenericFlagHandler<T> nextFlagHandler)
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
            return _defaultValue;
        }

        if (!request.MoveNext())
        {
            return _defaultValue;
        }

        T.Parse(request.Current);
    }*/
}