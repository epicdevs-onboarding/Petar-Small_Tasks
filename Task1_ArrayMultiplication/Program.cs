using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace Task1_ArrayMultiplication
{
    internal class Program
    {
        const int DIGITS_AFTER_FLOATING_POINT = 2;
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

            RoundingOption option = new RoundingOption();
            do
            {
                Console.WriteLine("Choose a desired rounding option for the results: \n (1) Round the result to the higher number of the hundreds (Ceiling) " +
                                                                                    "\n (2) Round the result to the lower number of the hundreds (Floor) " +
                                                                                    "\n (3) Round the result to the nearest even number of the hundreds ");
                input3 = Console.ReadLine();
                if (!Enum.IsDefined(typeof(RoundingOption), Convert.ToInt32(input3)))
                {
                    Console.WriteLine("Please enter a valid number between 1 and 3!");
                }
            } while (!Enum.IsDefined(typeof(RoundingOption), Convert.ToInt32(input3)));

            option = (RoundingOption)Convert.ToInt32(input3);

            int[] intArray = GenerateRandomIntArr(arrLength, maxValue);
            decimal[] decimalArray = GenerateRandomDecimalArr(arrLength, maxValue);
            
            PrintReadableExpression(intArray, decimalArray, option);
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
                decimalArray[i] = Math.Round((decimal)r.NextDouble() * maxValue, 3);
            }
            return decimalArray;
        }

        static decimal RoundFloor(decimal d)
        {
            string dString = d.ToString();
            string rounded = dString.TrimEnd(dString[dString.Length - 1]);
            return Convert.ToDecimal(rounded);
        }

        static decimal MathRound(decimal d) => Math.Round(d, DIGITS_AFTER_FLOATING_POINT);

        static decimal RoundCeiling(decimal d)
        {
            return RoundFloor(d) + 0.01m;
        }
        static void PrintReadableExpression(int[] intArr, decimal[] decimalArr, RoundingOption opt)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                switch (opt)
                {
                    case RoundingOption.CeilingRounding:
                    {
                        PrintExpression(intArr[i], decimalArr[i], RoundCeiling);
                        break;
                    }
                    case RoundingOption.FloorRounding:
                    {
                        PrintExpression(intArr[i], decimalArr[i], RoundFloor);
                        break;
                    }
                    case RoundingOption.DefaultRounding:
                    {
                        PrintExpression(intArr[i], decimalArr[i], MathRound);
                        break;
                    }
                }
            }
        }

        static void PrintExpression(int i, decimal d, Func<decimal, decimal> func)
        {
            Console.WriteLine($"{i} x {d} = {func(d * i)}");
        }
    }
    
}