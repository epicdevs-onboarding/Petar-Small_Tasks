using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Boards
{
    internal class GameBoard
    {
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        private enum CoordinateLiteral
        {
            A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9, J = 10
        }

        public List<BoardSquare> AttackingSide { get; set; }
        public List<BoardSquare> DefendingSide { get; set; }

        public GameBoard()
        {
            AttackingSide = new List<BoardSquare>();
            for (int i = 1; i <= WIDTH; i++)
            {
                for (int j = 0; j <= HEIGHT; j++)
                {
                    if ( i == 1 && j == 0)
                    {
                        AttackingSide.Add(new BoardSquare('-', i));
                        continue;
                    }
                    else if (j == 0)
                    {
                        BoardSquare boardSquare = new BoardSquare('-', i);
                        AttackingSide.Add(boardSquare);
                    }
                    else
                    {
                        BoardSquare square = new BoardSquare(Convert.ToChar((CoordinateLiteral)i), j);
                        AttackingSide.Add(square);
                    }
                    
                }
            }
            
            DefendingSide = new List<BoardSquare>();
            for (int i = 1; i <= WIDTH; i++)
            {
                for (int j = 0; j <= HEIGHT; j++)
                {
                    if (i == 1 && j == 0)
                    {
                        DefendingSide.Add(new BoardSquare('-', i));
                        continue;
                    }
                    else if (j == 0)
                    {
                        BoardSquare boardSquare = new BoardSquare('-', i);
                        DefendingSide.Add(boardSquare);
                    }
                    else
                    {
                        BoardSquare square = new BoardSquare(Convert.ToChar((CoordinateLiteral)i), j);
                        DefendingSide.Add(square);
                    }
                }
            }
        }

        public void PrintWholeBoard()
        {
            PrintSide(AttackingSide);
            Console.WriteLine();
            PrintSide(DefendingSide);
        }

        private void PrintSide(List<BoardSquare> side)
        {
            Console.WriteLine("   A B C D E F G H I J");
            foreach (BoardSquare square in side)
            {
                if (square.Coordinate.Item1 == '-' && square.Coordinate.Item2 == 0)
                    Console.Write(" ");
                else if (square.Coordinate.Item1 == '-')
                {
                    if (square.Coordinate.Item2 == 10)
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
    }
}
