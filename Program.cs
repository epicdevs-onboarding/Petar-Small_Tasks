using System.Diagnostics.Tracing;
using System.Text;
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
                if (!IsValidInputNumber(inputNumString))
                {
                    Console.WriteLine("This isn't a valid number!");
                }

            } while (!IsValidInputNumber(inputNumString));

            int wordCount = Convert.ToInt32(inputNumString);

            List<string> sentence = new List<string>();
            int i = 1;

            do
            {
                Console.WriteLine($"Word #{i}: ");
                string temp = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("The words can't be white spaces or null! Enter a valid word: ");
                    continue;
                }
                else
                {
                    sentence.Add(temp);
                    i++;
                    wordCount--;
                }
            } while (wordCount > 0);

            Console.WriteLine("Do you want to reverse the characters in the words (y/n)? ");
            answerQ1 = Console.ReadLine();
            sentence = ValidateAndReturnAnswers(answerQ1, sentence, 1);

            Console.WriteLine("Do you want to reverse the order in the sentence (y/n)? ");
            answerQ2 = Console.ReadLine();
            sentence = ValidateAndReturnAnswers(answerQ2, sentence, 2);

            PrintArr(sentence);
        }

        static List<string> ReverseCharsOfStringArr(List<string> list)
        {
            List<string> result = new List<string>();
            
            foreach (string word in list)
            {
                char[] charArr = word.ToCharArray();
                Array.Reverse(charArr);
                result.Add(new string(charArr));

            }
            return result;
        }

        static List<string> ReverseStringArrOrder(List<string> arr)
        {
            Stack<string> tempStack = new Stack<string>(arr);
            List<string> result = new List<string>();

            foreach (string word in tempStack)
            {
                result.Add(word);
            }
            return result;
        }

        static void PrintArr(List<string> arr)
        {
            foreach (string element in arr)
            {
                Console.Write(element + " ");
            }
        }

        static bool IsValidYNAnswer(string answer)
        {
            string temp = answer.ToLowerInvariant().Trim();
            if (temp == "y")
            {
                return true;
            }
            else if (temp == "n")
            {
                return true;
            }
            return false;
        }

        static bool IsValidInputNumber(string input)
        {
            int num;
            if (int.TryParse(input, out num) && num > 0)
            {
                return true;
            }

            return false;
        }

        static List<string> ValidateAndReturnAnswers(string answer, List<string> sentence, int pref)
        {
            do
            {
                if (answer.ToLowerInvariant().Equals("y") && pref == 1)
                {
                    sentence = ReverseCharsOfStringArr(sentence);
                    break;
                }
                else if (answer.ToLowerInvariant().Equals("y") && pref == 2)
                {
                    sentence = ReverseStringArrOrder(sentence);
                    break;
                }
                else if (answer.ToLowerInvariant().Equals("n"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid answer!");
                    answer = Console.ReadLine();
                }
            } while (!IsValidYNAnswer(answer));

            return sentence;
        }
    }
}