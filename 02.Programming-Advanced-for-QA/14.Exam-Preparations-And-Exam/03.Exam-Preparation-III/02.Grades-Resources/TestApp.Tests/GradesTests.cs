using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        //Arrange
        Dictionary<string, int> students = new()
        {
            {"Ivan", 70 },
            {"Peter", 12 },
            {"Teodor", 65 },
            {"Alexander", 41 }
        };
        string expected = $"Ivan with average grade 70.00{Environment.NewLine}" +
                          $"Teodor with average grade 65.00{Environment.NewLine}" +
                          $"Alexander with average grade 41.00";

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        //Arrange
        Dictionary<string, int> students = new();

        string expected = String.Empty;

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        //Arrange
        Dictionary<string, int> students = new()
        {
            {"Ivan", 70 },
            {"Alexander", 41 }
        };
        string expected = $"Ivan with average grade 70.00{Environment.NewLine}" +
                          $"Alexander with average grade 41.00";

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        Dictionary<string, int> students = new()
        {
            {"Ivan", 20 },
            {"Peter", 20 },
            {"Alexander", 20 }
        };
        string expected = $"Alexander with average grade 20.00{Environment.NewLine}" +
                          $"Ivan with average grade 20.00{Environment.NewLine}" +
                          $"Peter with average grade 20.00";

        //Act
        string result = Grades.GetBestStudents(students);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
