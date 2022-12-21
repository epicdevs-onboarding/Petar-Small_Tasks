using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal class Battleship : Ship
    {
        public Battleship() 
        {
            Name = "Battleship";
            BoardLetter = "B";
            Length = 4;
        }
    }
}
