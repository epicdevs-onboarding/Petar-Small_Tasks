using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Boards;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements.Players
{
    internal interface IPlayer
    {
        GameBoard Board { get; set; }
        string Name { get; set; }
        List<Ship> AvailableShips { get; set; }

        public void PlacingShipsPhase();
        public void PlaceSingleShip(Ship ship, Tuple<int, int> coordinates, bool isVertical);
        public void Strike(IPlayer player);

        bool HasLost()
        {
            return AvailableShips.Count == 0;
        }
    }
}
