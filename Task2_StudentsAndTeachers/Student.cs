using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Student : Person
    {
        private string _grade;

        public string Grade
        {
            get { return _grade; }
            set { _grade = value.Trim(); }
        }

        public override string ToString()
        {
            return $"{base.FirstName} {base.LastName} {base.Age} years old - Grade: {_grade}";
        }
    }
}
