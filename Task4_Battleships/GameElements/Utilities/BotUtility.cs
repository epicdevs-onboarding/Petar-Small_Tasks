using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;

namespace Task4_Battleships.GameElements.Utilities
{
    internal class BotUtility : GenericUtility, IUtility
    {
        public Tuple<int, int> ShipCoordinates { get; set; }
        public Tuple<int, int> StrikeCoordinates { get; set; }
        public bool IsVertical { get; set; }

        private GameBoard Board { get; set; }

        public void TakeShipInput()
        {
            Board = new GameBoard();
            Random r = new Random();
            int height = r.Next(1, Board.HEIGHT);
            int width = r.Next(1, Board.WIDTH);
            ShipCoordinates = new Tuple<int, int>(height, width);
            IsVertical = r.NextDouble() > 0.5;
        }

        public void TakeStrikeInput()
        {
            Random r = new Random();
            int height = r.Next(1, Board.HEIGHT);
            int width = r.Next(1, Board.WIDTH);
            StrikeCoordinates = new Tuple<int, int>(height, width);
        }
    }
}
