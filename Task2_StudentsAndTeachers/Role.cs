using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Role
    {
        public enum Title
        {
            Student = 1,
            Teacher = 2
        }
        public int Id { set; get; }
        public string RoleName { set; get; }

        public void DerriveFieldsFromInput(string input)
        {
            if (input.IndexOf("teacher", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Id = (int) Title.Teacher;
                RoleName = Title.Teacher.ToString();
            }
            else if (input.IndexOf("student", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Id = (int) Title.Student;
                RoleName = Title.Student.ToString();
            }
            else
                Console.WriteLine("Invalid role!");
        }
    }
}
