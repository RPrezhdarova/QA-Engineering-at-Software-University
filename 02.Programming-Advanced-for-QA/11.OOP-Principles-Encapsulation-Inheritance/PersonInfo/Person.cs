using System;
using System.Runtime.CompilerServices;

namespace PersonInfo;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FirstName
    {
        get => firstName;
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get => lastName;
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }
    public int Age
    {
        get => age;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    public override string ToString()
    {
        return $"{FirstName} {LastName} is {age} years old.";
    }
}
