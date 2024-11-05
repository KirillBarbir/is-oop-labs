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
        Collection<Labwork> labworks,
        Collection<Lecture> lectures,
        int examPoints)
         : base(id, authorId, name, description, labworks, lectures)
     {
         ExamPoints = examPoints;
     }

    public override ExamSubject Clone(int newId)
    {
        var subjectClone = new ExamSubject(newId, AuthorID, Name, Description, Labworks, Lectures, ExamPoints);
        subjectClone.BaseID = Id;
        return subjectClone;
    }
}