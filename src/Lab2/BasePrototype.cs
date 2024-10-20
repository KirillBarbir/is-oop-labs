namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BasePrototype : IStoredType
{
    public int Id { get; private set; }

    public int? BaseID { get; internal set; }

    public int AuthorID { get; internal set; }

    public string Name { get; internal set; }

    public string Description { get; internal set; }

    public BasePrototype(int id, int authorId, string name, string description = "")
    {
        Id = id;
        AuthorID = authorId;
        Name = name;
        Description = description;
    }

    public virtual BasePrototype Clone(int newId)
    {
        var clone = new BasePrototype(newId, AuthorID, Name, Description)
        {
            BaseID = Id,
        };
        return clone;
    }
}