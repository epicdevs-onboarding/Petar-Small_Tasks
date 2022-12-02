using System.Text.RegularExpressions;

namespace ConsoleAppAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputNumString;
            string answerQ1, answerQ2;

            
            do {
                Console.WriteLine("Please enter number of words to enter: ");
                inputNumString = Console.ReadLine();

            } while (!Regex.IsMatch(inputNumString, @"^\d+$"));

            int wordCount = Convert.ToInt32(inputNumString);

            string[] wordsStringArr = new string[wordCount];

            for (int i = 0; i < wordsStringArr.Length; i++)
            {
                Console.WriteLine("Word #"+ ++i +": ");
                i--;
                wordsStringArr[i] = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(wordsStringArr[i])) 
                {
                    Console.WriteLine("The words can't be white spaces or null! Enter a valid word: ");
                    i--;
                }
               
            }

            do
            {
                Console.WriteLine("Do you want to reverse the characters in the words (y/n)? ");
                answerQ1 = Console.ReadLine();
                if (answerQ1 == "y")
                {
                    wordsStringArr = ReverseCharsOfStringArr(wordsStringArr);
                    break;
                }
                else if (answerQ1 == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid answer!");
                }
            } while (!IsValidYNAnswer(answerQ1));

            do {
                Console.WriteLine("Do you want to reverse the order in the sentence (y/n)? ");
                answerQ2 = Console.ReadLine();
                if (answerQ2 == "y")
                {
                    wordsStringArr = ReverseStringArrOrder(wordsStringArr);
                    break;
                }
                else if (answerQ2 == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid answer!");
                }
            } while (!IsValidYNAnswer(answerQ2));


            PrintArr(wordsStringArr);
        }

        static string[] ReverseCharsOfStringArr(string[] arr)
        {
            string[] result = new string[arr.Length];
            int i = 0;
            foreach (string word in arr)
            {
                string reverseString = "";
                int length;

                length = word.Length - 1;

                while (length >= 0)
                {
                    reverseString = reverseString + word[length];
                    length--;
                }

                result[i] = reverseString;
                i++;
            }
            return result;
        }

        static string[] ReverseStringArrOrder(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
            return arr;
        }

        static void PrintArr(string[] arr)
        {
            foreach (string element in arr)
            {
                Console.Write(element + " ");
            }
        }

        static bool IsValidYNAnswer(string answer)
        {
            string temp = answer.ToLower().Trim();
            if (temp == "y" || temp == "n")
            {
                return true;
            }
            return false;
        }
    }
}