using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "abc1";
            int tryCount = 3;
            string userInput;

            Console.WriteLine("Enter password to unlock message");

            for (int i = 0; i < tryCount; i++)
            {
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Secret message unlocked: Move here.");
                    break;
                }
                else
                {

                    if (i == tryCount - 1)
                    {
                        Console.WriteLine("No more tries.");
                    }
                    else
                    {
                        Console.WriteLine("Try again.");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
