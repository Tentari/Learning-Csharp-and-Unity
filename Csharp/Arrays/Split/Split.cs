using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruits = "Apple Banana Lemon Watermelon Suprise";

            char delimeters = ' ';

            string[] fixedFruits = fruits.Split(delimeters);

            foreach (string fruit in fixedFruits)
            {
                Console.WriteLine(fruit);
            }

            Console.ReadKey();
        }
    }
}
