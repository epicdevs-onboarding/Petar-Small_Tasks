using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;

namespace Task2_StudentsAndTeachers.Services
{
    internal class GenericService
    {
        protected Classroom Classroom { get; set; }

        protected GenericService(Classroom classroom)
        {
            Classroom = classroom;
        }
    }
}
