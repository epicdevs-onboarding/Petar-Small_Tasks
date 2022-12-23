using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Ships;

namespace Task4_Battleships.GameElements.Players
{
    internal class BotPlayer : Player, IPlayer
    {
        public BotPlayer(string name) : base(name)
        {
        }

        public void PlaceSingleShip(Ship ship, Tuple<int, int> coordinates, bool isVertical)
        {
            throw new NotImplementedException();
        }

        public void PlacingShipsPhase()
        {
            throw new NotImplementedException();
        }

        public void Strike(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
