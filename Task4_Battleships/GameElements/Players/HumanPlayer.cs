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

        public void PrintTransitionScreen(IPlayer opponent)
        {
            Console.Clear();
            Console.WriteLine($"******************** {Name} please let {opponent.Name} conduct his turn! ******************** \n");
            if (opponent is BotPlayer)
            {
                return;
            }
            else
            {
                Console.WriteLine($"{opponent.Name}, press a key to begin!");
                Console.ReadKey();
            }
        }

        public void Wait()
        {
            Console.ReadKey();
        }
    }
}
