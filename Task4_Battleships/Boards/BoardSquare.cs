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
        public Tuple<char, int> Coordinate { get; set; }
        public char Icon { get; set; }
        public bool IsShip { get; set; }
        public Ship ShipSailing { get; set; }
        public bool IsStriked { get; set; }

        public BoardSquare(char letter, int number)
        {
            Icon = 'o';
            IsShip = false;
            IsStriked = false;
            Coordinate = Tuple.Create(letter, number);
        }

        public override string ToString()
        {
            return Icon.ToString(); 
        }
    }
}
