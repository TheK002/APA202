using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _15_ConsoleApp.Models
{
    internal class CourseGroup
    {
        private static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }

        public CourseGroup(string name, string teacher, int room)
        {
            _id++;
            Id = _id;
            Name = name;
            Teacher = teacher;
            Room = room;

        }
    }
}
