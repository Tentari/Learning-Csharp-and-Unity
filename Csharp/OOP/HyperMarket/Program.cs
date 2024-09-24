namespace HyperMarket;

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        shop.Work();
    }
}

public class Shop
{
    private int _profit;

    private Queue<Client> _clients;

    private List<Item> _items;

    public Shop()
    {
        GenerateItems();

        _clients = new Queue<Client>();

        _profit = 0;
    }

    public void Work()
    {
        bool isOpen = true;

        while (isOpen)
        {
            GenerateClient();
            ShowClientInfo();

            if (CanPay())
            {
                SellItems();
            }
            else
            {
                Console.WriteLine("Not enough money. I will remove random item from cart.");
                _clients.Peek().Cart.RemoveItem();
            }

            Console.WriteLine($"\nShop profit: {_profit}");

            Console.WriteLine("Press any key to serve another customer.");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void SellItems()
    {
        GiveItemsToCustomer();
        _profit += _clients.Peek().Cart.SumOfItems();
        _clients.Dequeue();
    }

    private void GiveItemsToCustomer()
    {
        _clients.Peek().FillBag();
    }

    private void GenerateItems()
    {
        _items = new List<Item>
        {
            new Item("Apple", 10),
            new Item("Banana", 15),
            new Item("Orange", 20),
            new Item("Pineapple", 25),
            new Item("Watermelon", 30),
            new Item("Grape", 35),
            new Item("Kiwi", 40),
            new Item("Mango", 45),
            new Item("Peach", 50),
            new Item("Plum", 55),
            new Item("Cherry", 60),
            new Item("Strawberry", 65),
            new Item("Blueberry", 70),
            new Item("Avocado", 75),
            new Item("Lemon", 80)
        };
    }

    private void GenerateClient()
    {
        int maxCartCount = 5;
        int minCartCount = 1;
        int cartCount = ConsoleUtils.GetRandomnNumber(minCartCount, maxCartCount + 1);

        Client client = new Client();

        for (int i = 0; i < cartCount; i++)
        {
            client.InsertItemIntoCart(_items[ConsoleUtils.GetRandomnNumber(0, _items.Count - 1)]);
        }

        _clients.Enqueue(client);
    }

    private void ShowClientInfo()
    {
        _clients.Peek().ShowCart();

        Console.WriteLine($"I have {_clients.Peek().Money} money.");
    }

    private bool CanPay()
    {
        if (_clients.Peek().Money >= _clients.Peek().Cart.SumOfItems())
        {
            return true;
        }

        return false;
    }
}

public class Client
{
    private int _minMoney = 200;
    private int _maxMoney = 500;

    public Client()
    {
        Bag = new Inventory();
        Cart = new Inventory();

        Money = ConsoleUtils.GetRandomnNumber(_minMoney, _maxMoney + 1);
    }

    public Inventory Bag { get; private set; }

    public Inventory Cart { get; private set; }

    public int Money { get; private set; }

    public void InsertItemIntoCart(Item item)
    {
        Cart.AddItem(item);
    }

    public void ShowCart()
    {
        Cart.ShowItems();
    }

    public void FillBag()
    {
        foreach (Item item in Cart.Items)
        {
            Bag.AddItem(item);
        }
    }
}

public class Inventory
{
    public Inventory()
    {
        Items = new List<Item>();
    }

    public List<Item> Items { get; private set; }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void ShowItems()
    {
        foreach (Item item in Items)
        {
            item.ShowInfo();
        }

        Console.WriteLine("Total price: " + SumOfItems());
    }

    public int SumOfItems()
    {
        int totalCartSum = 0;

        foreach (Item item in Items)
        {
            totalCartSum += item.Price;
        }

        return totalCartSum;
    }

    public void RemoveItem()
    {
        Items.RemoveAt(ConsoleUtils.GetRandomnNumber(0, Items.Count - 1));
    }
}

public class Item
{
    private string _name;


    public Item(string name, int price)
    {
        _name = name;
        Price = price;
    }

    public int Price { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {_name}, Price: {Price}");
    }
}

public class ConsoleUtils
{
    private static Random s_random = new Random();

    public static int GetRandomnNumber(int minNumber, int maxNumber)
    {
        int random = s_random.Next(minNumber, maxNumber + 1);

        return random;
    }
}