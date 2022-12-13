using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;
using Task2_StudentsAndTeachers.Models;

namespace Task2_StudentsAndTeachers.Services
{
    internal class PersonService : GenericService
    {
        public PersonService(Classroom classroom) : base(classroom)
        {
        }

        public string GetSubstringByString(string a, string b, string c) => c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);

        public void ExtractFullNameAndLastName(string[] splitInput, Person person)
        {
            int ageIdx = splitInput
                .Select((line, index) => new {line, index})
                .Where(word => Regex.IsMatch(word.line, "\\[.*?\\]"))
                .Select(word => word.index + 1)
                .First();

            int roleIdx = splitInput
                .Select((line, index) => new {line, index})
                .Where(word => Regex.IsMatch(word.line, "\\(.*?\\)"))
                .Select(word => word.index + 1)
                .First();

            int lastNameIdx = Math.Max(roleIdx, ageIdx) - 2;

            if (!splitInput[lastNameIdx].Equals(person.FirstName))
            {
                person.LastName = splitInput[lastNameIdx];
                StringBuilder fullName = new StringBuilder();
                for (int i = 0; i < lastNameIdx + 1; i++)
                {
                    fullName.Append($"{splitInput[i]} ");
                }
                person.FullName = fullName.ToString().TrimEnd();
            }
            else
                person.FullName = person.FirstName;
        }

        public bool AssignDetailsSuccessful(string inputString, Person person)
        {
            string[] splitInput = inputString.Split(" ");

            if (splitInput.Length <= InputService.SPECIAL_INPUT_FIELDS + InputService.MAX_NAMES)
            {
                person.FirstName = splitInput[0];
                ExtractFullNameAndLastName(splitInput, person);
                person.RoleTitle = new Role();
                person.RoleTitle.DerriveFieldsFromInput(inputString);
                person.Age = Convert.ToInt32(GetSubstringByString(InputService.OPEN_BRACKET_AGE, InputService.CLOSE_BRACKET_AGE, inputString));
                return true;
            }
            return false;
        }
    }
}
