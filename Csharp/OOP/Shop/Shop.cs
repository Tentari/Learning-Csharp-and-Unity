namespace Shop;

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        shop.Work();

        Console.ReadKey();
    }
}

public class Shop
{
    private Buyer _buyer;
    private Seller _seller;

    public Shop()
    {
        _seller = new Seller();
        GenerateItems();
        _buyer = new Buyer();
    }

    public void Work()
    {
        const int SellItemCommand = 1;
        const int ShowAllGoodsCommand = 2;
        const int ShowBuyersInventory = 3;
        const int ExitCommand = 4;

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine(
                $"\n{SellItemCommand} - Sell item\n{ShowAllGoodsCommand} - Show all goods\n{ShowBuyersInventory} - Show buyers inventory\n{ExitCommand} - Exit");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case SellItemCommand:
                    CompleteSellTransaction();
                    break;

                case ShowAllGoodsCommand:
                    _seller.ShowItems();
                    break;

                case ShowBuyersInventory:
                    _buyer.ShowItems();
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

    private void CompleteSellTransaction()
    {
        _seller.ShowItems();

        if (_seller.TryGetItem(out Item item))
        {
            if (_buyer.CanPay(item.Price))
            {
                _seller.SellItem(item);
                _buyer.BuyItem(item);

                Console.WriteLine("Item sold. Thank you.");
            }
            else
            {
                Console.WriteLine("Not enough gold.");
            }
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    private void GenerateItems()
    {
        _seller.AddItem("Laptop", 1000);
        _seller.AddItem("Phone", 500);
        _seller.AddItem("Tablet", 700);
        _seller.AddItem("Mouse", 50);
        _seller.AddItem("Keyboard", 100);
    }
}

public class Human
{
    protected List<Item> Items;

    public Human(int gold)
    {
        Gold = gold;
        Items = new List<Item>();
    }

    public int Gold { get; protected set; }

    public void ShowItems()
    {
        int itemsNumbering = 1;

        if (Items.Count > 0)
        {
            foreach (Item item in Items)
            {
                Console.Write(itemsNumbering++ + ".");
                item.ShowInfo();
            }

            Console.WriteLine($"Gold: {Gold}");
        }
        else
        {
            Console.WriteLine("It's empty.");
        }
    }
}

public class Seller : Human
{
    public Seller(int gold = 50) : base(gold)
    {
    }

    public bool TryGetItem(out Item item)
    {
        Console.WriteLine("Please choose product by number.");

        int userInput = ConsoleUtils.ReadInt();

        if (userInput <= Items.Count && userInput > 0)
        {
            item = Items[userInput - 1];
            return true;
        }

        item = null;
        return false;
    }

    public void SellItem(Item item)
    {
        Gold += item.Price;
        Items.Remove(item);
    }

    public void AddItem(string name, int price)
    {
        Items.Add(new Item(name, price));
    }
}

public class Buyer : Human
{
    public Buyer(int gold = 500) : base(gold)
    {
    }

    public void BuyItem(Item item)
    {
        Gold -= item.Price;
        Items.Add(item);
    }

    public bool CanPay(int price)
    {
        return Gold >= price;
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
        Console.WriteLine($"{_name} - {Price} gold.");
    }
}

public class ConsoleUtils
{
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