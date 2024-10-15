using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pacientCount;
            int pacientQueTime = 10;
            int queTime;
            int hour = 60;
            int hoursLeft;
            int minutesLeft;

            Console.WriteLine("How many patients you see?");
            pacientCount = Convert.ToInt32(Console.ReadLine());
            queTime = pacientQueTime * pacientCount;
            hoursLeft = queTime / hour;
            minutesLeft = queTime % hour;
            Console.WriteLine($"Doctor will see you in {hoursLeft} hours and {minutesLeft} minutes.");
            Console.ReadKey();
        }
    }
}
