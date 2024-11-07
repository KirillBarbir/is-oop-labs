namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class Subject : BasePrototype
{
    public ICollection<Labwork> Labworks { get; private set; }

    public ICollection<Lecture> Lectures { get; internal set; }

    internal Subject(int id, int authorId, string name, string description, ICollection<Labwork> labworks, ICollection<Lecture> lectures)
        : base(id, authorId, name, description)
    {
        Labworks = labworks;
        Lectures = lectures;
    }

    public void EditLectures(ICollection<Lecture> lectures)
    {
        Lectures = lectures;
    }
}