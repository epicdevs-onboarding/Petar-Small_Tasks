using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal class Carrier : Ship
    {
        public Carrier() 
        {
            Name = "Aircraft Carrier";
            BoardLetter = "A";
            Length = 5;
        }
    }
}
