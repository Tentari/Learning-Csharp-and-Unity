using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter number.");

            int userNumber = GetNumber();

            Console.WriteLine("you picked " + userNumber);

            Console.ReadKey();
        }

        static int GetNumber()
        {
            int result;

            while (Int32.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("I don't know such number.");
            }
            
            return result;
        }
    }
}
