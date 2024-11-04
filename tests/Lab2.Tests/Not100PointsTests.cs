using Itmo.ObjectOrientedProgramming.Lab2;
using JetBrains.Annotations;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(StudyMaterialCreator))]
public class Not100PointsTests
{
    [Fact]
    public void Not100PointsTest1()
    {
        var creator = new StudyMaterialCreator();
        creator.Authorize(1);
        Lecture lecture1 = creator.CreateLecture(1, "Lab1", "Description1", "content");
        Lecture lecture2 = lecture1.Clone(2);
        Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 15, "15 points");
        Labwork labwork2 = labwork1.Clone(2);
        var labworks = new Collection<Labwork> { labwork1, labwork2 };
        var lectures = new Collection<Lecture> { lecture1, lecture2 };
        ExamSubject? subject1 = creator.CreateExamSubject(1, "Sub1", "Description1", labworks, lectures, 71);
        Assert.Null(subject1);
    }

    [Fact]
    public void Not100PointsTest2()
    {
        var creator = new StudyMaterialCreator();
        creator.Authorize(1);
        Lecture lecture1 = creator.CreateLecture(1, "Lab1", "Description1", "content");
        Lecture lecture2 = lecture1.Clone(2);
        Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 10, "15 points");
        Labwork labwork2 = labwork1.Clone(2);
        var labworks = new Collection<Labwork> { labwork1, labwork2 };
        var lectures = new Collection<Lecture> { lecture1, lecture2 };
        ZachyotSubject? subject1 = creator.CreateZachyotSubject(1, "Sub1", "Description1", labworks, lectures, 70);
        Assert.Null(subject1);
    }
}