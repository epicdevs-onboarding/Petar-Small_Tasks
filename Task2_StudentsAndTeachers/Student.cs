using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Student : Person
    {
        private const string _gradeRegex = "[A - D][+-]?|F";
        private string _grade;
        public int Id { get; set; }

        public string Grade
        {
            get { return _grade; }
            set { if (Regex.Match(value, _gradeRegex).Success)
                    _grade = value;
                  else
                    _grade = "Too ugly to read"; }
        }

        public override string ToString()
        {
            return $"{base.FirstName} {base.LastName} {base.Age} years old - Grade: {_grade} - Guid: {base.GuidIdentifier.ToString()}";
        }

        
    }
}
