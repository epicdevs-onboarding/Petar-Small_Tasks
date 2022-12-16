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
                InputUtility.TakeShipInput();
                AvailableShips.Add(ship);
                PlaceSingleShip(ship, InputUtility.ShipCoordinates, InputUtility.IsVertical);
            }
        }

        public void Strike(GameBoard opponentBoard)
        {
            InputUtility.TakeStrikeInput();
            foreach (BoardSquare square in opponentBoard.DefendingSide)
            {
                if (square.Coordinate.Equals(InputUtility.StrikeCoordinates))
                {
                    square.Strike();
                    
                    Board.AttackingSide.Find(sq => sq.Coordinate.Equals(square.Coordinate)).Strike();
                }
            }
            // check for sunken ships -> update ship list
        }

        public void PlaceSingleShip(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (!IsOverlappingShips(ship, coordinates, isVertical) || !IsOutOfBounds(ship, coordinates, isVertical))
            {
                foreach (BoardSquare sq in Board.DefendingSide)
                {
                    if (isVertical)
                    {
                        if (sq.Coordinate.Item1 == coordinates.Item1 && 
                            sq.Coordinate.Item2 >=coordinates.Item2 || 
                            sq.Coordinate.Item2 <= coordinates.Item2 + ship.Length)
                        {
                            sq.IsShip = true;
                            sq.Icon = Convert.ToChar(ship.BoardLetter);
                        }
                    }
                    else if (!isVertical)
                    {
                        if (sq.Coordinate.Item2 == coordinates.Item2 &&
                            sq.Coordinate.Item1 >= coordinates.Item1 ||
                            sq.Coordinate.Item1 <= coordinates.Item1 + ship.Length)
                        {
                            sq.IsShip = true;
                            sq.Icon = Convert.ToChar(ship.BoardLetter);
                        }
                    }
                }
            }
            else
                throw new InvalidShipPlacementException("The ship is overlapping another one or is out of bounds!");
        }

        private bool IsOverlappingShips(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (isVertical)
            {
                var result = Board.DefendingSide
                    .Select(sq => coordinates.Item1 == sq.Coordinate.Item1 && 
                                 (coordinates.Item2 >= sq.Coordinate.Item2 || 
                                  coordinates.Item2 <= sq.Coordinate.Item2) &&
                                  sq.IsEmpty).ToList();
                if (result.Any() || result == null)
                    return false;
                
                return true;
            }
            else if (!isVertical)
            {
                var result = Board.DefendingSide
                    .Select(sq => coordinates.Item2 == sq.Coordinate.Item2 &&
                                 (coordinates.Item1 >= sq.Coordinate.Item1 ||
                                  coordinates.Item1 <= sq.Coordinate.Item1) &&
                                  sq.IsEmpty).ToList();
                if (result.Any() || result == null)
                    return false;
                
                return true;
            }
            return false;
        }

        private bool IsOutOfBounds(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            if (isVertical)
                return ship.Length > Board.HEIGHT - coordinates.Item2;
            else if (!isVertical)
                return ship.Length > Board.WIDTH - coordinates.Item1;
            
            return false;
        }
    }
}
