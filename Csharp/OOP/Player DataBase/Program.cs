namespace Player_DataBase;

class Program
{
    static void Main(string[] args)
    {
        PlayerDatabase playerDataBase = new PlayerDatabase();

        playerDataBase.Work();
    }
}

class PlayerDatabase
{
    private List<Player> _players;

    public PlayerDatabase()
    {
        _players = new List<Player>();
    }

    public void Work()
    {
        const string AddPlayerCommand = "1";
        const string BanPlayerCommand = "2";
        const string UnBanPlayerCommand = "3";
        const string ShowPlayersCommand = "4";
        const string ExitCommand = "5";

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine(
                $"Enter command number: {AddPlayerCommand} - add new player, {BanPlayerCommand} - ban player, {UnBanPlayerCommand} - unban player,{ShowPlayersCommand} - show players, {ExitCommand} - exit");

            string userInput = Console.ReadLine();

            Console.Clear();

            switch (userInput)
            {
                case AddPlayerCommand:
                    AddPlayer();
                    break;

                case BanPlayerCommand:
                    BanPlayer();
                    break;

                case UnBanPlayerCommand:
                    UnBanPlayer();
                    break;

                case ShowPlayersCommand:
                    ShowPlayers();
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

    private void ShowPlayers()
    {
        foreach (var player in _players)
        {
            player.ShowInfo();
        }
    }

    private void BanPlayer()
    {
        ShowPlayers();

        Console.WriteLine("Choose which player you want to ban: ");

        if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0 && userInput <= _players.Count &&
            _players[userInput - 1].IsBanned == false)
        {
            _players[userInput - 1].Ban();
        }
        else
        {
            Console.WriteLine("Player not found or is already banned.");
        }
    }

    private void UnBanPlayer()
    {
        ShowPlayers();

        Console.WriteLine("Choose which player you want to ban: ");


        if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0 && userInput <= _players.Count &&
            _players[userInput - 1].IsBanned)
        {
            _players[userInput - 1].Unban();
        }
        else
        {
            Console.WriteLine("Player not found or isn't banned.");
        }
    }

    private void AddPlayer()
    {
        ShowPlayers();

        Console.WriteLine("Enter player name: ");
        string userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput) == false)
        {
            _players.Add(new Player(userInput));
        }
    }
}

class Player
{
    private static int s_nextId = 1;

    public Player(string name)
    {
        Id = s_nextId++;
        Name = name;
        IsBanned = false;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public bool IsBanned { get; private set; }

    public void Ban()
    {
        IsBanned = true;
    }

    public void Unban()
    {
        IsBanned = false;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Id: {Id}\nName: {Name}\nIs banned: {IsBanned}");
    }
}