using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int percentageHealth = 50;
            int maxHealth = 10;
            int healthBarY = 5;

            ConsoleColor healthBar = ConsoleColor.Green;

            int percentageMana = 30;
            int maxMana = 10;
            int manaBarY = 6;

            ConsoleColor manaBar = ConsoleColor.Blue;

            DrawBar(percentageHealth, maxHealth, healthBar, healthBarY);
            DrawBar(percentageMana, maxMana, manaBar, manaBarY);

            Console.ReadKey();
        }

        static void DrawBar(int percentageValue, int maxValue, ConsoleColor color, int positionY)
        {
            int firstNumber = 0;
            int perCent = 100;
            int value = percentageValue * maxValue / perCent;

            ConsoleColor defaultColor = Console.BackgroundColor;

            char openBar = '[';
            char closeBar = ']';
            char fillBar = ' ';

            string filledBar = FillBar(firstNumber,value,fillBar);
            string emptyBar = FillBar(value,maxValue,fillBar);

            Console.SetCursorPosition(0, positionY);
            Console.Write(openBar);
            Console.BackgroundColor = color;
            Console.Write(filledBar);
            Console.BackgroundColor = defaultColor;
            Console.Write(emptyBar);
            Console.Write(closeBar);
        }

        static string FillBar(int value, int maxValue, char fillBar)
        {
            string bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += fillBar;
            }
            return bar;
        }
    }
}
