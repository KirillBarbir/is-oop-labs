using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ZachyotSubjectBuilder : BaseSubjectBuilder
{
    protected override Subject? Build(
        int id,
        int authorId,
        string name,
        string description,
        Collection<Labwork> labworks,
        Collection<Lecture> lectures,
        int points)
    {
        int sum = 0;
        foreach (Labwork labwork in Labworks)
        {
            sum += labwork.Points;
        }

        if (sum != 100)
        {
            return null;
        }

        return new ZachyotSubject(id, authorId, name, description, labworks, lectures, points);
    }
}