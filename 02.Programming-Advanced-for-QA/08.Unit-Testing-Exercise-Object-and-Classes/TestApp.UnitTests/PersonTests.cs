using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        _person=new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        List<Person> expectedPeopleList = new List<Person>()
        {
            new Person()
            {
                Name="Alice",
                Id ="A001",
                Age=35
            },
            new Person()
            {
                Name="Bob",
                Id ="B002",
                Age=30
            }
        };

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        //Arrange
        List<Person> people = new List<Person>()
        {
            new Person()
            {
                Name="Alice",
                Id ="A001",
                Age=35
            },
            new Person()
            {
                Name="Bob",
                Id ="B002",
                Age=30
            }
        };

        string expectedResult = $"Bob with ID: B002 is 30 years old.{Environment.NewLine}" + "Alice with ID: A001 is 35 years old.";
        // Act
        string result=_person.GetByAgeAscending(people);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }
}
