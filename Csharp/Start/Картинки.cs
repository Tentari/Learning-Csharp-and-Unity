using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictureCount = 52;
            int rowSize = 3;
            int maxRows = pictureCount / rowSize;
            int pictureLeftoverCount = pictureCount % rowSize;

            Console.WriteLine($"You will see {maxRows} of picture rows but {pictureLeftoverCount} will be left without full row");
            Console.ReadKey();
        }
    }
}