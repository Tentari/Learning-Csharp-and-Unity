using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[10, 10];

            Random random = new Random();

            int randomNumber;
            int minRandom = 5;
            int maxRandom = 50;
            int maxNumber = int.MinValue;
            int valueToReplace = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    randomNumber = random.Next(minRandom, maxRandom + 1);
                    numbers[i,j] = randomNumber;
                }
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine($"");
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (maxNumber < numbers[i,j])
                    {
                        maxNumber = numbers[i,j];
                    }
                }
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if(maxNumber == numbers[i,j])
                    {
                        numbers[i, j] = valueToReplace;
                    }
                }
            }

            Console.WriteLine($"\n\n\n");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\n{maxNumber} was our biggest number and was changed to {valueToReplace}");

            Console.ReadKey();
        }
    }
}
