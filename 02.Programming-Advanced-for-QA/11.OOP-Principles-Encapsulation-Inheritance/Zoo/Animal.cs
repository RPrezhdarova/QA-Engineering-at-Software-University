﻿namespace Zoo;

public class Animal
{

    private string name;

    
    public Animal(string name)
    {
        Name = name;
    }

    public string Name { get => name; set => name = value; }
}
