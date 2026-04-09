using System;

public class Person
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string Email;
    public string Id;

    public Person(string firstName, string lastName, int age, string email, string id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Email = email;
        this.Id = id;
    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }

    public void ShowBasicInfo()
    {
        Console.WriteLine($"Ad Soyad: {GetFullName()}");
        Console.WriteLine($"Yash: {Age}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"ID: {Id}");
    }
}