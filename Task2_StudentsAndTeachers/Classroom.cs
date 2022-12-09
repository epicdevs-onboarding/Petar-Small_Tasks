using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Classroom
    {
        public Teacher Teacher { get; set;}
        public SortedDictionary<int, Student> StudentsDatabase { get; set;}
        public static List<Student> StudentsIndexed { get; set;}
        public int StudentCount { get; set;}


        public Classroom()
        {
            StudentsDatabase = new SortedDictionary<int, Student>();
            StudentsIndexed = new List<Student>();
        }

        public void PrintClassroom()
        {
            Console.WriteLine("\n ===================== \n");
            if (!(Teacher.FirstName == null))
            {
                Console.WriteLine(Teacher.ToString());
            }
            else
            {
                Console.WriteLine("This class has no teacher.");
            }
                

            Console.WriteLine("*******");
            foreach (KeyValuePair<int, Student> entry in StudentsDatabase)
            {
                Console.WriteLine(entry.Value.ToString());
            }
        }
        public void AddStudent(Student s)
        {
            StudentsDatabase.Add(StudentCount, s);
            StudentsIndexed.Add(s);
            StudentCount++;
        }

        public int GetIdByGuid(Guid guid)
        {
            foreach (KeyValuePair<int, Student> pair in StudentsDatabase)
            {
                if(pair.Value.GuidIdentifier == guid) return pair.Key;
                
            }
            return 0;
        }

        public void ChangeGradeById(int id, string grade)
        {
            if (StudentsDatabase.TryGetValue(id, out Student s))
            {
                s.Grade = grade;
            }
            else
            {
                Console.WriteLine("No such student with this id!");
            }
        }

        public Student GetStudentById(int id)
        {
            Student s;
            StudentsDatabase.TryGetValue(id, out s);
            return s;
        }

        public void ChangeGradeByGuid(Guid guid, string grade)
        {
            if (StudentsDatabase.TryGetValue(GetIdByGuid(guid), out Student s))
            {
                s.Grade = grade;
            }
            else
            {
                Console.WriteLine("No such student with this guid!");
            }
        }

        /*
        public List<Student> PrintClassByGrade(List<Student> classroom)
        {
            return classroom.OrderBy(s => s.Grade).ToList();
        }

        public List<Student> PrintClassByAge(List<Student> classroom)
        {
            return classroom.OrderByDescending(s => s.Age).ToList();
        }
        */
    }
}
