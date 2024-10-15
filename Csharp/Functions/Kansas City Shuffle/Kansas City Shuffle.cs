using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            FillArray(numbers);
            ShowArray(numbers);
            DoShuffle(numbers);

            Console.WriteLine();

            ShowArray(numbers);

            Console.ReadKey();
        }

        static void DoShuffle(int[] array)
        {
            Random random = new Random();

            int minNumber = 0;
            int tempNumber;
            int tempRandom;

            for (int i = array.Length - 1; i > 0 ; i--)
            {
                tempRandom = random.Next(minNumber, i + 1);

                tempNumber = array[i];
                array[i] = array[tempRandom];
                array[tempRandom] = tempNumber;
            }
        }

        static int GenerateRandom(Random random,int minNumber,int maxNumber)
        {
            int number = random.Next(minNumber, maxNumber + 1);

            return number;
        }

        static void FillArray(int[] array)
        {
            Random random = new Random();

            int minNumber = 1;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GenerateRandom(random,minNumber,array.Length);
            }
        }

        static void ShowArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
