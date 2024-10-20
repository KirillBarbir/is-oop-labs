using Itmo.ObjectOrientedProgramming.Lab2;
using JetBrains.Annotations;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(ProgramConstructor))]
public class ProgramConstructorTest
{
    [Fact]
    public void CloneLabworkTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            50,
            "requirements1");
        Assert.True(programConstructor.Authorise("User1"));
        programConstructor.CloneLabwork("lab1", "lab1(1)");
        BaseRepository<Labwork> labworkRepository = programConstructor.ReturnLabworkRepository();
        Assert.Equal(
            labworkRepository.FindItem(labworkRepository.FindKeyByName("lab1(1)").Value).BaseID,
            labworkRepository.FindKeyByName("lab1").Value);
    }

    [Fact]
    public void CloneLectureTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        Assert.True(programConstructor.Authorise("User1"));
        programConstructor.CloneLecture("lec1", "lec1(1)");
        BaseRepository<Lecture> lectureRepository = programConstructor.ReturnLectureRepository();
        Assert.Equal(
            lectureRepository.FindItem(lectureRepository.FindKeyByName("lec1(1)").Value).BaseID,
            lectureRepository.FindKeyByName("lec1").Value);
    }

    [Fact]
    public void CloneSubjectTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            50,
            "requirements1");
        var labworks = new Collection<string>();
        var lectures = new Collection<string>();
        labworks.Add("lab1");
        lectures.Add("lec1");
        programConstructor.CreateExamSubject(
            "examSubject1", "description1", labworks, lectures, 50);
        Assert.True(programConstructor.Authorise("User1"));
        programConstructor.CloneExamSubject("examSubject1", "examSubject1(1)");
        BaseRepository<Subject> subjectRepository = programConstructor.ReturnSubjectRepository();
        Assert.Equal(
            subjectRepository.FindItem(subjectRepository.FindKeyByName("examSubject1(1)").Value).BaseID,
            subjectRepository.FindKeyByName("examSubject1").Value);
    }

    [Fact]
    public void Not100Points1()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            50,
            "requirements1");
        var labworks = new Collection<string>();
        var lectures = new Collection<string>();
        labworks.Add("lab1");
        lectures.Add("lec1");
        Assert.False(programConstructor.CreateExamSubject(
            "examSubject1",
            "description1",
            labworks,
            lectures,
            49));
    }

    [Fact]
    public void Not100Points2()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            25,
            "requirements1");
        programConstructor.CreateLabwork(
            "lab2",
            "description1",
            25,
            "requirements1");
        var labworks = new Collection<string>();
        var lectures = new Collection<string>();
        labworks.Add("lab1");
        labworks.Add("lab2");
        lectures.Add("lec1");
        Assert.False(programConstructor.CreateExamSubject(
            "examSubject1",
            "description1",
            labworks,
            lectures,
            49));
    }

    [Fact]
    public void LabworkUnauthorizedAccessTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            50,
            "requirements1");
        Assert.True(programConstructor.Authorise("User1"));
        Assert.False(programConstructor.EditLabworkDescription("lab1", "edited description"));
        programConstructor.Authorise("User2");
        Assert.True(programConstructor.EditLabworkDescription("lab1", "edited description"));
        programConstructor.Logout();
        Assert.False(programConstructor.EditLabworkDescription("lab1", "edited edited description"));
    }

    [Fact]
    public void LectureUnauthorizedAccessTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        Assert.True(programConstructor.Authorise("User1"));
        Assert.False(programConstructor.EditLectureDescription("lec1", "edited description"));
        programConstructor.Authorise("User2");
        Assert.True(programConstructor.EditLectureDescription("lec1", "edited description"));
        programConstructor.Logout();
        Assert.False(programConstructor.EditLectureDescription("lec1", "edited edited description"));
    }

    [Fact]
    public void SubjectUnauthorizedAccessTest()
    {
        var programConstructor = new ProgramConstructor();
        programConstructor.SignIn("User1");
        programConstructor.SignIn("User2");
        programConstructor.CreateLecture(
            "lec1",
            "description1",
            "content1");
        programConstructor.CreateLabwork(
            "lab1",
            "description1",
            50,
            "requirements1");
        var labworks = new Collection<string>();
        var lectures = new Collection<string>();
        labworks.Add("lab1");
        lectures.Add("lec1");
        programConstructor.CreateExamSubject(
            "examSubject1", "description1", labworks, lectures, 50);
        Assert.True(programConstructor.Authorise("User1"));
        Assert.False(programConstructor.EditSubjectName("examSubject1", "examSubject2"));
        programConstructor.Authorise("User2");
        Assert.True(programConstructor.EditSubjectName("examSubject1", "examSubject3"));
        programConstructor.Logout();
        Assert.False(programConstructor.EditSubjectName("examSubject3", "examSubject4"));
    }
}