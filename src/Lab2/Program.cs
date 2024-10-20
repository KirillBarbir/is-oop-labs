using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Program : IStoredType
{
    public int Id { get; }

    public string Name { get; }

    public int DirectorId { get; }

    public Collection<int>[] SubjectIDs { get; }

    public Program(int id, string name, int directorId, Collection<int>[] subjectIDs)
    {
        Id = id;
        Name = name;
        DirectorId = directorId;
        SubjectIDs = subjectIDs;
    }
}