using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string EurosToDollarsCommand = "1";
            const string DollarsToEurosCommand = "2";
            const string EurosToRubblesCommand = "3";
            const string RubblesToEurosCommand = "4";
            const string DollarsToRubblesCommand = "5";
            const string RubblesToDollarsCommand = "6";
            const string ExitCommand = "exit";

            float userConvertInput;
            string userInput;
            bool isOpen = true;
            float eurosToDollars = 1.11f;
            float dollarsToEuros = 0.90f;
            float eurosToRubbles = 99.32f;
            float rubblesToEuros = 0.010f;
            float dollarsToRubbles = 89.71f;
            float rubblesToDollars = 0.011f;
            float userRubbles = 600f;
            float userEuros = 20.5f;
            float userDollars = 100f;

            Console.WriteLine("Hello user! I'm converter.");

            while (isOpen)
            {
                Console.WriteLine($"1 RUB = {rubblesToEuros} EUR / {rubblesToDollars} USD.\n1 EUR = {eurosToRubbles} RUB / {eurosToDollars} USD.\n1 USD = {dollarsToEuros} EUR / {dollarsToRubbles} RUB.");
                Console.WriteLine($"You have {userDollars} USD. {userEuros} EUR. {userRubbles} RUB.");
                Console.WriteLine($"{EurosToDollarsCommand} - EUR to USD. {DollarsToEurosCommand} - USD to EUR. {EurosToRubblesCommand} - EUR to RUB. {RubblesToEurosCommand} - RUB to EUR. {DollarsToRubblesCommand} - USD to RUB. {RubblesToDollarsCommand} - RUB to USD. {ExitCommand} - close app.");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case EurosToDollarsCommand:
                        Console.WriteLine("How many EUR to USD?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userEuros >= userConvertInput)
                        {
                            userEuros -= Convert.ToSingle(userConvertInput);
                            userDollars += Convert.ToSingle(userConvertInput) * eurosToDollars;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;

                    case DollarsToEurosCommand:
                        Console.WriteLine("How many USD to EUR?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userDollars >= Convert.ToSingle(userConvertInput))
                        {
                            userDollars -= Convert.ToSingle(userConvertInput);
                            userEuros += Convert.ToSingle(userConvertInput) * dollarsToEuros;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;

                    case EurosToRubblesCommand:
                        Console.WriteLine("How many EUR to RUB?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userEuros >= Convert.ToSingle(userConvertInput))
                        {
                            userEuros -= Convert.ToSingle(userConvertInput);
                            userRubbles += Convert.ToSingle(userConvertInput) * eurosToRubbles;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                            break;

                    case RubblesToEurosCommand:
                        Console.WriteLine("How many RUB to EUR?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userRubbles >= Convert.ToSingle(userConvertInput))
                        {
                            userRubbles -= Convert.ToSingle(userConvertInput);
                            userEuros += Convert.ToSingle(userConvertInput) * rubblesToEuros;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;

                    case DollarsToRubblesCommand:
                        Console.WriteLine("How many USD to RUB?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userDollars >= Convert.ToSingle(userConvertInput))
                        {
                            userDollars -= Convert.ToSingle(userConvertInput);
                            userRubbles += Convert.ToSingle(userConvertInput) * dollarsToRubbles;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
                        break;

                    case RubblesToDollarsCommand:
                        Console.WriteLine("How many RUB to USD?");
                        userConvertInput = Convert.ToSingle(Console.ReadLine());

                        if (userRubbles >= userConvertInput)
                        {
                            userRubbles -= Convert.ToSingle(userConvertInput);
                            userDollars += Convert.ToSingle(userConvertInput) * rubblesToDollars;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }
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
