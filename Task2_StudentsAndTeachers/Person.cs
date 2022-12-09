using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_StudentsAndTeachers
{
    internal class Person
    {
        private const int MIN_AGE = 18;
        private const int MAX_AGE = 65;

        private const int MAX_NAMES = 5;
        private const int SPECIAL_INPUT_FIELDS = 2;
        
        private const string OPEN_BRACKET_AGE = "[";
        private const string CLOSE_BRACKET_AGE = "]";
        private const string OPEN_BRACKET_ROLE = "(";
        private const string CLOSE_BRACKET_ROLE = ")";

        public Guid GuidIdentifier { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role RoleTitle { get; set; }
        public Classroom Classroom { get; set; }
        private int _age;


        public Person()
        {
            GuidIdentifier = Guid.NewGuid();
        }

        public int Age
        { 
            set 
            {   
                if (value >= MIN_AGE && value <= MAX_AGE)
                    _age = value;
                else
                    Console.WriteLine($"Invalid age! Age must be in the {MIN_AGE}-{MAX_AGE} range!");
            } 
            get { return _age; } 
        }

        public void SetFields(string fullName, string firstName, string lastName, int age)
        {
            FullName = fullName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public bool AssignDetailsSuccessful(string inputString)
        {
            string[] splitInput = inputString.Split(" ");
            
            if (splitInput.Length <= SPECIAL_INPUT_FIELDS + MAX_NAMES)
            {
                FirstName = splitInput[0];
                ExtractFullNameAndLastName(splitInput);
                RoleTitle = new Role();
                RoleTitle.DerriveFieldsFromInput(inputString);     
                Age = Convert.ToInt32(GetSubstringByString(OPEN_BRACKET_AGE, CLOSE_BRACKET_AGE, inputString));
                return true;
            }
            return false;
        }

        public string GetSubstringByString(string a, string b, string c) => c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));

        private void ExtractFullNameAndLastName(string[] splitInput)
        {
            int roleIdx = 0; 
            int ageIdx = 0;
            for (int i = 0; i < splitInput.Length; i++) 
            {
                if (Regex.Match(splitInput[i], "\\[.*?\\]").Success)
                    ageIdx = i;
                else if (Regex.Match(splitInput[i], "\\(.*?\\)").Success)
                    roleIdx = i;
            }

            int lastNameIdx = Math.Max(roleIdx, ageIdx) - 2;
            if (!splitInput[lastNameIdx].Equals(FirstName))
            {
                LastName = splitInput[lastNameIdx];
                StringBuilder fullName = new StringBuilder();
                for (int i = 0; i < lastNameIdx + 1; i++)
                {
                    fullName.Append($"{splitInput[i]} ");
                }
                FullName = fullName.ToString().TrimEnd();
            }
            else
                FullName = FirstName;
        }
    }
}
