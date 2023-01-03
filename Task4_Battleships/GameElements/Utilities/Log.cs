using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.GameElements.Utilities
{
    internal class Log
    {
        public List<Turn> turns;

        public Log()
        {
            turns = new List<Turn>();
        }

        public void Add(Turn turn)
        {
            turns.Add(turn);
        }
    }
}
