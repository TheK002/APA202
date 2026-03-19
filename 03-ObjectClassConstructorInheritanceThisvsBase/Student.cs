using System;

public class Student : Person
{
    public string StudentNumber;
    public string Faculty;
    public double GPA;
    public int Year;

    public Student(string firstName, string lastName, int age, string email, string id,
                   string studentNumber, string faculty, double gpa, int year)
        : base(firstName, lastName, age, email, id)
    {
        this.StudentNumber = studentNumber;
        this.Faculty = faculty;
        this.GPA = gpa;
        this.Year = year;
    }

    public void ShowStudentInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Telebe nömrəsi: {StudentNumber}");
        Console.WriteLine($"Fakulte: {Faculty}");
        Console.WriteLine($"GPA: {GPA}");
        Console.WriteLine($"Kurs: {Year}");
    }

    public double CalculateScholarship()
    {
        if (GPA >= 90) return 500;
        else if (GPA >= 80) return 350;
        else if (GPA >= 70) return 200;
        else return 0;
    }
}