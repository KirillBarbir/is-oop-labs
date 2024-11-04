using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface ISubjectBuilder
{
    ISubjectBuilder WithId(int id);

    ISubjectBuilder WithAuthorId(int id);

    ISubjectBuilder WithName(string name);

    ISubjectBuilder WithDescription(string description);

    ISubjectBuilder WithLabworks(Collection<Labwork> labworks);

    ISubjectBuilder WithLectures(Collection<Lecture> lectures);

    ISubjectBuilder WithPoints(int points);

    Subject? Build();
}