using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class Subject : BasePrototype
{
    public Collection<int> LabworkIDs { get; private set; }

    public Collection<int> LectureIDs { get; internal set; }

    internal Subject(int id, int authorId, string name, string description, Collection<int> labworkIDs, Collection<int> lectureIDs)
        : base(id, authorId, name, description)
    {
        LabworkIDs = labworkIDs;
        LectureIDs = lectureIDs;
    }
}