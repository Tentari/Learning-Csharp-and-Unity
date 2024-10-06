namespace SoldiersInfo;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        Battlefield battlefield = dataBaseFactory.Create();

        battlefield.Work();
    }
}

public class DataBaseFactory
{
    private SoldierFactory _soldierFactory;

    public DataBaseFactory()
    {
        _soldierFactory = new SoldierFactory();
    }

    public Battlefield Create()
    {
        return new Battlefield(Fill());
    }

    private List<Soldier> Fill()
    {
        int soldiersCount = 15;

        List<Soldier> soldiers = new List<Soldier>();

        for (int i = 0; i < soldiersCount; i++)
        {
            soldiers.Add(_soldierFactory.Create());
        }

        return soldiers;
    }
}

public class Battlefield
{
    private List<Soldier> _soldiers;

    public Battlefield(List<Soldier> soldiers)
    {
        _soldiers = soldiers;
    }

    public void Work()
    {
        const int ShowSoldierListCommand = 1;
        const int ExitCommand = 2;

        List<SoldierDetails> soldierDetails =
            _soldiers.Select(soldier => new SoldierDetails(soldier.Name, soldier.Rank)).ToList();

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine("Hello user, what do you want to do?\n");


            Console.WriteLine($"\nThere are {_soldiers.Count} soldiers in the battlefield.\n");

            Console.WriteLine($"{ShowSoldierListCommand} - get all soldiers names and ranks." +
                              $"\n{ExitCommand} - exit.");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case ShowSoldierListCommand:
                    ShowDetails(soldierDetails);
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please enter a valid command.");
                    break;
            }
        }
    }

    public void ShowDetails(List<SoldierDetails> soldierDetails)
    {
        soldierDetails.ForEach(soldier => soldier.ShowInfo());
    }
}

public class SoldierDetails
{
    private string _name;
    private string _rank;

    public SoldierDetails(string name, string rank)
    {
        _name = name;
        _rank = rank;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{_name} - {_rank}");
    }
}

public class SoldierFactory
{
    private List<string> _names;
    private List<string> _ranks;
    private List<string> _armaments;

    public SoldierFactory()
    {
        _names =
        [
            "John",
            "Jane",
            "Michael",
            "Emily",
            "David",
            "Sarah",
            "Olivia",
            "William",
            "Emma",
            "Daniel",
            "Ava",
            "Joseph",
        ];

        _ranks =
        [
            "Master",
            "Captain",
            "Lieutenant",
            "Private",
            "Enforcer",
        ];

        _armaments =
        [
            "Pistol",
            "Shotgun",
            "Rifle",
            "Sniper",
        ];
    }

    public Soldier Create()
    {
        return new Soldier(GetRandomName(), GetRandomRank(), GetRandomArmament(), GetServiceTime());
    }

    private string GetRandomName()
    {
        return _names[ConsoleUtils.GetRandomNumber(_names.Count)];
    }

    private string GetRandomRank()
    {
        return _ranks[ConsoleUtils.GetRandomNumber(_ranks.Count)];
    }

    private string GetRandomArmament()
    {
        return _armaments[ConsoleUtils.GetRandomNumber(_armaments.Count)];
    }

    private int GetServiceTime()
    {
        int minTime = 1;
        int maxTime = 100;

        return ConsoleUtils.GetRandomNumber(minTime, maxTime + 1);
    }
}

public class Soldier
{
    private string _armaments;
    private int _serviceTime;

    public Soldier(string name, string rank, string armaments, int serviceTime)
    {
        Name = name;
        Rank = rank;
        _armaments = armaments;
        _serviceTime = serviceTime;
    }

    public string Name { get; private set; }
    public string Rank { get; private set; }
}

public class ConsoleUtils
{
    private static Random s_random = new Random();

    public static int GetRandomNumber(int minNumber, int maxNumber)
    {
        int random = s_random.Next(minNumber, maxNumber);

        return random;
    }

    public static int GetRandomNumber(int maxNumber)
    {
        int random = s_random.Next(maxNumber);

        return random;
    }

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