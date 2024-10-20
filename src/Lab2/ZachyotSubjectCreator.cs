using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ZachyotSubjectCreator : SubjectCreator
{
    public override ZachyotSubject CreateSubject(
        int id,
        int authorId,
        string name,
        string description,
        Collection<int> labworkIDs,
        Collection<int> lectureIDs,
        int points)
   {
       return new ZachyotSubject(id, authorId, name, description, labworkIDs, lectureIDs, points);
    }
}