using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Ships
{
    internal abstract class Ship
    {

        public string Name { get; init; }
        public string BoardLetter { get; init; }
        public int Length { get; init; }
        public int Hits { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Length;
            }
        }
    }
}
