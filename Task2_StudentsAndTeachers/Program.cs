using System.Collections.ObjectModel;
using System.IO.MemoryMappedFiles;
using System.Reflection.Metadata.Ecma335;

namespace Task2_StudentsAndTeachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            bool isInsertModeActive = true;
            bool hasTeacher = false;
            Teacher teacher = new Teacher();
            do
            {
                Console.WriteLine("Enter person's details as such <names> <age> (student/teacher): ");
                string inputString = Console.ReadLine();
                string firstName, lastName, fullName, role, grade;
                int age;
                Person person = new Person();
                

                if (inputString.Equals("q!"))
                {
                    isInsertModeActive = false;
                }
                else if (person.AssignDetailsSuccessful(inputString))
                {
                    if (person.Role.Equals("student"))
                    {
                        Student student = new Student();
                        student.FirstName = person.FirstName;
                        student.LastName = person.LastName;
                        student.FullName = person.FullName;
                        student.Role = person.Role;
                        student.Age = person.Age;
                        Console.WriteLine("Enter a grade for this student: ");
                        student.Grade = Console.ReadLine();
                        students.Add(student);
                    }
                    else if (person.Role.Equals("teacher") && hasTeacher == false)
                    {
                        teacher.FirstName = person.FirstName;
                        teacher.LastName = person.LastName;
                        teacher.FullName = person.FullName;
                        teacher.Role = person.Role;
                        teacher.Age = person.Age;
                        Console.WriteLine("Enter a specialty for this teacher: ");
                        teacher.Specialty = Console.ReadLine();
                        hasTeacher= true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

            } while (isInsertModeActive);

            Console.WriteLine("\n ===================== \n");

            Console.WriteLine(teacher.ToString());
            students = PrintClassByAge(PrintClassByGrade(students));

            foreach (Student s in students)
            {
                Console.WriteLine($"{s.ToString()} ");
            }
        }

        static List<Student> PrintClassByGrade(List<Student> classroom)
        {
            return classroom.OrderBy(s => s.Grade).ToList();
        }

        static List<Student> PrintClassByAge(List<Student> classroom)
        {
            return classroom.OrderByDescending(s => s.Age).ToList();
        }
    }
}