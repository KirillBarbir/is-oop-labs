namespace Itmo.ObjectOrientedProgramming.Lab2;

public enum ResultType
{
    Success,
    Failure,
}

public record ReturnType<T>
{
    public T? Value { get; }

    public ResultType ResultType { get; }

    public ReturnType(T? value, ResultType resultType)
    {
        Value = value;
        ResultType = resultType;
    }
}