using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Exceptions
{
    internal class InvalidShipPlacementException : Exception
    {
        public InvalidShipPlacementException(string message) : base(message) { }

        public InvalidShipPlacementException() : base("Invalid ship placement!") { }
    }
}
