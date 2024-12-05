using System;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        //Arrange
        string title = "Take the exam";
        DateTime dateTime = DateTime.Parse("01.01.2025");
        string expected = "[ ] Take the exam - Due: ";

        //Act
        _toDoList.AddTask(title, dateTime);
        string result=_toDoList.DisplayTasks();

        //Assert
        Assert.That(result.Contains(expected), Is.True);

    }
    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        //Arrange
        string title = "Take the exam";
        DateTime dateTime = DateTime.Parse("01.01.2025");
        string expected = "[✓] Take the exam - Due: ";

        //Act
        _toDoList.AddTask(title, dateTime);
        _toDoList.CompleteTask(title);
        string result = _toDoList.DisplayTasks();

        //Assert
        Assert.That(result.Contains(expected), Is.True);
    }
    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        //Arrange
        string title = "Take the exam";
        DateTime dateTime = DateTime.Parse("01.01.2025");
        string expected = "[ ] Take the exam - Due: ";

        //Act
        _toDoList.AddTask(title, dateTime);

        //Assert
        var ex = Assert.Throws<ArgumentException>(() => _toDoList.CompleteTask("unknown"));
        Assert.That(ex.Message, Is.EqualTo("Task with given title does not exist."));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        //Arrange        
        string expectedHeader = "To-Do List:";

        //Act        
        string result = _toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Is.EqualTo(expectedHeader));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        //Arrange
        string title = "First Task";
        DateTime dateTime = DateTime.Parse("01.12.2025");
        string title2 = "Second Task";
        DateTime dateTime2 = DateTime.Parse("01.12.2024");
        string expected = "[ ] First Task - Due: ";
        string expected2 = "[✓] Second Task - Due: ";        

        //Act
        _toDoList.AddTask(title, dateTime);
        _toDoList.AddTask(title2, dateTime2);
   
        _toDoList.CompleteTask(title2);
        string result = _toDoList.DisplayTasks();

        //Assert
        bool isContained=result.Contains(expected)&&result.Contains(expected2);
        Assert.That(isContained, Is.True);
    }
}
