namespace Itmo.ObjectOrientedProgramming.Lab2;

public class GenericRepository<T> where T : IStoredType
{
    private readonly Dictionary<int, T> _dictionary = [];

    public void Add(T item)
    {
        _dictionary.TryAdd(item.Id, item);
    }

    public T? GetItem(int key)
    {
        return _dictionary.GetValueOrDefault(key);
    }
}