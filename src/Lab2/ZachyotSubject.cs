using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ZachyotSubject : Subject
{
    public int PointThreshold { get; internal set; }

    public ZachyotSubject(
        int id,
        int authorId,
        string name,
        string description,
        Collection<int> labworkIDs,
        Collection<int> lectureIDs,
        int pointThreshold)
        : base(id, authorId, name, description, labworkIDs, lectureIDs)
    {
        PointThreshold = pointThreshold;
    }

    public override ZachyotSubject Clone(int newId)
    {
        var subjectClone =
            new ZachyotSubject(newId, AuthorID, Name, Description, LabworkIDs, LectureIDs, PointThreshold);
        subjectClone.BaseID = Id;
        return subjectClone;
    }
}