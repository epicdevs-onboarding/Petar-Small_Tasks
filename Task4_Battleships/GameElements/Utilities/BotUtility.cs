using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;

namespace Task4_Battleships.GameElements.Utilities
{
    internal class BotUtility : IUtility
    {
        public Tuple<int, int> ShipCoordinates { get; set; }
        public Tuple<int, int> StrikeCoordinates { get; set; }
        public bool IsVertical { get; set; }
        public Stack<BoardSquare> Targets { get; set; }
        private GameBoard Board { get; set; }

        public void AddTargets(BoardSquare square, GameBoard opponentBoard)
        {
            foreach (BoardSquare sq in opponentBoard.DefendingSide)
            {
                if (!sq.IsStriked && (sq.Coordinate.Item1 == square.Coordinate.Item1
                                  && sq.Coordinate.Item2 == square.Coordinate.Item2 - 1)
                                  || (sq.Coordinate.Item1 == square.Coordinate.Item1
                                  && sq.Coordinate.Item2 == square.Coordinate.Item2 + 1)
                                  || (sq.Coordinate.Item1 - 1 == square.Coordinate.Item1
                                  && sq.Coordinate.Item2 == square.Coordinate.Item2)
                                  || (sq.Coordinate.Item1 + 1 == square.Coordinate.Item1
                                  && sq.Coordinate.Item2 == square.Coordinate.Item2))
                {
                    Targets.Push(sq);
                }
            }
        }

        public void TakeShipInput()
        {
            Targets = new Stack<BoardSquare>();
            Board = new GameBoard();
            Random r = new Random();
            int height = r.Next(1, Board.HEIGHT);
            int width = r.Next(1, Board.WIDTH);
            ShipCoordinates = new Tuple<int, int>(height, width);
            IsVertical = r.NextDouble() > 0.5;
        }

        public void TakeStrikeInput()
        {
            
            if (Targets.Any())
            {
                BoardSquare strikeTarget = Targets.Pop();
                StrikeCoordinates = new Tuple<int, int>(strikeTarget.Coordinate.Item1, strikeTarget.Coordinate.Item2);
            }
            else
            {
                Hunt();
            }
        }

        private void Hunt()
        {
            Random r = new Random();
            int height = r.Next(1, Board.HEIGHT);
            int width = r.Next(1, Board.WIDTH);
            StrikeCoordinates = new Tuple<int, int>(height, width);
        }
    }
}
