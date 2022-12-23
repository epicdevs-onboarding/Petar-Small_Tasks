using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.Exceptions;
using Task4_Battleships.GameElements.Players;
using Task4_Battleships.GameElements.Utilities;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Ship> StartingShips { get; set; }
        public List<Ship> AvailableShips { get; set; }
        public GameBoard Board { get; set; }
        public IUtility InputUtility { get; set; }

        public Player(string name)
        {
            Name = name;
            StartingShips = new List<Ship>
            {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Cruiser(),
                new Destroyer()
            };
            Board = new GameBoard();
            AvailableShips = new List<Ship>();
            InputUtility = new InputUtility();
        }

        protected bool IsOverlappingShips(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            bool hasOverlap = false;
            foreach (BoardSquare sq in Board.DefendingSide)
            {
                if (!isVertical && sq.IsShip
                                && ((sq.Coordinate.Item2 == coordinates.Item2)
                                && (sq.Coordinate.Item1 >= coordinates.Item1
                                && sq.Coordinate.Item1 < coordinates.Item1 + ship.Length))) // horizontal
                {
                    hasOverlap = true;
                }
                else if (isVertical && sq.IsShip
                                    && ((sq.Coordinate.Item1 == coordinates.Item1)
                                    && (sq.Coordinate.Item2 >= coordinates.Item2
                                    && sq.Coordinate.Item2 < coordinates.Item2 + ship.Length))) // vertical
                {
                    hasOverlap = true;
                }
            }
            return hasOverlap;
        }

        protected bool IsOutOfBounds(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (isVertical && coordinates.Item2 + ship.Length > Board.HEIGHT + 1)
                return true;
            else if (!isVertical && coordinates.Item1 + ship.Length > Board.WIDTH + 1)
                return true;

            return false;
        }
    }
}
