using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;
using Task2_StudentsAndTeachers.Models;

namespace Task2_StudentsAndTeachers.Services
{
    internal class OutputService : GenericService
    {
        public JsonService JsonService { get; set; }

        public OutputService(Classroom classroom, JsonService jsonService) : base(classroom)
        {
            JsonService = jsonService;
        }

        public void PrintClassroomInConsole()
        {
            Console.WriteLine("\n ===================== \n");
            if (Classroom.Teacher.FirstName != null)
                Console.WriteLine(Classroom.Teacher.ToString());
            else
                Console.WriteLine("This class has no teacher.");

            Console.WriteLine("*******");
            foreach (KeyValuePair<int, Student> entry in Classroom.StudentsDatabase)
            {
                Console.WriteLine(entry.Value.ToString());
            }
        }
    }
}
