using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;

namespace Task2_StudentsAndTeachers.Services
{
    internal class JsonService : GenericService
    {
        public JsonService(Classroom classroom) : base(classroom)
        {
        }

        public void PrintClassroomInJson()
        {
            var classRoomJson = JsonConvert.SerializeObject(Classroom);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"InputOutputFiles\", "output.json"), classRoomJson);
        }
    }
}
