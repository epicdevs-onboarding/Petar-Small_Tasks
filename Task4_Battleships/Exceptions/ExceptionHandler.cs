using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Battleships.Exceptions
{
    internal class ExceptionHandler
    {
        public void HandleException(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Please try again!");
        }
    }
}
