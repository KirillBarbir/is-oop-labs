using Itmo.ObjectOrientedProgramming.Lab2;
using JetBrains.Annotations;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(StudyMaterialCreator))]

public class CloneTests
{
    [Fact]
    public void CloneLabworkTest()
    {
        var creator = new StudyMaterialCreator();
        creator.Authorize(1);
        Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 15, "15 points");
        Labwork labwork2 = labwork1.Clone(2);
        Assert.Equal(labwork1.Id, labwork2.AuthorID);
    }

    [Fact]
    public void CloneLectureTest()
    {
        var creator = new StudyMaterialCreator();
        creator.Authorize(1);
        Lecture lecture1 = creator.CreateLecture(1, "Lec1", "Description1", "content");
        Lecture lecture2 = lecture1.Clone(2);
        Assert.Equal(lecture1.Id, lecture2.AuthorID);
    }

    [Fact]
    public void CloneSubjectTest()
    {
        var creator = new StudyMaterialCreator();
        creator.Authorize(1);
        Lecture lecture1 = creator.CreateLecture(1, "Lab1", "Description1", "content");
        Lecture lecture2 = lecture1.Clone(2);
        Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 15, "15 points");
        Labwork labwork2 = labwork1.Clone(2);
        var labworks = new Collection<Labwork> { labwork1, labwork2 };
        var lectures = new Collection<Lecture> { lecture1, lecture2 };
        ExamSubject? subject1 = creator.CreateExamSubject(1, "Sub1", "Description1", labworks, lectures, 70);
        if (subject1 != null)
        {
            ExamSubject subject2 = subject1.Clone(2);
            Assert.Equal(subject1.Id, subject2.AuthorID);
        }
    }
}