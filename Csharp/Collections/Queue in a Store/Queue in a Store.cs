namespace Real;

class Program
{
    static void Main(string[] args)
    {
        Queue<int> customers = GenerateCustomers();

        int noCustomerLeft = 0;
        int income = 0;

        while (customers.Count > noCustomerLeft)
        {
            Console.Clear();
            TakeCustomer(customers,ref income);
            Console.ReadKey();
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static Queue<int> GenerateCustomers()
    {
        Queue<int> customers = new Queue<int>();

        Random random = new Random();

        int minNumber = 50;
        int maxNumber = 500;
        int customerCount = 10;

        for (int i = 0; i < customerCount; i++)
        {
            customers.Enqueue(random.Next(minNumber, maxNumber + 1));
        }

        return customers;
    }

    static void TakeCustomer(Queue<int> customers,ref int income)
    {
        int lastCustomer = 0;
        
        income += customers.Dequeue();
        Console.WriteLine("Customer taken");
        Console.WriteLine($"Our income {income}.");
        if (customers.Count > lastCustomer)
        {
            Console.WriteLine("Press any key to take another customer.");
        }
        else
        {
            Console.WriteLine("That was our last customer.");
        }
    }
}
