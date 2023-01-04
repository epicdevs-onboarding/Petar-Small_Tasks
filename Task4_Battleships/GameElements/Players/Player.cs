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

        protected bool IsAlreadyStruck(IPlayer opponent, Tuple<int, int> coordinates)
        {
            bool isAlreadyStruck = false;
            foreach (BoardSquare sq in Board.AttackingSide)
            {
                if (sq.IsStriked && sq.Coordinate.Item1 == coordinates.Item1
                                 && sq.Coordinate.Item2 == coordinates.Item2)
                {
                    isAlreadyStruck = true;
                }
            }
            return isAlreadyStruck;
        }

        public void Strike(IPlayer opponent)
        {
            bool isHit = false;
            bool isMiss = true;
            bool isSink = false;
            InputUtility.TakeStrikeInput();

            foreach (BoardSquare sq in Board.AttackingSide)
            {
                if (sq.Icon != sq.DEFAULT_CHAR && sq.Coordinate.Equals(Tuple.Create(InputUtility.StrikeCoordinates.Item1, InputUtility.StrikeCoordinates.Item2)))
                {
                    throw new InvalidCoordinatesException("Make another try!");
                }
            }
            
            foreach (BoardSquare square in opponent.Board.DefendingSide)
            {
                if (square.Coordinate.Equals(Tuple.Create(InputUtility.StrikeCoordinates.Item1, InputUtility.StrikeCoordinates.Item2)))
                {
                    
                    if (square.IsShip)
                    {
                        foreach (BoardSquare squareAtk in Board.AttackingSide)
                        {
                            if (square.Coordinate.Equals(squareAtk.Coordinate))
                            {
                                squareAtk.IsShip = true;
                                squareAtk.Icon = squareAtk.HIT_CHAR;
                                isHit = true;
                                InputUtility.AddTargets(square, opponent.Board);
                                Board.PrintWholeBoard();
                            }
                        }
                        var targetShip = opponent.AvailableShips.Where(s => s.BoardLetter.First() == square.Icon).ToList();
                        targetShip.ForEach(s => s.Hits += 1);
                        square.Icon = square.HIT_CHAR;
                    }
                    else if (square.IsEmpty)
                    {
                        foreach (BoardSquare squareAtk in Board.AttackingSide)
                        {
                            if (square.Coordinate.Equals(squareAtk.Coordinate))
                            {
                                squareAtk.Icon = squareAtk.MISS_CHAR;
                                isMiss = true;
                                Board.PrintWholeBoard();
                            }
                        }
                        square.Icon = square.MISS_CHAR;
                    }
                    square.IsStriked = true;
                }
            }
            

            isSink = opponent.AvailableShips.Any(s => s.IsSunk);
            opponent.AvailableShips.RemoveAll(s => s.IsSunk);
            if (isHit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (isSink)
                    Console.WriteLine("You sank a ship!");
                else
                    Console.WriteLine("Hit!");

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Miss!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void PlaceSingleShip(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (IsOverlappingShips(ship, coordinates, isVertical))
                throw new InvalidShipPlacementException("The ship ovelaps another one! Mind the ship length when placing!");
            else if (IsOutOfBounds(ship, coordinates, isVertical))
                throw new InvalidShipPlacementException("The ship is outside of the field! Mind the ship length when placing!");

            foreach (BoardSquare sq in Board.DefendingSide)
            {
                if ((!isVertical && ((sq.Coordinate.Item2 == coordinates.Item2)
                                 && (sq.Coordinate.Item1 >= coordinates.Item1
                                 && sq.Coordinate.Item1 < coordinates.Item1 + ship.Length)))
                  || (isVertical && ((sq.Coordinate.Item1 == coordinates.Item1)
                                 && (sq.Coordinate.Item2 >= coordinates.Item2
                                 && sq.Coordinate.Item2 < coordinates.Item2 + ship.Length))))
                {
                    sq.IsEmpty = false;
                    sq.IsShip = true;
                    sq.Icon = Convert.ToChar(ship.BoardLetter);
                }
            }
            Board.PrintWholeBoard();
        }
    }
}
