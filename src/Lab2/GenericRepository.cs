namespace Itmo.ObjectOrientedProgramming.Lab2;

public class GenericRepository<T> where T : IStoredType
{
    private readonly Dictionary<int, T> _dictionary = [];

    public void Add(T item)
    {
        if (!_dictionary.TryAdd(item.Id, item))
        {
            throw new ArgumentException($"Item with id {item.Id} already exists");
        }
    }

    public T? GetItem(int key)
    {
        return _dictionary[key];
    }
}