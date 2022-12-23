using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.GameElements.Utilities
{
    internal interface IUtility
    {
        public Tuple<int, int> ShipCoordinates { get; set; }
        public Tuple<int, int> StrikeCoordinates { get; set; }
        public bool IsVertical { get; set; }

        void TakeShipInput();
        void TakeStrikeInput();
    }
}
