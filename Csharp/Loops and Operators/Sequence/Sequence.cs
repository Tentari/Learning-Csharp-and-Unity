using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int maxNumber = 103;
            int addedNumber = 7;
            int result = firstNumber;

            for (int i = firstNumber; i < maxNumber; i += addedNumber)
            {
                Console.Write($"{result} + {addedNumber}");
                result += addedNumber;
                Console.WriteLine($" = {result}");
            }

            Console.ReadKey();
        }
    }
}
