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
    private string _userName;
    private int _hp;
    private int _money;

    public Player(string userName, int hp, int money)
    {
        _userName = userName;
        _hp = hp;
        _money = money;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Username - {_userName}\nHealth - {_hp}\nMoney - {_money}");
    }
}