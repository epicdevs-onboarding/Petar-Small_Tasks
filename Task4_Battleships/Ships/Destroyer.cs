using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal class Destroyer : Ship
    {
        public Destroyer() 
        {
            Name = "Destroyer";
            BoardLetter = "D";
            Length = 2;
        }
    }
}
