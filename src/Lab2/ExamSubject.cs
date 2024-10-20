using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ExamSubject : Subject
{
    public int ExamPoints { get; private set; }

    public ExamSubject(
        int id,
        int authorId,
        string name,
        string description,
        Collection<int> labworkIDs,
        Collection<int> lectureIDs,
        int examPoints)
         : base(id, authorId, name, description, labworkIDs, lectureIDs)
     {
         ExamPoints = examPoints;
     }

    public override ExamSubject Clone(int newId)
    {
        var subjectClone = new ExamSubject(newId, AuthorID, Name, Description, LabworkIDs, LectureIDs, ExamPoints);
        subjectClone.BaseID = Id;
        return subjectClone;
    }
}