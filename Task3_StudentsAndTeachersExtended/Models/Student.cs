using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;

namespace Task2_StudentsAndTeachers.Models
{
    internal class Student : Person
    {
        public static int globalId;

        private string _grade;
        [JsonIgnore]
        public int Id { get; private set; }

        public Student()
        {
            Id = Interlocked.Increment(ref globalId);
            _grade = string.Empty;
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

        public override string ToString() => $"{FirstName} {LastName} {Age} years old - Grade: {_grade} - Guid: {GuidIdentifier.ToString()}";
    }
}
