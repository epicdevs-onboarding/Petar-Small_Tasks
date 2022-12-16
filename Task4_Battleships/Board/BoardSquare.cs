using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Ships;

namespace Task4_Battleships.Boards
{
    internal class BoardSquare
    {
        public Tuple<int, int> Coordinate { get; set; }
        public char Icon { get; set; }
        public bool IsShip { get; set; }
        public bool IsEmpty { get; set; }
        public Ship ShipSailing { get; set; }
        public bool IsStriked { get; set; }

        public BoardSquare(int letterIdx, int number)
        {
            Icon = 'o';
            IsEmpty = true;
            IsShip = false;
            IsStriked = false;
            Coordinate = Tuple.Create(letterIdx, number);
        }

        public void Strike()
        {
            IsStriked = true;
            if (IsShip)
                Icon = 'x';
            else if (IsEmpty)
                Icon = '-';
        }

        public override string ToString()
        {
            return Icon.ToString(); 
        }
    }
}
