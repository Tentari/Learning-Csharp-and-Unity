using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRandomNumber = 100;
            Random random = new Random();
            int generatedNumber = random.Next(0, maxRandomNumber + 1);
            int firstDevidedNumber = 3;
            int secondDevidedNumber = 5;
            int totalSumOfDividableNumbers = 0;
            int noRemainderLeft = 0;

            for (int i = 1; i <= generatedNumber; i++)
            {
                if (i % firstDevidedNumber == noRemainderLeft || i % secondDevidedNumber == noRemainderLeft)
                {
                    totalSumOfDividableNumbers += i;
                }
            }

            Console.WriteLine($"{totalSumOfDividableNumbers} is final sum of all numbers dividable by {firstDevidedNumber} and {secondDevidedNumber} from {generatedNumber}.");
            Console.ReadKey();
        }
    }
}
