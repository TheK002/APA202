using System;

class Program
{
    static void Main(string[] args)
    {
        // Students
        Student s1 = new Student("Ali", "Aliyev", 20, "ali@mail.com", "S001", "ST001", "IT", 88.5, 2);
        Student s2 = new Student("Veli", "Veliev", 21, "veli@mail.com", "S002", "ST002", "IT", 92.0, 3);
        Student s3 = new Student("Aysel", "Memmedova", 19, "aysel@mail.com", "S003", "ST003", "Business", 68.5, 1);

        // Teachers
        Teacher t1 = new Teacher("Rashad", "Hasanov", 40, "rashad@mail.com", "T001", "CS", "Programming", 800, 15);
        Teacher t2 = new Teacher("Leyla", "Kerimova", 35, "leyla@mail.com", "T002", "Math", "Algebra", 800, 8);

        // Administrator
        Administrator admin = new Administrator("Nigar", "Aliyeva", 45, "nigar@mail.com", "A001", "Dekan", "IT", 5);

        Console.WriteLine("=== STUDENTS ===");
        double totalScholarship = 0;

        Student[] students = { s1, s2, s3 };
        foreach (var s in students)
        {
            s.ShowStudentInfo();
            double scholarship = s.CalculateScholarship();
            Console.WriteLine($"Təqaud: {scholarship} AZN\n");
            totalScholarship += scholarship;
        }

        Console.WriteLine("=== TEACHERS ===");
        decimal totalSalary = 0;

        Teacher[] teachers = { t1, t2 };
        foreach (var t in teachers)
        {
            t.ShowTeacherInfo();
            decimal salary = t.CalculateSalary();
            Console.WriteLine($"Maash: {salary} AZN\n");
            totalSalary += salary;
        }

        Console.WriteLine("=== ADMIN ===");
        admin.ShowAdminInfo();

        Console.WriteLine("\n--- ACCESS ---");
        admin.GrantAccess(s1);

        Console.WriteLine("\n=== STATISTICS ===");
        Console.WriteLine($"Umumi təqaud xərci: {totalScholarship} AZN");
        Console.WriteLine($"Umumi maash xərci: {totalSalary} AZN");
    }
}