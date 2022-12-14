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
            HaveBot = false;
        }
        
        public Game(string humanName) //Player vs. Comupter
        {
            Player1 = new HumanPlayer(humanName);
            Player2 = new BotPlayer(DEAULT_BOT_NAME);
            Log = new Log();
        }

        public void Play()
        {
            Turn turn = new Turn(CurrentPlayer);



            // ... turn logic ...

            turn.End();
            NumberOfTurns++;
            Log.Add(turn);
            if (NextPlayer.HasLost())
            {
                PrintFinalScreen();
                return;
            }
            else
            {
                PassTurn();
                PrintTransitionScreen();
            }
                
        }

        public void PrintTransitionScreen()
        {
            Console.WriteLine($"******************** {CurrentPlayer.Name} please let {NextPlayer.Name} conduct his turn! ******************** \n");
        }

        public void PrintFinalScreen()
        {
            Console.WriteLine("                         *******************************");
            Console.WriteLine("                             ***********************    ");
            Console.WriteLine("                                 ***************        ");
            Console.WriteLine($"Congratulations {CurrentPlayer.Name}! You have won the game of Battleships against {NextPlayer.Name}!");
            Console.WriteLine("                                 ***************        ");
            Console.WriteLine("                             ***********************    ");
            Console.WriteLine("                         *******************************\n");

        }

        public void DecideStartingPlayer()
        {
            Random r = new Random();
            List<Player> list = new List<Player> { Player1, Player2};
            CurrentPlayer = list[r.Next(0, 1)];
        }

        public void PassTurn()
        {
            Player temp = new Player("");
            temp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = temp;
            Console.Clear();
        }
    }
}
