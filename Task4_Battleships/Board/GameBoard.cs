using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.GameElements;

namespace Task4_Battleships.Boards
{
    internal class GameBoard
    {
        public readonly int WIDTH = 10;
        public readonly int HEIGHT = 10;

        public List<BoardSquare> AttackingSide { get; set; }
        public List<BoardSquare> DefendingSide { get; set; }

        public GameBoard()
        {
            AttackingSide = BoardCreation();
            DefendingSide = BoardCreation();
        }

        public void PrintWholeBoard()
        {
            PrintSide(AttackingSide);
            Console.WriteLine();
            PrintSide(DefendingSide);
        }

        private void PrintSide(List<BoardSquare> side)
        {
            Console.Write("   ");
            foreach (string letter in Enum.GetNames(typeof(CoordinateLiteral))) 
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
            foreach (BoardSquare square in side)
            {
                if (square.Coordinate.Item1 == 0 && square.Coordinate.Item2 == 0)
                    Console.Write(" ");
                else if (square.Coordinate.Item1 == 0)
                {
                    if (square.Coordinate.Item2 == WIDTH)
                        Console.Write(square.Coordinate.Item2 + " ");
                    else
                        Console.Write(square.Coordinate.Item2 + "  ");
                }
                else
                {
                    Console.Write(square + " ");
                    if (square.Coordinate.Item2 >= WIDTH)
                        Console.WriteLine();
                }
            }
        }

        private List<BoardSquare> BoardCreation()
        {
            List<BoardSquare> board = new List<BoardSquare>();
            for (int i = 1; i <= WIDTH; i++)
            {
                for (int j = 0; j <= HEIGHT; j++)
                {
                    if (i == 1 && j == 0)
                    {
                        board.Add(new BoardSquare(0, i)); 
                        continue;
                    }
                    else if (j == 0)
                        board.Add(new BoardSquare(0, i)); 
                    else
                        board.Add(new BoardSquare(Convert.ToChar((CoordinateLiteral)i), j)); 
                }
            }
            return board;
        }
    }
}
