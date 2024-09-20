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
        const int SellCommand = 1;
        const int ShowProducts = 2;
        const int ShowBuyerInventory = 3;
        const int ExitCommand = 4;

        bool IsRunning = true;

        while (IsRunning)
        {
            Console.WriteLine($"\nYour money - {seller.Money}. Buyer's money - {buyer.Money}.\n");

            Console.WriteLine(
                $"\n{SellCommand} - Sell item.\n{ShowProducts} - Show products.\n{ShowBuyerInventory} - Show buyer's inventory.\n{ExitCommand} - Exit. ");
            int userInput = ReadInt();
            Console.Clear();

            switch (userInput)
            {
                case SellCommand:
                    SellItem();
                    break;

                case ShowProducts:
                    ShowItems(seller);
                    break;

                case ShowBuyerInventory:
                    ShowItems(buyer);
                    break;

                case ExitCommand:
                    IsRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }

    private void ShowItems(NPC npc)
    {
        int itemsNumbering = 1;

        if (npc.Items.Count > 0)
        {
            foreach (Item item in npc.Items)
            {
                Console.Write(itemsNumbering++ + ".");
                item.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("It's empty.");
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

    private void SellItem()
    {
        ShowItems(seller);

        Console.WriteLine("Enter index of item you want to sell: ");
        int index = ReadInt() - 1;

        if (index > -1 && index < seller.Items.Count)
        {
            if (buyer.Money >= seller.Items[index].Price)
            {
                Item item = seller.Items[index];

                seller.SellItem(item);
                buyer.BuyItem(item);

                Console.WriteLine("You sold " + item.Name);
            }
            else
            {
                Console.WriteLine("Buyer don't have enough money");
            }
        }
        else
        {
            Console.WriteLine("Wrong index");
        }
    }

    private void GenerateItems()
    {
        seller.Items.Add(new Item("Laptop", 1000));
        seller.Items.Add(new Item("Phone", 500));
        seller.Items.Add(new Item("Tablet", 700));
        seller.Items.Add(new Item("Mouse", 50));
        seller.Items.Add(new Item("Keyboard", 100));
    }
}

class NPC
{
    public NPC(int money)
    {
        Money = money;
        Items = new List<Item>();
    }

    public List<Item> Items { get; private set; }
    public int Money { get; protected set; }
}

class Seller : NPC
{
    public Seller(int money = 50) : base(money) { }

    public void SellItem(Item item)
    {
        Money += item.Price;
        Items.Remove(item);
    }
}

class Buyer : NPC
{
    public Buyer(int money = 500) : base(money) { }

    public void BuyItem(Item item)
    {
        Money -= item.Price;
        Items.Add(item);
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