using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 5, 8, 3, 6, 1, 9, 2, 4, 7, 10 };

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int tempNumber;

                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        tempNumber = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tempNumber;
                    }
                }
            }

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.ReadKey();

        }
    }
}
