namespace Deck_of_cards;

class Program
{
    static void Main(string[] args)
    {
        Croupier croupier = new Croupier();

        croupier.Work();

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

    public void Work()
    {
        Console.WriteLine("How many card you need?");

        int userInput = ReadInt();

        while (userInput > _deck.CardsCount || userInput < 0)
        {
            Console.WriteLine($"We have only {_deck.CardsCount} cards.");
            userInput = ReadInt();
        }

        GivePlayerCards(userInput);

        _player.ShowHand();
    }

    private void GivePlayerCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _player.TakeCard(_deck.GiveCard());
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

    public void TakeCard(Card card)
    {
        _hand.Add(card);
    }
}

class Deck
{
    private Stack<Card> _cards = new Stack<Card>();

    public Deck()
    {
        CardsCount = 60;
        FillDeck();
    }

    public int CardsCount { get; private set; }

    public Card GiveCard()
    {
        return _cards.Pop();
    }

    private void FillDeck()
    {
        for (int i = 0; i < CardsCount; i++)
        {
            _cards.Push(new Card());
        }
    }
}

class Card
{
    static private Random s_random = new Random();

    public Card()
    {
        int minRandomValue = 1;
        int maxRandomValue = 10;
        
        Power = s_random.Next(minRandomValue, maxRandomValue + 1);
    }

    public int Power { get; private set; }
}
