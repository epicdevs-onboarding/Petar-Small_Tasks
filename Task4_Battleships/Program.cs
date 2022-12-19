using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.GameElements;

namespace Task4_Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game battleships = new Game("Viktor", "Pesho");
            /*
            GameBoard board = new GameBoard();
            foreach (BoardSquare sq in board.DefendingSide)
            {
                Console.WriteLine("{" + sq.Coordinate.Item1 + ", " + sq.Coordinate.Item2 + "}");
            }
            */
            battleships.DecideStartingPlayer();

            while (true)
            {
                battleships.Play();
            }
        }
    }
}
