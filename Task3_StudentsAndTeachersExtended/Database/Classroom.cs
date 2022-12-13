using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Models;

namespace Task2_StudentsAndTeachers.Database
{
    internal class Classroom
    {
        public Teacher Teacher { get; set; }
        public SortedDictionary<int, Student> StudentsDatabase { get; set; }
        public static List<Student> StudentsIndexed { get; set; }
        public int StudentCount { get; set; }


        public Classroom()
        {
            StudentsDatabase = new SortedDictionary<int, Student>();
            StudentsIndexed = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            StudentsDatabase.Add(StudentCount, s);
            StudentsIndexed.Add(s);
            StudentCount++;
        }

        public int GetIdByGuid(Guid guid)
        {
            var id = StudentsDatabase
                .Select(s => s.Value)
                .Where(v => v.GuidIdentifier == guid)
                .Select(student => student.Id);
            int result = int.Parse(id.ToString());
            return result;
        }

        public void ChangeGradeById(int id, string grade)
        {
            if (StudentsDatabase.TryGetValue(id, out Student student))
                student.Grade = grade;
            else
                Console.WriteLine("No such student with this id!");
        }

        public Student GetStudentById(int id)
        {
            StudentsDatabase.TryGetValue(id, out Student student);
            return student;
        }

        public void ChangeGradeByGuid(Guid guid, string grade)
        {
            if (StudentsDatabase.TryGetValue(GetIdByGuid(guid), out Student student))
                student.Grade = grade;
            else
                Console.WriteLine("No such student with this guid!");
        }
    }
}
