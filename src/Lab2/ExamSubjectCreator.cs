using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ExamSubjectCreator : SubjectCreator
{
    public override ExamSubject CreateSubject(
        int id,
        int authorId,
        string name,
        string description,
        Collection<int> labworkIDs,
        Collection<int> lectureIDs,
        int points)
    {
        return new ExamSubject(id, authorId, name, description, labworkIDs, lectureIDs, points);
    }
}