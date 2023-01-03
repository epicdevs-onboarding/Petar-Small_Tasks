using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;

namespace Task4_Battleships.GameElements.Utilities
{
    internal interface IUtility
    {
        Tuple<int, int> ShipCoordinates { get; set; }
        Tuple<int, int> StrikeCoordinates { get; set; }
        bool IsVertical { get; set; }
        Stack<BoardSquare> Targets { get; set; }

        void TakeShipInput();
        void TakeStrikeInput();
        void AddTargets(BoardSquare square, GameBoard opponentBoard);
    }
}
