using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4 };

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.WriteLine("How many times we switch numbers to left?");
            int userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInput; i++)
            {
                int nextNumber = 1;
                int tempNumber = 0;

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    tempNumber = numbers[j + nextNumber];
                    numbers[j + nextNumber] = numbers[j];
                    numbers[j] = tempNumber;
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
