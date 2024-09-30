namespace Arstotzka;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        PoliceStation policeStation = dataBaseFactory.Create();

        policeStation.Work();
    }
}

public class DataBaseFactory
{
    private WantedFactory _wantedFactory;

    public DataBaseFactory()
    {
        _wantedFactory = new WantedFactory();
    }

    public PoliceStation Create()
    {
        return new PoliceStation(Fill());
    }

    public List<Wanted> Fill()
    {
        int wantedCount = 15;

        List<Wanted> wanteds = new List<Wanted>();

        for (int i = 0; i < wantedCount; i++)
        {
            wanteds.Add(_wantedFactory.Create());
        }

        return wanteds;
    }
}

public class PoliceStation
{
    private List<Wanted> _wanted;

    public PoliceStation(List<Wanted> wanted)
    {
        _wanted = wanted;
    }

    public void Work()
    {
        const string ShowByNationalityCommand = "1";
        const string ShowByHeightCommand = "2";
        const string ShowByWeightCommand = "3";
        const string ExitCommand = "4";

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine(
                $"Welcome to our program. What do you want to do?\n{ShowByNationalityCommand} - Show wanted by nationality" +
                $"\n{ShowByHeightCommand} - Show wanted by height" +
                $"\n{ShowByWeightCommand} - Show wanted by weight\n{ExitCommand} - Exit");
            string userInput = Console.ReadLine();

            Console.Clear();

            switch (userInput)
            {
                case ShowByNationalityCommand:
                    ShowByNationality();
                    break;

                case ShowByHeightCommand:
                    ShowByHeight();
                    break;

                case ShowByWeightCommand:
                    ShowByWeight();
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }
    }

    private void ShowByNationality()
    {
        Console.WriteLine("Enter nationality: ");
        string nationality = Console.ReadLine();

        IEnumerable<Wanted> filteredWanted = from wanted in _wanted
            where wanted.Nationality.Equals(nationality, StringComparison.OrdinalIgnoreCase)
            select wanted;

        ShowWanted(filteredWanted);
    }

    private void ShowByHeight()
    {
        Console.WriteLine("Enter height: ");
        int height = ConsoleUtils.ReadInt();

        IEnumerable<Wanted> filteredWanted = from wanted in _wanted
            where wanted.Height == height
            select wanted;

        ShowWanted(filteredWanted);
    }

    private void ShowByWeight()
    {
        Console.WriteLine("Enter weight: ");
        int weight = ConsoleUtils.ReadInt();

        IEnumerable<Wanted> filteredWanted = from wanted in _wanted
            where wanted.Weight == weight
            select wanted;

        ShowWanted(filteredWanted);
    }

    private void ShowWanted(IEnumerable<Wanted> filteredWanted)
    {
        if (filteredWanted.Count() > 0)
        {
            foreach (Wanted wanted in filteredWanted)
            {
                wanted.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }
    }
}

public class WantedFactory
{
    public Wanted Create()
    {
        return new Wanted(GetRandomFullName(), GetRandomNationality(), GetRandomHeight(), GetRandomWeight(),
            IsJailed());
    }

    private string GetRandomFullName()
    {
        List<string> fullNames = new List<string>()
        {
            "John Smith",
            "Jane Doe",
            "Michael Johnson",
            "Emily Williams",
            "David Brown",
            "Sarah Davis",
            "Olivia Taylor",
            "William Anderson",
            "Emma Thomas",
            "Daniel Jackson",
            "Ava Martinez",
            "Joseph Smith",
            "Liam Johnson",
            "Mason Williams",
        };

        return fullNames[ConsoleUtils.GetRandomNumber(fullNames.Count - 1)];
    }

    private string GetRandomNationality()
    {
        List<string> nationalities = new List<string>()
        {
            "American", "British", "Canadian", "Australian", "Japanese", "Chinese", "Indian",
        };

        return nationalities[ConsoleUtils.GetRandomNumber(nationalities.Count - 1)];
    }

    private int GetRandomHeight()
    {
        List<int> heights = new List<int>()
        {
            160, 170, 180, 190, 200, 210
        };

        return heights[ConsoleUtils.GetRandomNumber(heights.Count - 1)];
    }

    private int GetRandomWeight()
    {
        List<int> weights = new List<int>()
        {
            70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200
        };

        return weights[ConsoleUtils.GetRandomNumber(weights.Count - 1)];
    }

    private bool IsJailed()
    {
        int boolTrue = 1;

        return Convert.ToBoolean(ConsoleUtils.GetRandomNumber(boolTrue + 1));
    }
}

public class Wanted
{
    public Wanted(string fullName, string nationality, int height, int weight, bool isJailed)
    {
        FullName = fullName;
        Nationality = nationality;
        Height = height;
        Weight = weight;
        IsJailed = isJailed;
    }

    public string FullName { get; }
    public string Nationality { get; }

    public int Height { get; }
    public int Weight { get; }

    public bool IsJailed { get; }

    public void ShowInfo()
    {
        Console.WriteLine($"{FullName}) {Nationality}. {Height} height, {Weight} weight.");
    }
}

public class ConsoleUtils
{
    private static Random s_random = new Random();

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