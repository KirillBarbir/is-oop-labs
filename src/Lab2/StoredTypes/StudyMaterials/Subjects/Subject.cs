using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class Subject : BasePrototype
{
    public Collection<Labwork> Labworks { get; private set; }

    public Collection<Lecture> Lectures { get; internal set; }

    internal Subject(int id, int authorId, string name, string description, Collection<Labwork> labworks, Collection<Lecture> lectures)
        : base(id, authorId, name, description)
    {
        Labworks = labworks;
        Lectures = lectures;
    }

    public void EditLectures(Collection<Lecture> lectures)
    {
        Lectures = lectures;
    }
}