using _15_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace _15_ConsoleApp.Service
{
    internal class CourseService
    {
        private List<CourseGroup> groups = new();
        private List<Student> students = new();

        public void CreateGroup(CourseGroup group)
        {
            groups.Add(group);
        }

        public void UpdateGroup(int id, string name, string teacher, int room)
        {
            var group = groups.FirstOrDefault(x => x.Id == id);
            if (group != null)
            {
                group.Name = name;
                group.Teacher = teacher;
                group.Room = room;
            }

        }

        public void DeleteGroup(int id)
        {
            var group = groups.FirstOrDefault(x => x.Id == id);
            if (group != null)
            {
                groups.Remove(group);
            }
        }

        public CourseGroup GetGroupById(int id)
        {
             return groups.FirstOrDefault(x => x.Id == id);
        }

        public List<CourseGroup> GetGroupByTeacher(string teacher)
        {
            return groups.Where(x => x.Teacher == teacher).ToList();
        }

        public List<CourseGroup> GetGroupByRoom(int room)
        {
            return groups.Where(x => x.Room == room).ToList();
        }

        public List<CourseGroup> GetAllGroup()
        {
            return groups;
        }

    }
}
