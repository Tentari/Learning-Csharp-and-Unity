namespace Train_Configurator;

class Program
{
    static void Main(string[] args)
    {
        Dispatcher dispatcher = new Dispatcher();

        dispatcher.Work();

        Console.ReadKey();
    }
}

public class Dispatcher
{
    private static Random _random = new Random();

    private List<Train> _trains;

    public Dispatcher()
    {
        _trains = new List<Train>();
    }

    public void Work()
    {
        const int CreateTrainCommand = 1;
        const int ShowTrainsCommand = 2;
        const int ExitCommand = 3;

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine(
                $"\n{CreateTrainCommand} - Create train\n{ShowTrainsCommand} - Show trains \n{ExitCommand} - Exit");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case CreateTrainCommand:
                    CreateTrain();
                    break;

                case ShowTrainsCommand:
                    ShowTrains();
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    break;
            }
        }
    }


    public void CreateTrain()
    {
        Route route = CreateRoute();

        int boughtTickets = GenerateBoughtTickets();

        List<Wagon> wagons = CreateWagons(boughtTickets);

        Train train = new Train(route, wagons);

        _trains.Add(train);
    }

    private int GenerateBoughtTickets()
    {
        int minPassengers = 50;
        int maxPassengers = 300;

        return _random.Next(minPassengers, maxPassengers + 1);
    }

    private Route CreateRoute()
    {
        string departurePoint = default;
        string arrivalPoint = default;

        do
        {
            Console.WriteLine("Hello user. Please enter departure point:");
            departurePoint = Console.ReadLine();

            Console.WriteLine("Please enter arrivalment point:");
            arrivalPoint = Console.ReadLine();
        } while (departurePoint == arrivalPoint);

        return new Route(departurePoint, arrivalPoint);
    }

    private List<Wagon> CreateWagons(int boughtTickets)
    {
        List<Wagon> wagons = new List<Wagon>();

        int capacity = new Wagon().MaxPlaces;

        int wagonsCount = boughtTickets / capacity;

        if (boughtTickets % capacity > 0)
        {
            wagonsCount++;
        }

        for (int i = 0; i < wagonsCount; i++)
        {
            wagons.Add(new Wagon());
        }

        return wagons;
    }

    private void ShowTrains()
    {
        int trainNumber = 1;

        foreach (Train train in _trains)
        {
            Console.Write(trainNumber + ". ");
            train.ShowInfo();
        }
    }
}

public class Route
{
    public Route(string departurePoint, string arrivementPoint)
    {
        DeparturePoint = departurePoint;
        ArrivementPoint = arrivementPoint;
    }

    public string DeparturePoint { get; private set; }
    public string ArrivementPoint { get; private set; }
}

public class Train
{
    private List<Wagon> _wagons;
    private Route _route;

    public Train(Route route, List<Wagon> wagons)
    {
        _wagons = wagons;
        _route = route;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Train {_route.DeparturePoint} - {_route.ArrivementPoint} has {_wagons.Count} wagons.");
    }
}

public class Wagon
{
    public Wagon()
    {
        MaxPlaces = 50;
    }

    public int MaxPlaces { get; private set; }
}

public class ConsoleUtils
{
    public static int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        return number;
    }
}