using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;
using Task2_StudentsAndTeachers.Models;

namespace Task2_StudentsAndTeachers.Services
{
    internal class InputService : GenericService
    {
        public const string OPEN_BRACKET_AGE = "[";
        public const string CLOSE_BRACKET_AGE = "]";
        public const string OPEN_BRACKET_ROLE = "(";
        public const string CLOSE_BRACKET_ROLE = ")";
        public const int SPECIAL_INPUT_FIELDS = 2;
        public const int MAX_NAMES = 5;

        public InputService(Classroom classroom) : base(classroom)
        {
        }

        public void ReadInputFile()
        {
            bool hasTeacher = false;
            int inputCount = 0;
            string file = "input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"InputOutputFiles\", file);
            string[] inputArr = File.ReadAllLines(path);
            
            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                string inputString = inputArr[i];
                if (!IsValidPersonInput(inputString))
                {
                    Console.WriteLine("Invalid person input! Check if you typed all required fields!");
                    inputCount++;
                    continue;
                }
                
                Person person = new Person();
                person.PersonService = new PersonService(Classroom);

                if (person.PersonService.AssignDetailsSuccessful(inputString, person))
                {
                    if (person.RoleTitle.Id == (int)Role.Title.Student)
                    {
                        Student student = new Student();
                        student.SetFields(person.FullName, person.FirstName, person.LastName, person.Age);
                        student.Grade = inputArr[++i];
                        i--;
                        Classroom.AddStudent(student);
                    }
                    else if (person.RoleTitle.Id == (int)Role.Title.Teacher && hasTeacher == false)
                    {
                        Classroom.Teacher.SetFields(person.FullName, person.FirstName, person.LastName, person.Age);
                        Classroom.Teacher.Specialty = inputArr[++i];
                        i--;
                        hasTeacher = true;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input for person {++i}");
                    i--;
                }
                    

            }
        }
        public bool IsValidPersonInput(string input)
            => input.Split(" ").Length <= MAX_NAMES + SPECIAL_INPUT_FIELDS 
                                            && input.Contains(OPEN_BRACKET_ROLE)
                                            && input.Contains(OPEN_BRACKET_AGE)
                                            && input.IndexOf(OPEN_BRACKET_ROLE) != 0
                                            && input.IndexOf(OPEN_BRACKET_AGE) != 0;
    }
}
