namespace Real;

class Program
{
    static void Main(string[] args)
    {
        const char AcceptNewWorkerCommand = '1';
        const char FireWorkerCommand = '2';
        const char ShowWorkersCommand = '3';

        Dictionary<string, List<string>> positions = CreatePositions();

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine(
                $"\n\n{AcceptNewWorkerCommand} - Accept new worker\n{FireWorkerCommand} - Fire worker\n{ShowWorkersCommand} - Show workers");

            string userInput = Console.ReadLine();
            Console.Clear();

            switch (Convert.ToChar(userInput))
            {
                case AcceptNewWorkerCommand:
                    AcceptNewWorker(positions);
                    break;

                case FireWorkerCommand:
                    DeleteWorker(positions);
                    break;

                case ShowWorkersCommand:
                    ShowList(positions);
                    break;
            }
        }
    }

    static Dictionary<string, List<string>> CreatePositions()
    {
        Dictionary<string, List<string>> positions =
            new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

        positions.Add("Worker", ["Arthur", "Marian", "Vlad", "Ivan"]);
        positions.Add("Main trainer", ["Alex"]);
        positions.Add("Support trainer", ["John", "Michael"]);
        positions.Add("Manager", ["Dmitry"]);

        return positions;
    }

    static void ShowList(Dictionary<string, List<string>> positions)
    {
        foreach (var position in positions)
        {
            Console.Write($"{position.Key} - ");
            {
                int workerNumber = 0;

                foreach (var item in position.Value)
                {
                    Console.Write($"{++workerNumber}.{item} ");
                }
            }

            Console.WriteLine();
        }
    }

    static void AcceptNewWorker(Dictionary<string, List<string>> positions)
    {
        Console.WriteLine("Enter name of your worker.");
        string name = Console.ReadLine();

        Console.WriteLine("Enter position.");
        ShowList(positions);
        string position = Console.ReadLine();

        if (positions.ContainsKey(position) == false)
        {
            positions.Add(position, new List<string>());
        }

        positions[position].Add(name);
    }

    static void DeleteWorker(Dictionary<string, List<string>> positions)
    {
        int userIndex = -1;

        ShowList(positions);

        Console.WriteLine("Enter position of your worker.");
        string position = Console.ReadLine();

        if (positions.TryGetValue(position, out List<string> workers))
        {
            Console.WriteLine("Enter number of your worker.");

            int workerNumber = ReadInt();

            if (workerNumber > 0 && workerNumber <= workers.Count)
            {
                workers.RemoveAt(workerNumber - 1);

                if (workers.Count == 0)
                {
                    positions.Remove(position);
                }
            }
        }
    }

    static int ReadInt()
    {
        int workerNumber;

        while (int.TryParse(Console.ReadLine(), out workerNumber) == false)
        {
            Console.WriteLine("Please enter correct number.");
        }

        return workerNumber;
    }
}
