using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomNumber = random.Next(5, 50);
            int originalNumber = 2;
            int result = originalNumber;
            int power = 1;

            while (result < randomNumber)
            {
                result *= originalNumber;
                power++;
            }

            Console.WriteLine($"{originalNumber} power {power}({result}) > {randomNumber}(random number)");
            Console.ReadKey();
        }
    }
}
