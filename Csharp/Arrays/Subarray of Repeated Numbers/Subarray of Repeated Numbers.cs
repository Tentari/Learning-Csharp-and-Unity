using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];

            Random random = new Random();

            int maxNumber = 20;
            int minNumber = 5;
            int firstArrayNumber = 0;
            int currentRepeatNumber;
            int currentRepeatNumberCount = 1;
            int mostFrequentNumber = 0;
            int mostFrequentNumberCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int randomNumber = random.Next(minNumber,maxNumber + 1);
                numbers[i] = randomNumber;
            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            currentRepeatNumber = numbers[firstArrayNumber];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (currentRepeatNumber == numbers[i + 1])
                {
                    currentRepeatNumberCount++;
                }
                else
                {
                    currentRepeatNumber = numbers[i + 1];
                    currentRepeatNumberCount = 1;
                }

                if (mostFrequentNumberCount < currentRepeatNumberCount)
                {
                    mostFrequentNumberCount = currentRepeatNumberCount;
                    mostFrequentNumber = currentRepeatNumber;
                }
            }

            if (mostFrequentNumberCount == 1)
            {
                Console.WriteLine("All numbers were non consecutive");
            }
            else
            {
                Console.WriteLine($"{mostFrequentNumberCount} of {mostFrequentNumber} were near each other");
            }

            Console.ReadKey();
        }
    }
}
