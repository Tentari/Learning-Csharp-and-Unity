using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRandomNumber = 25;
            int minRandomNumber = 10;
            int randomDividableNumber = random.Next(minRandomNumber, maxRandomNumber + 1);
            int maxNumber = 150;
            int minNumber = 50;
            int dividedCount = 0;

            for (int i = 0; i < maxNumber + 1; i += randomDividableNumber)
            {
                if(i >= minNumber &&  i <= maxNumber)
                {
                    dividedCount++;
                }
            }

            Console.WriteLine(dividedCount);
            Console.ReadKey();
        }
    }
}
