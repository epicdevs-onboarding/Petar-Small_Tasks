using System.CodeDom.Compiler;

namespace Task1_ArrayMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int maxValue, arrLength;
            string input1, input2;
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

            int[] intArray = GenerateRandomIntArray(arrLength, maxValue);
            double[] doubleArray = GenerateRandomDoubleArr(arrLength, maxValue);
            
            PrintReadableExpression(intArray, doubleArray);
        }

        static int[] GenerateRandomIntArray(int elemCount, int maxValue)
        {
            int[] intArray = new int[elemCount];
            Random r = new Random();
            for (int i = 0; i < elemCount; i++)
            {
                intArray[i] = r.Next(maxValue);
            }
            return intArray;
        }
        static double[] GenerateRandomDoubleArr(int elemCount, int maxValue)
        {
            double[] doubleArray = new double[elemCount];
            Random r = new Random();
            for (int i = 0; i < elemCount; i++)
            {
                doubleArray[i] = Math.Round(r.NextDouble() * maxValue, 3);
            }
            return doubleArray;
        }
        static void PrintReadableExpression(int[] intArr, double[] doubleArr)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine($"{Convert.ToString(intArr[i])} x {Convert.ToString(doubleArr[i])} = {Math.Round(doubleArr[i] * intArr[i], 2)}");
            }
        }
    }
}