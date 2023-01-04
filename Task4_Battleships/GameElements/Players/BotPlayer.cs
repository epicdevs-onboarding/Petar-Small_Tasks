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
    internal class BotPlayer : Player, IPlayer
    {
        public BotPlayer(string name) : base(name)
        {
            InputUtility = new BotUtility();
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
        }

        public void PrintTransitionScreen(IPlayer opponent)
        {
            Console.Clear();
            Console.WriteLine($"******************** {Name} finished it's turn! ******************** \n");
            Console.WriteLine($"{opponent.Name}, press a key to begin!");
        }

        public void Wait()
        {
            return;
        }
    }
}
