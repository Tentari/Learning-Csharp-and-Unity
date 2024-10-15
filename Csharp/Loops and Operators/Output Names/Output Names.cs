using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            char borderChar;
            string nameWithSymbols;
            string borderSymbolRow = "";
            int nameLenght;

            Console.WriteLine("Tell us your name.");
            userName = Console.ReadLine();
            Console.WriteLine("Tell ur your preffered symbol.");
            borderChar = Convert.ToChar(Console.ReadLine());

            nameWithSymbols = borderChar + userName + borderChar;
            nameLenght = nameWithSymbols.Length;
            Console.Clear();

            for (int i = 0; i < nameLenght; i++)
            {
                borderSymbolRow += borderChar;
            }

            Console.WriteLine($"{borderSymbolRow}\n{nameWithSymbols}\n{borderSymbolRow}");
            Console.ReadKey();
        }
    }
}
