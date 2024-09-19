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
    private Deck _freshDeck;
    private Player _player;

    public Croupier()
    {
        _player = new Player();
        _freshDeck = new Deck();
        _freshDeck.ShuffleCards();
    }

    public void Work()
    {
        Console.WriteLine("Hello player, tell us how many cards you need?");
        int cardsRequested = ReadInt();

        while (cardsRequested > _freshDeck.CardCount || cardsRequested < 1)
        {
            if (cardsRequested < 1)
            {
                Console.WriteLine("You need atleast one card.");
            }
            else
            {
                Console.WriteLine($"We have only {_freshDeck.CardCount} cards.");
            }

            cardsRequested = ReadInt();
        }

        GiveCardsToPlayer(cardsRequested);

        _player.ShowHand();
    }

    private void GiveCardsToPlayer(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _player.TakeCard(_freshDeck.GetCard());
        }
    }

    private int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
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

    public void TakeCard(Card card)
    {
        _hand.Add(card);
    }

    public void ShowHand()
    {
        int cardNumbering = 1;
        Console.WriteLine("My hand is :");

        foreach (Card card in _hand)
        {
            Console.WriteLine($"{cardNumbering}. {card.Name} of {card.Suit}");
            cardNumbering++;
        }
    }
}

class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
        GenerateCards();
        CardCount = _cards.Count;
    }

    public int CardCount { get; private set; }

    public Card GetCard()
    {
        int firstCard = 0;

        Card card = _cards[firstCard];
        _cards.RemoveAt(firstCard);
        CardCount--;

        return card;
    }

    private void GenerateCards()
    {
        List<string> cardName = new List<string>
            { "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        List<string> cardSuit = new List<string> { "Spade", "Club", "Heart", "Diamond" };

        foreach (string suit in cardSuit)
        {
            for (int i = 0; i < cardName.Count; i++)
            {
                _cards.Add(new Card(cardName[i], suit));
            }
        }
    }

    public void ShuffleCards()
    {
        Random random = new Random();

        for (int i = 0; i < _cards.Count - 1; i++)
        {
            int randomNumber = random.Next(i, _cards.Count);

            Card tempCard = _cards[i];
            _cards[i] = _cards[randomNumber];
            _cards[randomNumber] = tempCard;
        }
    }
}

class Card
{
    public Card(string name, string suit)
    {
        Name = name;
        Suit = suit;
    }

    public string Name { get; private set; }
    public string Suit { get; private set; }
}