using Itmo.ObjectOrientedProgramming.Lab2;
using JetBrains.Annotations;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(StudyMaterialCreator))]
public class UnauthorizedAcessTests
{
        [Fact]
        public void UnauthorizedLabworkAcessTest()
        {
            // arrange
            var creator = new StudyMaterialCreator();
            creator.Authorize(1);
            Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 15, "15 points");

            // act
            labwork1.EditDescription("Description2", 2);

            // assert
            Assert.Equal("Description1", labwork1.Description);
        }

        [Fact]
        public void UnauthorizedLectureAcessTest()
        {
            // arrange
            var creator = new StudyMaterialCreator();
            creator.Authorize(1);
            Lecture lecture1 = creator.CreateLecture(1, "Lec1", "Description1", "content");

            // act
            lecture1.EditDescription("Description2", 2);

            // assert
            Assert.Equal("Description1", lecture1.Description);
        }

        [Fact]
        public void UnauthorizedSubjectAcessTest()
        {
            // arrange
            var creator = new StudyMaterialCreator();
            creator.Authorize(1);
            Lecture lecture1 = creator.CreateLecture(1, "Lab1", "Description1", "content");
            Lecture lecture2 = lecture1.Clone(2);
            Labwork labwork1 = creator.CreateLabwork(1, "Lab1", "Description1", 15, "15 points");
            Labwork labwork2 = labwork1.Clone(2);
            var labworks = new Collection<Labwork> { labwork1, labwork2 };
            var lectures = new Collection<Lecture> { lecture1, lecture2 };
            ExamSubject? subject1 = creator.CreateExamSubject(1, "Sub1", "Description1", labworks, lectures, 70);

            // act
            if (subject1 != null)
            {
                subject1.EditDescription("Description2", 2);
            }

            // assert
            if (subject1 != null)
            {
                Assert.Equal("Description1", subject1.Description);
            }
        }
}