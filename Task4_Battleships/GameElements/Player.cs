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
        public GenericBoard Board { get; set; }



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
            Board = new GenericBoard();
        }

        public bool HasLost()
        {
            return AvailableShips.Count == 0;
        }

        public void PlaceShips()
        {

        }

        public void Strike(Tuple<char, int> coordinates)
        {

        }
    }
}
