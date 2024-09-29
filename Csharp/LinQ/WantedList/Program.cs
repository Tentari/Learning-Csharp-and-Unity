namespace WantedList;

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
    private WantedFactory wantedFactory;

    public DataBaseFactory()
    {
        wantedFactory = new WantedFactory();
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
            wanteds.Add(wantedFactory.Create());
        }

        return wanteds;
    }
}

public class PoliceStation
{
    private List<Wanted> _wanteds;

    public PoliceStation(List<Wanted> wanteds)
    {
        _wanteds = wanteds;
    }

    public void Work()
    {
        ShowWantedsByParameter();
    }

    private void ShowWantedsByParameter()
    {
        Console.WriteLine("Enter wanted parameter: ");

        string wantedParameter = Console.ReadLine();

        IEnumerable<Wanted> filteredWanteds = from wanted in _wanteds
            where wanted.FullName.Equals(wantedParameter, StringComparison.OrdinalIgnoreCase) ||
                  wanted.Nationality.Equals(wantedParameter, StringComparison.OrdinalIgnoreCase) ||
                  wanted.Height.ToString() == wantedParameter ||
                  wanted.Weight.ToString() == wantedParameter && wanted.IsJailed == false
            select wanted;

        if (filteredWanteds.Count() > 0)
        {
            foreach (Wanted wanted in filteredWanteds)
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
            170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300
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
}