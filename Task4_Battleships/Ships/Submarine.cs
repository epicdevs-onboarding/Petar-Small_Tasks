using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal class Submarine : Ship
    {
        public Submarine() 
        {
            Name = "Submarine";
            BoardLetter = "S";
            Length = 3;
        }
    }
}
