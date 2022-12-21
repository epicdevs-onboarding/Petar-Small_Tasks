using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Exceptions
{
    internal class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string message) : base(message) { }

        public InvalidCoordinatesException() : base("Invalid coordinates!") { }
    }
}
