using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _15_ConsoleApp.Models
{
    internal class Student
    {
        private static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public CourseGroup CourseGroup { get; set; }

        public Student(string name, string surname, int age)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
            Age = age;
        }

    }
}
