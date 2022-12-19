using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.Exceptions;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Ship> StartingShips { get; set; }
        public List<Ship> AvailableShips { get; set; }
        public GameBoard Board { get; set; }
        public InputUtility InputUtility { get; set; }

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

        public bool HasLost()
        {
            return StartingShips.Count == 0;
        }

        public void PlacingShipsPhase()
        {
            foreach (Ship ship in StartingShips)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Placing the {ship.Name} which is {ship.Length} squares long...");
                Console.ForegroundColor = ConsoleColor.White;
                InputUtility.TakeShipInput();
                AvailableShips.Add(ship);
                
                PlaceSingleShip(ship, InputUtility.ShipCoordinates, InputUtility.IsVertical);
            }
            Console.WriteLine($"{Name}, all of your ships are placed! Press any key to pass turn...");
            Console.ReadKey();
        }

        public void Strike(Player opponent)
        {
            Console.Clear();
            InputUtility.TakeStrikeInput();
            foreach (BoardSquare square in opponent.Board.DefendingSide)
            {
                if (square.Coordinate.Equals(InputUtility.StrikeCoordinates))
                {
                    if (square.IsShip)
                    {
                        var strikedShip = opponent.AvailableShips.Where(ship => Convert.ToChar(ship.BoardLetter) == square.Icon).ToList();
                        strikedShip.ForEach(s => s.Hits++);
                        if (strikedShip.Any(s => s.IsSunk))
                        {
                            Console.WriteLine("Sunken ship!");
                        }
                        else
                        {
                            Console.WriteLine("Hit!");
                        }
                        square.Icon = square.HIT_CHAR;
                    }
                    else if (square.IsEmpty)
                    {
                        Console.WriteLine("Miss!");
                        square.Icon = square.MISS_CHAR;
                    }
                    square.IsStriked = true;
                }
            }
            opponent.AvailableShips.RemoveAll(s => s.IsSunk);
        }

        public void PlaceSingleShip(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (!IsOverlappingShips(ship, coordinates, isVertical) && !IsOutOfBounds(ship, coordinates, isVertical))
            {
                foreach (BoardSquare sq in Board.DefendingSide)
                {
                    if (!isVertical && ((sq.Coordinate.Item1 == coordinates.Item2) 
                                    && (sq.Coordinate.Item2 >= coordinates.Item1
                                    && sq.Coordinate.Item2 < coordinates.Item1 + ship.Length)))// horizontal
                    {
                        sq.IsEmpty = false;
                        sq.IsShip = true;
                        sq.Icon = Convert.ToChar(ship.BoardLetter);
                    }
                    else if (isVertical && ((sq.Coordinate.Item2 == coordinates.Item1) 
                                        && (sq.Coordinate.Item1  >= coordinates.Item2 
                                        && sq.Coordinate.Item1 < coordinates.Item2 + ship.Length))) // vertical
                    {
                        sq.IsEmpty = false;
                        sq.IsShip = true;
                        sq.Icon = Convert.ToChar(ship.BoardLetter);
                    }
                }
            }
            else
                throw new InvalidShipPlacementException("The ship is overlapping another one or is out of bounds!");

            Board.PrintWholeBoard();
        }

        private bool IsOverlappingShips(Ship ship, Tuple<int, int> coordinates, bool isVertical) // todo fix check for ship overlap
        {
            if (isVertical)
            {
                bool hasOverlap = Board.DefendingSide
                    .Any(sq => ((sq.Coordinate.Item2 == coordinates.Item1)
                                && (sq.Coordinate.Item1 >= coordinates.Item2
                                && sq.Coordinate.Item1 <= coordinates.Item2 + ship.Length)));
                if (hasOverlap)
                    return false;
                
                return true;
            }
            else if (!isVertical)
            {
                bool hasOverlap = Board.DefendingSide
                    .Any(sq => ((sq.Coordinate.Item1 == coordinates.Item2)
                                && (sq.Coordinate.Item2 >= coordinates.Item1
                                && sq.Coordinate.Item2 <= coordinates.Item1 + ship.Length)));
                if (hasOverlap)
                    return false;
                
                return true;
            }
            return false;
        }

        private bool IsOutOfBounds(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (isVertical && coordinates.Item2 + ship.Length > Board.HEIGHT + 1)
                return true;
            else if (!isVertical && coordinates.Item1 + ship.Length > Board.WIDTH + 1)
                return true;
            
            return false;
        }
    }
}
