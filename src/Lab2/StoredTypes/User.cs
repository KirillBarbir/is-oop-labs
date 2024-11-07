namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User : IStoredType
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}