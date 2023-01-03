using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.Exceptions;
using Task4_Battleships.GameElements.Players;
using Task4_Battleships.GameElements.Utilities;

namespace Task4_Battleships.GameElements
{
    internal class Game
    {
        private const string DEAULT_BOT_NAME = "Computer";

        public bool HaveBot { get; set; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IPlayer NextPlayer { get; set; }
        public Log Log { get; set; }
        public int NumberOfTurns { get; set; }
        public ExceptionHandler ExceptionHandler { get; set; }

        public Game()
        {
            Log = new Log();
            NumberOfTurns = -1;
            HaveBot = false;
            ExceptionHandler = new ExceptionHandler();
        }

        public void Play()
        {
            CurrentPlayer.Board.PrintWholeBoard();
            if (NumberOfTurns < 1)
            {
                CurrentPlayer.PlacingShipsPhase();
                PrintTransitionScreen();
                NumberOfTurns++;
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
                    PrintFinalScreen();
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
            Console.ReadLine();

            Console.WriteLine("End game boards...");
            Console.WriteLine($"{NextPlayer.Name}'s board:");
            NextPlayer.Board.PrintDefendingSide();
            Console.WriteLine($"{CurrentPlayer.Name}'s board:");
            CurrentPlayer.Board.PrintDefendingSide();
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void DecideStartingPlayer()
        {
            Random r = new Random();
            List<IPlayer> list = new List<IPlayer> { Player1, Player2};
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
            IPlayer temp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = temp;
            Console.Clear();
        }

        public void Start()
        {
            int mode;
            string input;
            do
            {
                Console.WriteLine("*************************   Welcome to Battleships!   *************************");
                Console.WriteLine("Please choose gamemode:");
                Console.WriteLine("-----------------------");
                Console.WriteLine("(1) Player vs. Player");
                Console.WriteLine("(2) Player vs. AI");
                input = Console.ReadLine();
                if (!int.TryParse(input.Trim(), out mode) && (mode != 1 || mode != 2))
                {
                    Console.WriteLine("Invalid input! Pleace enter a valid mode!");
                }
            } while (!int.TryParse(input.Trim(), out mode) && (mode != 1 || mode != 2));
            
            switch (mode)
            {
                case 1 : GamemodeOnlyHuman(); break;
                case 2 : GamemodeHumanVsComputer(); break;
                default: Start(); break;
            }
            Console.WriteLine("The game will decide automaticaly who will start first...");
            DecideStartingPlayer();
        }

        public void GamemodeOnlyHuman()
        {
            Console.Write("Enter the first player's name: ");
            string firstPlayerName = Console.ReadLine();
            Console.Write("Enter the second player's name: ");
            string secondPlayerName = Console.ReadLine();
            Player1 = new HumanPlayer(firstPlayerName);
            Player2 = new HumanPlayer(secondPlayerName);
        }

        public void GamemodeHumanVsComputer()
        {
            Console.Write("Enter player's name: ");
            string playerName = Console.ReadLine();
            Player1 = new HumanPlayer(playerName);
            Player2 = new BotPlayer(DEAULT_BOT_NAME);
        }
    }
}
