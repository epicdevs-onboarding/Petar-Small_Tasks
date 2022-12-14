using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal class Cruiser : Ship
    {
        public Cruiser() 
        {
            Name = "Cruiser";
            BoardLetter = "C";
            Length = 3;
        }
    }
}
