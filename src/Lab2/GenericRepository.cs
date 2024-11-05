namespace Itmo.ObjectOrientedProgramming.Lab2;

public class GenericRepository<T> where T : IStoredType
{
    private readonly Dictionary<int, T> _dictionary = [];

    public void Add(T item)
    {
        if (!_dictionary.TryAdd(item.Id, item))
        {
            Console.WriteLine($"Item with id {item.Id} already exists");
        }
    }

    public T? GetItem(int key)
    {
        if (!_dictionary.TryGetValue(key, out T? item))
        {
            Console.WriteLine($"Item with id {key} does not exist");
        }

        return item;
    }
}