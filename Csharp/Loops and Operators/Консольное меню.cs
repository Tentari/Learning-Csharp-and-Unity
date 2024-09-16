using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowDateCommand = "1";
            const string ShowBatteryPercentageCommand = "2";
            const string ShowRandomNumberCommand = "3";
            const string ClearConsoleCommand = "4";
            const string ExitCommand = "5";

            Random random = new Random();
            int batteryLeft = random.Next(1, 101);
            int randomNumber;
            string userInput;
            string todaysDate = "2024Y 09M 02D";
            bool isOpen = true;

            Console.WriteLine("Hello user!");

            while (isOpen == true)
            {
                Console.WriteLine($"Write in number to choose command.\n{ShowDateCommand} - Today's date.\n{ShowBatteryPercentageCommand} - Battery left.\n{ShowRandomNumberCommand} - Random number.\n{ClearConsoleCommand} - Clear console.\n{ExitCommand} - Exit.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowDateCommand:
                        Console.WriteLine(todaysDate);
                        break;
                    case ShowBatteryPercentageCommand:
                        Console.WriteLine($"{batteryLeft}% is left");
                        break;
                    case ShowRandomNumberCommand:
                        randomNumber = random.Next(0, 501);
                        Console.WriteLine($"{randomNumber} is your random number for this session.");
                        break;
                    case ClearConsoleCommand:
                        Console.Clear();
                        break;
                    case ExitCommand:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("I don't know such command.");
                        break;
                }
            }
        }
    }
}
