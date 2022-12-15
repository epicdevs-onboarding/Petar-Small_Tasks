using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task4_Battleships.Exceptions;

namespace Task4_Battleships.GameElements
{
    internal class InputUtility
    {
        private const string KEYWORD_HORIZONTAL = "hor";
        private const string KEYWORD_VERTICAL = "ver";
        public Tuple<char, int> ShipCoordinates { get; set; }
        public Tuple<char, int> StrikeCoordinates { get; set; }
        public bool IsVertical { get; set; }

        public void TakeShipInput()
        {
            string input;
            do
            {
                Console.WriteLine($"Where do you want to put the ship? Vertical({KEYWORD_VERTICAL}) or horizontal({KEYWORD_HORIZONTAL})?");
                input = Console.ReadLine();

                if (!HasValidShipInput(input))
                    Console.WriteLine("Please enter the data formated correctly as following: <coordinates> (ver/hor)");

            } while (!HasValidShipInput(input));
            
            ShipCoordinates = ParseCoordinates(input);
            ParseOrientation(input);
        }

        public void TakeStrikeInput()
        {
            string input;
            do
            {
                Console.WriteLine($"Where do you want to strike your enemy?");
                input = Console.ReadLine();

            } while (!HasValidStrikeInput(input));

            StrikeCoordinates = ParseCoordinates(input);
        }

        private bool HasValidShipInput(string input)
        {
            if (Regex.Match(input, $"^[a-jA-J]([1-9]|10) ({KEYWORD_HORIZONTAL}|{KEYWORD_VERTICAL})$").Success)
                return true;

            return false;
        }

        private bool HasValidStrikeInput(string input)
        {
            if (Regex.Match(input, "^[a-jA-J]([1-9]|10)$").Success)
                return true;

            return false;
        }

        private Tuple<char, int> ParseCoordinates(string input)
        {
            char letter = Convert.ToChar(input.Substring(0, 1));
            int number;

            if (input.Length == 2)
                number = Convert.ToInt32(input.Substring(1, 1));
            else
                number = Convert.ToInt32(input.Substring(1, 2));

            return Tuple.Create(letter, number);
        }

        private bool ParseOrientation(string input)
        {
            if (input.IndexOf(KEYWORD_VERTICAL, StringComparison.OrdinalIgnoreCase) > -1)
                return true;
            else if (input.IndexOf(KEYWORD_HORIZONTAL, StringComparison.OrdinalIgnoreCase) > -1)
                return false;
            else
                throw new Exceptions.InvalidShipPlacementException("Wrong ship placement orientation!");
        }
    }
}
