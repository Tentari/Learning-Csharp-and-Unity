using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string exitCommand = "exit";
            const string sumCommand = "sum";

            int[] numbers = new int[0];

            string userInput;

            bool isOpen = true;

            while(isOpen)
            {
                foreach (var number in numbers)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine("It's our numbers for now.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case sumCommand:
                        int sumResult = 0;
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sumResult += numbers[i];
                        }

                        Console.WriteLine($"Sum of all these numbers is {sumResult}");

                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case exitCommand:
                        isOpen = false;
                        break;

                    default:
                            int[] tempArray = new int[numbers.Length + 1];

                            for (int i = 0; i <= numbers.Length - 1; i++)
                            {
                                tempArray[i] = numbers[i];
                            }

                            tempArray[tempArray.Length - 1] = Convert.ToInt32(userInput);
                            numbers = tempArray;
                        break;
                }

                Console.Clear();
            }
        }
    }
}
