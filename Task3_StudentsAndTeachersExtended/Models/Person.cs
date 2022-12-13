using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2_StudentsAndTeachers.Database;
using Task2_StudentsAndTeachers.Services;

namespace Task2_StudentsAndTeachers.Models
{
    internal class Person
    {
        private const int MIN_AGE = 18;
        private const int MAX_AGE = 65;

        public Guid GuidIdentifier { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public Role RoleTitle { get; set; }
        [JsonIgnore]
        public PersonService PersonService { get; set; }
        [JsonIgnore]
        public InputService InputService { get; set; }
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
    }
}
