using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace Task1_ArrayMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int maxValue, arrLength;
            string input1, input2, input3;
            do
            {
                Console.WriteLine("Enter length of the arrays (max. 20): ");
                input1 = Console.ReadLine();
                if (!int.TryParse(input1, out arrLength) || Convert.ToInt32(input1) > 20)
                {
                    Console.WriteLine("Please enter a valid number!");

                }
            } while (!int.TryParse(input1, out arrLength));

            do
            {
                Console.WriteLine("Enter maximum possible value for the array elements: ");
                input2 = Console.ReadLine();
                if (!int.TryParse(input2, out maxValue))
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            } while (!int.TryParse(input2, out maxValue));

            int roundingOption;
            do
            {
                Console.WriteLine("Choose a desired rounding option for the results: \n (1) ceiling() \n (2) floor() \n (3) Math.Round() ");
                input3 = Console.ReadLine();
                if (!int.TryParse(input3, out roundingOption) || !(roundingOption >= 1 && roundingOption <= 3))
                {
                    Console.WriteLine("Please enter a valid number between 1 and 3!");
                }
            } while (!int.TryParse(input3, out roundingOption) || !(roundingOption >=1 && roundingOption <= 3));
            
            int[] intArray = GenerateRandomIntArr(arrLength, maxValue);
            decimal[] decimalArray = GenerateRandomDecimalArr(arrLength, maxValue);
            
            PrintReadableExpression(intArray, decimalArray, roundingOption);
        }

        static int[] GenerateRandomIntArr(int elemCount, int maxValue)
        {
            int[] intArray = new int[elemCount];
            Random r = new Random();
            for (int i = 0; i < elemCount; i++)
            {
                intArray[i] = r.Next(maxValue);
            }
            return intArray;
        }
        static decimal[] GenerateRandomDecimalArr(int elemCount, int maxValue)
        {
            decimal[] decimalArray = new decimal[elemCount];
            Random r = new Random();
            for (int i = 0; i < elemCount; i++)
            {
                decimalArray[i] = Math.Round(Convert.ToDecimal(r.NextDouble()) * maxValue, 3);
            }
            return decimalArray;
        }

        static decimal RoundFloor(decimal d)
        {
            string dString = d.ToString();
            string rounded = dString.TrimEnd(dString[dString.Length - 1]);
            return Convert.ToDecimal(rounded);
        }

        static decimal RoundCeiling(decimal d)
        {
            return RoundFloor(d) + 0.01m;
        }
        static void PrintReadableExpression(int[] intArr, decimal[] decimalArr, int roundingOption)
        {
            for (int i = 0; i < intArr.Length; i++)
            {   
                if (roundingOption == 1)
                    Console.WriteLine($"{intArr[i]} x {decimalArr[i]} = {RoundCeiling(decimalArr[i] * intArr[i])}");
                else if (roundingOption == 2)
                    Console.WriteLine($"{intArr[i]} x {decimalArr[i]} = {RoundFloor(decimalArr[i] * intArr[i])}");
                else
                    Console.WriteLine($"{intArr[i]} x {decimalArr[i]} = {Math.Round(decimalArr[i] * intArr[i], 2)}");

            }
        }
    }
}