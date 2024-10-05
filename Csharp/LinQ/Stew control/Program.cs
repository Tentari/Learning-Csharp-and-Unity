namespace Stew_control;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        WareHouse wareHouse = dataBaseFactory.Create();

        wareHouse.Work();
    }
}

public class DataBaseFactory
{
    private StewFactory _stewFactory;

    public DataBaseFactory()
    {
        _stewFactory = new StewFactory();
    }

    public WareHouse Create()
    {
        return new WareHouse(Fill());
    }

    private List<Stew> Fill()
    {
        int stewsCount = 15;

        List<Stew> stews = new List<Stew>();

        for (int i = 0; i < stewsCount; i++)
        {
            stews.Add(_stewFactory.Create());
        }

        return stews;
    }
}

public class WareHouse
{
    private List<Stew> _stews;

    public WareHouse(List<Stew> stews)
    {
        _stews = stews;
    }

    public void Work()
    {
        const int SortBadStews = 1;
        const int ExitCommand = 2;

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine("Hello user, what do you want to do?\n");

            ShowStews(_stews);

            Console.WriteLine($"\nThere are {_stews.Count} stews in the warehouse.\n");

            Console.WriteLine($"{SortBadStews} - get all bad stews." +
                              $"\n{ExitCommand} - exit.");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case SortBadStews:
                    ShowStews(GetBadStews());
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

    private List<Stew> GetBadStews()
    {
        List<Stew> badStews = _stews.Where(stew => stew.ProductionDate >= stew.BestBeforeDate).ToList();

        return badStews;
    }

    private void ShowStews(List<Stew> stews)
    {
        if (stews.Count > 0)
        {
            foreach (Stew stew in stews)
            {
                stew.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("No stews.");
        }

        Console.WriteLine();
    }
}

public class StewFactory
{
    private List<string> _names;

    public StewFactory()
    {
        _names =
        [
            "Vkusniaska",
            "Gavno",
            "Prosto jeda",
        ];
    }

    public Stew Create()
    {
        int productionDate = GetProductionDate();

        return new Stew(GetRandomName(), productionDate, GetExpireDate(productionDate));
    }

    private string GetRandomName()
    {
        return _names[ConsoleUtils.GetRandomNumber(_names.Count)];
    }

    private int GetProductionDate()
    {
        int maxDate = 2025;
        int minDate = 2020;

        return ConsoleUtils.GetRandomNumber(minDate, maxDate + 1);
    }

    private int GetExpireDate(int productionDate)
    {
        int minAge = -3;
        int maxAge = 3;

        return productionDate + ConsoleUtils.GetRandomNumber(minAge, maxAge + 1);
    }
}

public class Stew
{
    private string _name;

    public Stew(string name, int productionDate, int bestBeforeDate)
    {
        _name = name;
        ProductionDate = productionDate;
        BestBeforeDate = bestBeforeDate;
    }

    public int ProductionDate { get; private set; }
    public int BestBeforeDate { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{_name}) Was made {ProductionDate} - best before {BestBeforeDate}.");
    }
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