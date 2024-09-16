namespace Learning;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player(5, 15, '@');
        Renderer renderer = new Renderer();

        renderer.ShowPlayer(player);

        Console.ReadKey();
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        
        public char PlayerChar { get; private set; }

        public Player(int x, int y, char playerChar)
        {
            X = x;
            Y = y;
            PlayerChar = playerChar;
        }
    }

    class Renderer
    {
        public void ShowPlayer(Player player)
        {
            Console.SetCursorPosition(player.Y, player.X);
            Console.WriteLine(player.PlayerChar);
        }
    }
}