using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userTextInput;
            int userNumberInput;

            Console.WriteLine("Hello user. Write your message.");
            userTextInput = Console.ReadLine();
            Console.WriteLine("How many times to repeat?");
            userNumberInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userNumberInput; i++)
            {
                Console.WriteLine(userTextInput);
            }
            Console.ReadKey();
        }
    }
}
