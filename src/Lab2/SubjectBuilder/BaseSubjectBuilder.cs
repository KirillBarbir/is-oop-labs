namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class BaseSubjectBuilder : ISubjectBuilder
{
    protected ICollection<Labwork> Labworks { get; private set; } = [];

    private int? Id { get; set; }

    private int? AuthorId { get; set; }

    private string? Name { get; set; }

    private string Description { get; set; } = string.Empty;

    private ICollection<Lecture> Lectures { get; set; } = [];

    private int? Points { get; set; }

    public ISubjectBuilder WithId(int id)
    {
        Id = id;
        return this;
    }

    public ISubjectBuilder WithAuthorId(int id)
    {
        AuthorId = id;
        return this;
    }

    public ISubjectBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public ISubjectBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }

    public ISubjectBuilder WithLabworks(ICollection<Labwork> labworks)
    {
        Labworks = labworks;
        return this;
    }

    public ISubjectBuilder WithLectures(ICollection<Lecture> lectures)
    {
        Lectures = lectures;
        return this;
    }

    public ISubjectBuilder WithPoints(int points)
    {
         Points = points;
         return this;
    }

    public Subject? Build()
    {
        return Build(
            Id ?? throw new ArgumentNullException(),
            AuthorId ?? throw new ArgumentNullException(),
            Name ?? throw new ArgumentNullException(),
            Description,
            Labworks,
            Lectures,
            Points ?? throw new ArgumentNullException());
    }

    protected abstract Subject? Build(
        int id,
        int authorId,
        string name,
        string description,
        ICollection<Labwork> labworks,
        ICollection<Lecture> lectures,
        int points);
}