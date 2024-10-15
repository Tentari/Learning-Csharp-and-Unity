namespace Real;

class Program
{
    static void Main(string[] args)
    {
        const string SumCommand = "sum";
        const string ExitCommand = "exit";
        
        List<int> numbers = new List<int>();

        bool isOpen = true;
        
        while (isOpen)
        {
            Console.WriteLine($"Please enter command\n{SumCommand} - SUM.\n{ExitCommand} - EXIT.\nOr type any number.");
            string userInput = Console.ReadLine();
            
            Console.Clear();
            
            switch (userInput)
            {
                case SumCommand:
                    Console.WriteLine(SumNumbers(numbers));
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    numbers.Add(CheckInput(userInput));
                    break;
            }
        }
    }

    static int CheckInput(string userInput)
    {
        bool isRight = false;
        int number = 0;

        while (!isRight)
        {
            if (int.TryParse(userInput, out number))
            {
                isRight = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong number input, try again");
                userInput = Console.ReadLine();
            }
        }
        
        return number;
    }

    static int SumNumbers(List<int> numbers)
    {
        int sum = 0;
        
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}
