namespace Top_players;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        PlayGround playGround = dataBaseFactory.Create();

        playGround.Work();
    }
}

public class DataBaseFactory
{
    private PlayerFactory _playerFactory;

    public DataBaseFactory()
    {
        _playerFactory = new PlayerFactory();
    }

    public PlayGround Create()
    {
        return new PlayGround(Fill());
    }

    public List<Player> Fill()
    {
        int playersCount = 15;

        List<Player> players = new List<Player>();

        for (int i = 0; i < playersCount; i++)
        {
            players.Add(_playerFactory.Create());
        }

        return players;
    }
}

public class PlayGround
{
    private List<Player> _players;

    public PlayGround(List<Player> players)
    {
        _players = players;
    }

    public void Work()
    {
        const int SortTopPowerPlayersCommand = 1;
        const int SortTopLevelPlayersCommand = 2;
        const int ExitCommand = 3;

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine("Hello user, what do you want to do?\n");

            ShowPlayers();

            Console.WriteLine($"\nThere are {_players.Count} players in the play ground.\n");

            Console.WriteLine($"{SortTopPowerPlayersCommand} - show best power players." +
                              $"\n{SortTopLevelPlayersCommand} - show best level players." +
                              $"\n{ExitCommand} - exit.");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case SortTopPowerPlayersCommand:
                    ShowTopPlayers(GetTopPowerPlayers(), "power");
                    break;

                case SortTopLevelPlayersCommand:
                    ShowTopPlayers(GetTopLevelPlayers(), "level");
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

    private IEnumerable<Player> GetTopPowerPlayers()
    {
        return _players.OrderByDescending(players => players.Power);
    }

    private IEnumerable<Player> GetTopLevelPlayers()
    {
        return _players.OrderByDescending(players => players.Level);
    }

    private void ShowPlayers()
    {
        if (_players.Count > 0)
        {
            foreach (Player player in _players)
            {
                player.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("No players.");
        }
    }

    private void ShowTopPlayers(IEnumerable<Player> players, string topPlayerParameter)
    {
        int topPlayersCount = 3;

        if (_players.Count > 0)
        {
            Console.WriteLine($"Top {topPlayerParameter} players\n");
            players.Take(topPlayersCount).ToList().ForEach(player => player.ShowInfo());
        }
        else
        {
            Console.WriteLine("No players.");
        }
    }
}

public class PlayerFactory
{
    private List<string> _names;

    public PlayerFactory()
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
            "Liam",
            "Mason",
        ];
    }

    public Player Create()
    {
        return new Player(GetRandomFullName(), GetRandomLevel(), GetRandomPower());
    }

    private string GetRandomFullName()
    {
        return _names[ConsoleUtils.GetRandomNumber(_names.Count)];
    }

    private int GetRandomLevel()
    {
        int maxLevel = 100;
        int minLevel = 1;

        return ConsoleUtils.GetRandomNumber(minLevel, maxLevel + 1);
    }

    private int GetRandomPower()
    {
        int maxPower = 10000;
        int minPower = 10;

        return ConsoleUtils.GetRandomNumber(minPower, maxPower + 1);
    }
}

public class Player
{
    public Player(string name, int level, int power)
    {
        Name = name;
        Level = level;
        Power = power;
    }

    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Power { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}) {Level} level - {Power} power");
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