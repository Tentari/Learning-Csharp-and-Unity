using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Ozekauskas";
            string surname = "Renatas";
            string tempSwaper;

            Console.WriteLine($"Your name is {name} and surname {surname}");
            tempSwaper = name;
            name = surname;
            surname = tempSwaper;
            Console.WriteLine($"Sorry! Our data got swapped correctly now. Your name is {name} and surname {surname}");
            Console.ReadKey();
        }
    }
}
