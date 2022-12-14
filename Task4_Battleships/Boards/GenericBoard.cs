using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Boards
{
    internal class GenericBoard
    {
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        private enum CoordinateLiteral
        {
            A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9, J = 10
        }

        public List<BoardSquare> Board { get; set; }

        public GenericBoard()
        {
            Board = new List<BoardSquare>();
            for (int i = 1; i <= WIDTH; i++)
            {
                for (int j = 1; j <= HEIGHT; j++)
                {
                    BoardSquare square = new BoardSquare(Convert.ToChar((CoordinateLiteral)i), j);
                    Board.Add(square);
                }
            }
        }

        public void Print()
        {
            foreach (BoardSquare square in Board)
            {
                Console.Write(square + " ");
                if (square.Coordinate.Item2 >= WIDTH)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
