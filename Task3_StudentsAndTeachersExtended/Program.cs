using System.Collections.ObjectModel;
using System.IO.MemoryMappedFiles;
using System.Reflection.Metadata.Ecma335;
using Task2_StudentsAndTeachers.Models;
using Task2_StudentsAndTeachers.Services;
using Task2_StudentsAndTeachers.Database;

namespace Task2_StudentsAndTeachers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom();
            Teacher teacher = new Teacher();
            classroom.Teacher = teacher;

            InputService inputService = new InputService(classroom);
            JsonService jsonService = new JsonService(classroom);
            OutputService outputService = new OutputService(classroom, jsonService);
            PersonService personService = new PersonService(classroom);

            inputService.ReadInputFile();
            outputService.PrintClassroomInConsole();
            jsonService.PrintClassroomInJson();
        }

                
    }
}