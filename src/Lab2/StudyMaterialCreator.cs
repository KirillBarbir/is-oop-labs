using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class StudyMaterialCreator
{
    public int CurrentId { get; private set; }

    public void Authorize(int currentId)
    {
        CurrentId = currentId;
    }

    public Labwork CreateLabwork(
        int id,
        string name,
        string description,
        int points,
        string labworkPointsRequirements)
    {
        return new Labwork(id, CurrentId, name, description, points, labworkPointsRequirements);
    }

    public Lecture CreateLecture(
        int id,
        string name,
        string description,
        string content)
    {
        return new Lecture(id, CurrentId, name, description, content);
    }

    public ZachyotSubject? CreateZachyotSubject(
        int id,
        string name,
        string description,
        Collection<Labwork> labworks,
        Collection<Lecture> lectures,
        int pointThreshold)
    {
        var builder = new ZachyotSubjectBuilder();
        return (ZachyotSubject?)builder.WithId(id)
            .WithAuthorId(CurrentId)
            .WithName(name)
            .WithDescription(description)
            .WithLabworks(labworks)
            .WithLectures(lectures)
            .WithPoints(pointThreshold)
            .Build();
    }

    public ExamSubject? CreateExamSubject(
        int id,
        string name,
        string description,
        Collection<Labwork> labworks,
        Collection<Lecture> lectures,
        int examPoints)
    {
        var builder = new ExamSubjectBuilder();
        return (ExamSubject?)builder.WithId(id)
            .WithAuthorId(CurrentId)
            .WithName(name)
            .WithDescription(description)
            .WithLabworks(labworks)
            .WithLectures(lectures)
            .WithPoints(examPoints)
            .Build();
    }
}