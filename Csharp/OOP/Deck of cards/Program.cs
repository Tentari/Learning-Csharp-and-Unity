namespace Deck_of_cards;

class Program
{
    static void Main(string[] args)
    {
        Croupier croupier = new Croupier();

        croupier.StartGame();

        Console.ReadKey();
    }
}

class Croupier
{
    private Deck _deck;
    private Player _player;

    public Croupier()
    {
        _player = new Player();
        _deck = new Deck();
    }

    public void StartGame()
    {
        Console.WriteLine("How many card you need?");

        int userInput = ReadInt();

        while (userInput > _deck.CardCount || userInput < 0)
        {
            Console.WriteLine($"We have only {_deck.CardCount} cards.");
            userInput = ReadInt();
        }

        GivePlayerCards(userInput);

        _player.ShowHand();
    }

    private void GivePlayerCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _player.GetCard(_deck.GiveCard());
        }
    }

    private int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Wrong number, try again.");
        }

        return number;
    }
}

class Player
{
    private List<Card> _hand;

    public Player()
    {
        _hand = new List<Card>();
    }

    public void ShowHand()
    {
        if (_hand.Count == 0)
        {
            Console.WriteLine("Sad, you have no cards.");
        }
        else
        {
            foreach (Card card in _hand)
            {
                Console.Write($"{card.Power} ");
            }

            Console.Write("- Are my cards.\n");
        }
    }

    public void GetCard(Card card)
    {
        _hand.Add(card);
    }
}

class Deck
{
    private Stack<Card> _deck;

    public Deck()
    {
        CardCount = 60;
        _deck = FillDeck();
    }

    public int CardCount { get; private set; }

    public Card GiveCard()
    {
        if (_deck.Count == 0)
        {
            Console.WriteLine("No more cards in deck.");
        }

        return _deck.Pop();
    }

    private Stack<Card> FillDeck()
    {
        _deck = new Stack<Card>();
        for (int i = 0; i < CardCount; i++)
        {
            _deck.Push(new Card());
        }

        return _deck;
    }
}

class Card
{
    static private Random s_random = new Random();

    public Card()
    {
        Power = s_random.Next(1, 10 + 1);
    }

    public int Power { get; private set; }
}