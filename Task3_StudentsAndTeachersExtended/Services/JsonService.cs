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
            File.WriteAllText("D:\\onboarding-tasks\\Petar-Small_Tasks\\Task3_StudentsAndTeachersExtended\\InputOutputFiles\\output.json", classRoomJson);
        }
    }
}
