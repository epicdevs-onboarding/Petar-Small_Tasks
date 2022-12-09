using System.Collections.ObjectModel;
using System.IO.MemoryMappedFiles;
using System.Reflection.Metadata.Ecma335;

namespace Task2_StudentsAndTeachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isInsertModeActive = true;
            bool hasTeacher = false;
            Classroom classroom = new Classroom();
            Teacher teacher = new Teacher();
            teacher.Classroom = classroom;
            classroom.Teacher = teacher;

            do
            {
                Console.WriteLine("Enter person's details as such <names> [<age>] (student/teacher): ");
                string inputString = Console.ReadLine();
                if (IsValidPersonInput(inputString))
                {
                    Console.WriteLine("Invalid person input! Check if you typed all required fields!");
                    continue;
                }
                string firstName, lastName, fullName, role, grade;
                int age;
                Person person = new Person();
                
                if (inputString.Equals("q!"))
                    isInsertModeActive = false;
                else if (person.AssignDetailsSuccessful(inputString))
                {
                    if (person.RoleTitle.Id == 1)
                    {
                        Student student = new Student();
                        student.SetFields(person.FullName, person.FirstName, person.LastName, person.Age);

                        Console.WriteLine($"Enter a grade for {student.FullName}: ");
                        student.Grade = Console.ReadLine();

                        classroom.AddStudent(student);
                    }
                    else if (person.RoleTitle.Id == 2 && hasTeacher == false)
                    {
                        teacher.SetFields(person.FullName, person.FirstName, person.LastName, person.Age);
                        Console.WriteLine("Enter a specialty for the teacher: ");
                        teacher.Specialty = Console.ReadLine();
                        hasTeacher= true;
                    }
                }
                else
                    Console.WriteLine("Invalid input!");

            } while (isInsertModeActive);

            classroom.PrintClassroom();
        }

        public static bool IsValidPersonInput(string input) => input.Split(" ").Length >= 7 || !input.Contains("(") 
                                                                                            || !input.Contains("[") 
                                                                                            || input.IndexOf("(") == 0 
                                                                                            || input.IndexOf("[") == 0;        
    }
}