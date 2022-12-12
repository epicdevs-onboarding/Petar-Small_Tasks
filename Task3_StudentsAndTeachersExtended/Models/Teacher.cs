using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers.Models
{
    internal class Teacher : Person
    {
        private string _speciality;

        public string Specialty
        {
            set { _speciality = value.Trim(); }
            get { return _speciality; }
        }

        public override string ToString() => $"{FirstName} {LastName} - Speciality: {_speciality}";
    }
}
