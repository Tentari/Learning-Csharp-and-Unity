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
        public Player(int positionX, int positionY, char playerChar)
        {
            positionX = positionX;
            positionY = positionY;
            PlayerChar = playerChar;
        }

        public int PositionX { get; private set; }
        public char PlayerChar { get; private set; }
        public int PositionY { get; private set; }
    }

    class Renderer
    {
        public void ShowPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionY, player.PositionX);
            Console.WriteLine(player.PlayerChar);
        }
    }
}