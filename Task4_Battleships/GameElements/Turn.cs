using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_Battleships.GameElements.Players;

namespace Task4_Battleships.GameElements
{
    internal class Turn
    {
        public int Number { get; set; }
        public string PlayerName { get; set; }
        public TimeSpan Duration { get; set; }
        public Tuple<char, int> StrikedSquare { get; set; }
        public bool IsHit { get; set; }
        public Stopwatch Stopwatch { get; set; }

        public Turn(IPlayer player)
        {
            PlayerName = player.Name;
            Stopwatch = Stopwatch.StartNew();
        }

        public void End()
        {
            Stopwatch.Stop();
            Duration = Stopwatch.Elapsed;
        }
    }
}
