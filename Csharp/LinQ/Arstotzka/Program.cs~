namespace Arstotzka;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        Arstotzka arstotzka = dataBaseFactory.Create();

        arstotzka.Work();
    }
}

public class DataBaseFactory
{
    private CriminalFactory _criminalFactory;

    public DataBaseFactory()
    {
        _criminalFactory = new CriminalFactory();
    }

    public Arstotzka Create()
    {
        return new Arstotzka(Fill());
    }

    public List<Criminal> Fill()
    {
        int criminalsCount = 15;

        List<Criminal> criminals = new List<Criminal>();

        for (int i = 0; i < criminalsCount; i++)
        {
            criminals.Add(_criminalFactory.Create());
        }

        return criminals;
    }
}

public class Arstotzka
{
    private List<Criminal> _criminals;

    public Arstotzka(List<Criminal> criminals)
    {
        _criminals = criminals;
    }

    public void Work()
    {
        ShowCriminals(_criminals);

        _criminals = FreeCriminals("Revolution");

        Console.WriteLine("Updated list:");

        ShowCriminals(_criminals);
    }

    private List<Criminal> FreeCriminals(string crime)
    {
        return _criminals
            .Where(criminals => criminals.Crime != crime)
            .ToList();
    }

    private void ShowCriminals(List<Criminal> criminals)
    {
        if (criminals.Count() > 0)
        {
            foreach (Criminal criminal in criminals)
            {
                criminal.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }
    }
}

public class CriminalFactory
{
    public Criminal Create()
    {
        return new Criminal(GetRandomFullName(), GetRandomCrime());
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

    private string GetRandomCrime()
    {
        List<string> crimes = new List<string>()
        {
            "Assault", "Robbery", "Murder", "Homicide", "Revolution"
        };

        return crimes[ConsoleUtils.GetRandomNumber(crimes.Count)];
    }
}

public class Criminal
{
    private string _fullName;


    public Criminal(string fullName, string crime)
    {
        _fullName = fullName;
        Crime = crime;
    }

    public string Crime { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{_fullName}) Crime - {Crime}.");
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