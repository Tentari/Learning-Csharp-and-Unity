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

class Shop
{
    Buyer buyer;
    Seller seller;

    public Shop()
    {
        seller = new Seller();
        GenerateItems();
        buyer = new Buyer();
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
                    seller.ShowItems();
                    break;

                case ShowBuyersInventory:
                    buyer.ShowItems();
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
        seller.ShowItems();

        if (seller.TryGetItem(out Item item))
        {
            if (buyer.CanPay(item.Price))
            {
                seller.SellItem(item);
                buyer.BuyItem(item);

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
        seller.AddItem("Laptop", 1000);
        seller.AddItem("Phone", 500);
        seller.AddItem("Tablet", 700);
        seller.AddItem("Mouse", 50);
        seller.AddItem("Keyboard", 100);
    }
}

class Human
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

class Seller : Human
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

class Buyer : Human
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

class Item
{
    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name;
    public int Price;

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} - {Price} gold.");
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