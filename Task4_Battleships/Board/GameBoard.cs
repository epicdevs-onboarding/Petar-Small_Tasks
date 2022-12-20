﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        public readonly ConsoleColor FRAME_COLOR = ConsoleColor.Cyan;
        public readonly ConsoleColor SHIP_COLOR = ConsoleColor.Blue;
        public readonly ConsoleColor DEF_HIT_COLOR = ConsoleColor.Red;
        public readonly ConsoleColor DEF_MISS_COLOR = ConsoleColor.Green;
        public readonly ConsoleColor ATK_HIT_COLOR = ConsoleColor.Green;
        public readonly ConsoleColor ATK_MISS_COLOR = ConsoleColor.Red;

        public List<BoardSquare> AttackingSide { get; set; }
        public List<BoardSquare> DefendingSide { get; set; }

        public GameBoard()
        {
            AttackingSide = BoardCreation();
            DefendingSide = BoardCreation();
        }

        public void PrintWholeBoard()
        {
            Console.Clear();
            PrintSide(AttackingSide, false);
            Console.WriteLine();
            PrintSide(DefendingSide, true);
        }

        private void PrintSide(List<BoardSquare> side, bool isDefendingSide)
        {
            Console.Write("   ");
            foreach (string letter in Enum.GetNames(typeof(CoordinateLiteral))) // prints the letter coordinate frame
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(letter + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            int numberFrameIdx = 1;
            foreach (BoardSquare square in side)
            {
                if (square.Coordinate.Item1 == 0 && square.Coordinate.Item2 == 0) // prints the number coordinate frame
                {
                    if (numberFrameIdx > 9)
                    {
                        Console.ForegroundColor = FRAME_COLOR;
                        Console.Write($"{numberFrameIdx++} ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }  
                    else
                    {
                        Console.ForegroundColor = FRAME_COLOR;
                        Console.Write($"{numberFrameIdx++}  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (square.IsShip)
                {
                    if (isDefendingSide)
                        Console.ForegroundColor = square.Icon == 'x' ?  DEF_HIT_COLOR : SHIP_COLOR;
                    else
                        Console.ForegroundColor = square.Icon == 'x' ? ATK_HIT_COLOR : ConsoleColor.White;
                    Console.Write(square + " ");
                    if (square.Coordinate.Item2 >= WIDTH)
                        Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    if (isDefendingSide)
                        Console.ForegroundColor = square.Icon == '-' ? DEF_MISS_COLOR : ConsoleColor.White;
                    else    
                        Console.ForegroundColor = square.Icon == '-' ? ATK_MISS_COLOR : ConsoleColor.White;
                    Console.Write(square + " ");
                    if (square.Coordinate.Item2 >= WIDTH)
                        Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
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
                        board.Add(new BoardSquare(0, 0)); 
                        continue;
                    }
                    else if (j == 0)
                        board.Add(new BoardSquare(0, 0)); 
                    else
                        board.Add(new BoardSquare(Convert.ToChar((CoordinateLiteral)i), j)); 
                }
            }
            return board;
        }
    }
}
