using System;
using System.Collections.Generic;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> vocabulary = new Dictionary<string, string>
            {
                {"Labas","Hello"},
                {"Tu","You"},
                {"Siandien","Today"}
            };

            string userInput = GetInput("Please enter word:");

            if (vocabulary.ContainsKey(userInput))
            {
                Console.WriteLine(vocabulary[userInput]);
            }
            else
            {
                Console.WriteLine("ERROR WRONG INPUT");
            }

            Console.ReadKey();
        }

        static string GetInput(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }
    }
}
