using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.GameElements
{
    internal class Game
    {
        private const string DEAULT_BOT_NAME = "Computer";

        public bool HaveBot { get; set; }
        public Player Player1 { get; init; }
        public Player Player2 { get; init; }
        public Player CurrentPlayer { get; set; }
        public Player NextPlayer { get; set; }
        public Log Log { get; set; }
        public int NumberOfTurns { get; set; }

        public Game(string name1, string name2) //Player vs. Player
        { 
            Player1 = new HumanPlayer(name1);
            Player2 = new HumanPlayer(name2);
            Log = new Log();
            NumberOfTurns = 0;
            HaveBot = false;
        }
        
        public Game(string humanName) //Player vs. Comupter
        {
            Player1 = new HumanPlayer(humanName);
            Player2 = new BotPlayer(DEAULT_BOT_NAME);
            Log = new Log();
            NumberOfTurns = 0;
            HaveBot = true;
        }

        public void Play()
        {
            CurrentPlayer.Board.PrintWholeBoard();
            if (NumberOfTurns == 0)
            {
                CurrentPlayer.PlacingShipsPhase();
                PrintTransitionScreen();
                PassTurn();
            }
            else
            {
                Turn turn = new Turn(CurrentPlayer);
                CurrentPlayer.Strike(NextPlayer);

                turn.End();
                NumberOfTurns++;
                Log.Add(turn);

                if (NextPlayer.HasLost())
                {
                    PrintFinalScreen();
                }
                else
                {
                    PassTurn();
                    PrintTransitionScreen();
                }
            }
        }

        public void PrintTransitionScreen()
        {
            Console.Clear();
            Console.WriteLine($"******************** {CurrentPlayer.Name} please let {NextPlayer.Name} conduct his turn! ******************** \n");
            Console.WriteLine($"{NextPlayer.Name}, press a key to begin!");
            Console.ReadKey();
        }

        public void PrintFinalScreen()
        {
            Console.Clear();
            Console.WriteLine("                         *******************************");
            Console.WriteLine("                             ***********************    ");
            Console.WriteLine("                                 ***************        ");
            Console.WriteLine($"Congratulations {CurrentPlayer.Name}! You have won the game of Battleships against {NextPlayer.Name}!");
            Console.WriteLine("                                 ***************        ");
            Console.WriteLine("                             ***********************    ");
            Console.WriteLine("                         *******************************\n");
            Console.ReadKey();
            return;
        }

        public void DecideStartingPlayer()
        {
            Random r = new Random();
            List<Player> list = new List<Player> { Player1, Player2};
            CurrentPlayer = list[r.Next(0, 2)];

            if (CurrentPlayer.Equals(Player1))
                NextPlayer = Player2;
            else
                NextPlayer = Player1;

            Console.WriteLine($"{CurrentPlayer.Name} starts the game!");
            Console.WriteLine($"{CurrentPlayer.Name}, press a key to begin!");
            Console.ReadKey();
        }

        public void PassTurn()
        {
            Player temp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = temp;
            Console.Clear();
        }
    }
}
