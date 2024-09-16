namespace Real;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Tentari", 100, 1500);
            
        player.ShowStats();

        Console.ReadKey();
    }
}

class Player
{
    private string _name;
    private int _hp;
    private int _money;

    public Player(string name, int hp, int money)
    {
        _name = name;
        _hp = hp;
        _money = money;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name - {_name}\nHealth - {_hp}\nMoney - {_money}");
    }
}
