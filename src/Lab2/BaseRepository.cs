namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BaseRepository<T> where T : IStoredType
{
    public BaseRepository() { }

    private readonly Dictionary<int, T> _dictionary = new Dictionary<int, T>();

    public void Add(T item)
    {
        _dictionary.Add(item.Id, item);
    }

    public bool CheckAvailability(int key)
    {
        return _dictionary.ContainsKey(key);
    }

    public bool CheckAvailability(T item)
    {
        return _dictionary.ContainsValue(item);
    }

    public T ExtractItem(int key)
    {
        T result = _dictionary[key];
        _dictionary.Remove(key);
        return result;
    }

    public T FindItem(int key)
    {
        return _dictionary[key];
    }

    public ReturnType<int> FindKeyByItem(T value)
    {
        foreach (KeyValuePair<int, T> item in _dictionary)
        {
            if (item.Value.Equals(value))
            {
                return new ReturnType<int>(item.Key, ResultType.Success);
            }
        }

        return new ReturnType<int>(0, ResultType.Failure);
    }

    public ReturnType<int> FindKeyByName(string name)
    {
        foreach (KeyValuePair<int, T> item in _dictionary)
        {
            if (item.Value.Name == name)
            {
                return new ReturnType<int>(item.Key, ResultType.Success);
            }
        }

        return new ReturnType<int>(0, ResultType.Failure);
    }
}