using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Teacher : Person
    {
        private string _speciality;

        public string Specialty
        {
            set { _speciality = value.Trim(); }
            get { return _speciality; }
        }

        public override string ToString()
        {
            return $"{base.FirstName} {base.LastName} - Speciality: {_speciality}";
        }
    }
}
