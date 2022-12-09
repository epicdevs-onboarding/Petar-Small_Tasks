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
        private string _grade;
        public int Id { get; private set; }

        public static int globalId;

        public Student()
        {
            Id = Interlocked.Increment(ref globalId);
        }

        public string Grade
        {
            get { return _grade; }
            set 
            { 
                if (Regex.Match(value, "[ABCD][+-]?|F").Success)
                    _grade = value;
                else
                    _grade = "No grade"; 
            }
        }

        public override string ToString() => $"{base.FirstName} {base.LastName} {base.Age} years old - Grade: {_grade} - Guid: {base.GuidIdentifier.ToString()}";
    }
}
