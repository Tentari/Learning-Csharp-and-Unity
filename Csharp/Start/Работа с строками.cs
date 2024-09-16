using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string userSurname;
            int userAge;
            int userFavoriteNumber;

            Console.WriteLine("Hello user! Please tell us your name");
            userName = Console.ReadLine();
            Console.WriteLine("Your surname?");
            userSurname = Console.ReadLine();
            Console.WriteLine("Your age?");
            userAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your favorite number?");
            userFavoriteNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Welcome in.\n{userName} {userSurname} {userAge}.\nYour Favorite number is: {userFavoriteNumber}.");
            Console.ReadKey();
        }
    }
}
