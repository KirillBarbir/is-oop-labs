using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class SubjectCreator
{
    public abstract Subject CreateSubject(
        int id,
        int authorId,
        string name,
        string description,
        Collection<int> labworkIDs,
        Collection<int> lectureIDs,
        int points);
}
