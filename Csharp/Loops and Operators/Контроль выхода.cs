using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            string userInput;
            string exit = "exit";

            Console.WriteLine("Hello user. Which command we will execute today?");

            while (isOpen == true)
            {
                userInput = Console.ReadLine();
                if (userInput == exit)
                {
                    Console.WriteLine("Shuting down.");
                    isOpen = false;
                }
                else
                {
                    Console.WriteLine("Wrong command. We know how to exit only :(");
                }
            }

            Console.ReadKey();
        }
    }
}
