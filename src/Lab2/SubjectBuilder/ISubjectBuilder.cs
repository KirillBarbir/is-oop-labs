namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface ISubjectBuilder
{
    ISubjectBuilder WithId(int id);

    ISubjectBuilder WithAuthorId(int id);

    ISubjectBuilder WithName(string name);

    ISubjectBuilder WithDescription(string description);

    ISubjectBuilder WithLabworks(ICollection<Labwork> labworks);

    ISubjectBuilder WithLectures(ICollection<Lecture> lectures);

    ISubjectBuilder WithPoints(int points);

    Subject? Build();
}