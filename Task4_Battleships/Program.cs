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
            Game battleships = new Game("Pesho", "Viktor");
            GameBoard board = new GameBoard();
            board.PrintWholeBoard();
            //battleships.DecideStartingPlayer();
            
            //while (true)
            //{
            //    battleships.Play();
            //}
        }
    }
}
