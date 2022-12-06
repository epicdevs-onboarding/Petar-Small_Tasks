using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Person
    {
        private string _fullName;
        private string _firstName;
        private string _lastName;
        private int _age; //18-65
        private string _role;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public virtual string FirstName
        {
            set { _firstName = value; }
            get { return _firstName; }
        }
        public virtual string LastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }
        public int Age
        { 
            set 
            {   
                if (value >= 18 && value <= 65)
                    _age = value;
                else
                {
                    Console.WriteLine("Invalid age! Age must be in the 18-65 range!");
                }
            } 
            get { return _age; } 
        }
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }

        public bool AssignDetailsSuccessful(string inputString)
        {
            string[] splitInput = inputString.Split(" ");
            _firstName = splitInput[0];
            if (splitInput.Length > 7)
            {
                return false;
            }
            for (int i = 0; i < splitInput.Length; i++)
            {
                if (int.TryParse(splitInput[i], out int age))
                { 
                    _age = age;
                    _lastName = splitInput[i-1];
                    _role = splitInput[i + 1].TrimStart('(').TrimEnd(')').ToLowerInvariant();
                    break;
                }
            }
            
            return true;
        }
    }
}
