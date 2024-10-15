using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gold = 200;
            int crystalPrice = 50;
            int crystalCount = 0;

            Console.WriteLine($"Hello travaller. Buy some crystals cheap! 50g per item.How much you need?\nYour gold: {gold}  Crystals: {crystalCount}");
            int userInput = Convert.ToInt32(Console.ReadLine());
            crystalCount += userInput;
            gold -= crystalPrice * userInput;
            Console.WriteLine($"Thanks! Come again.\nYour gold: {gold}  Crystals: {crystalCount}");
            Console.ReadKey();
        }
    }
}
