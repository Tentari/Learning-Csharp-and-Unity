using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];

            Random random = new Random();

            int minNumber = 5;
            int maxNumber = 20;
            int randomNumber;
            int numberToStartFrom = 1;
            int firstArrayNumber = 0;
            int secondArrayNumber = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                randomNumber = random.Next(minNumber, maxNumber + 1);
                numbers[i] = randomNumber;
            }

            if (numbers[firstArrayNumber] > numbers[secondArrayNumber])
            {
                Console.WriteLine($"Me local strenght! {numbers[firstArrayNumber]}");
            }

            for (int i = numberToStartFrom; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1])
                {
                    Console.WriteLine($"Me local strenght! {numbers[i]}.");
                }
            }

            int secondNumberFromEnd = numbers.Length - 1;

            if (numbers[numbers.Length - 1] > numbers[secondNumberFromEnd - 1])
            {
                Console.WriteLine($"Me local strenght! {numbers[numbers.Length - 1]}");
            }

            Console.ReadKey();
        }
    }
}
