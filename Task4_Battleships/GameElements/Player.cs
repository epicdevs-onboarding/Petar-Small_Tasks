using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Ship> AvailableShips { get; set; }
        public GameBoard Board { get; set; }
        public InputUtility InputUtility { get; set; }

        public Player(string name)
        {
            Name = name;
            AvailableShips = new List<Ship>
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
            return AvailableShips.Count == 0;
        }

        public void PlacingShipsPhase() //optimise move in class Game. Make abstract to work with bot and human
        {
            foreach (Ship ship in AvailableShips)
            {
                InputUtility.TakeShipInput();
                PlaceSingleShip(ship, InputUtility.ShipCoordinates, InputUtility.IsVertical);
            }
        }

        public void Strike(Tuple<char, int> coordinates)
        {
            // place pin on attacking board -> hit/miss/sink
        }

        public void PlaceSingleShip(Ship ship, Tuple<char, int> coordinates, bool isVertical)
        {
            // check if overlaps another ship
            // check if it is out of bounds
            // place corresponding ship on the deffending board
        }
    }
}
