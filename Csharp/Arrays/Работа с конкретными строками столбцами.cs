using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arrayNumbers = new int[,] { { 5, 6, 7 }, { 5, 7, 8 } };

            int sumResult = 0;
            int multiplicationResult = 1;
            int rowIndex = 1;
            int numberIndex = 0;

            for (int i = 0; i < arrayNumbers.GetLength(1); i++)
            {
                sumResult += arrayNumbers[rowIndex, i];
            }

            for (int i = 0; i < arrayNumbers.GetLength(0); i++)
            {
                multiplicationResult *= arrayNumbers[i, numberIndex];
            }

            for (int i = 0; i < arrayNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < arrayNumbers.GetLength(1); j++)
                {
                    Console.Write($"{arrayNumbers[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("It's our array.");
            Console.WriteLine($"\n{sumResult} is our SUM of second row.");
            Console.WriteLine($"{multiplicationResult} is our multiplication of first column");

            Console.ReadKey();
        }
    }
}
