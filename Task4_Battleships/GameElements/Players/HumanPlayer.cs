using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.Exceptions;
using Task4_Battleships.GameElements.Utilities;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements.Players
{
    internal class HumanPlayer : Player, IPlayer
    {
        public HumanPlayer(string name) : base(name)
        {
            InputUtility = new InputUtility();
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

        public void PlacingShipsPhase()
        {
            foreach (Ship ship in StartingShips)
            {
                bool hasException = false;
                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Placing the {ship.Name} which is {ship.Length} squares long...");
                        Console.ForegroundColor = ConsoleColor.White;
                        InputUtility.TakeShipInput();

                        PlaceSingleShip(ship, InputUtility.ShipCoordinates, InputUtility.IsVertical);
                        AvailableShips.Add(ship);
                        hasException = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (!hasException);
            }
            Console.WriteLine($"{Name}, all of your ships are placed! Press any key to pass turn...");
            Console.ReadKey();
        }

        public void Strike(IPlayer opponent)
        {
            bool isHit = false;
            bool isMiss = true;
            bool isSink = false;
            InputUtility.TakeStrikeInput();
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
            Console.ReadKey();
        }
    }
}
