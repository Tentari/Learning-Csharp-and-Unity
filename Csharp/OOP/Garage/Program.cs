namespace Garage;

class Program
{
    static void Main(string[] args)
    {
        GarageFactory garageFactory = new GarageFactory();

        Garage garage = garageFactory.Create();

        garage.Work();

        Console.ReadKey();
    }
}

public class GarageFactory
{
    private CarsFactory _carsFactory;

    public GarageFactory()
    {
        _carsFactory = new CarsFactory();
    }

    public Garage Create()
    {
        List<Car> cars = new List<Car>();

        int minCarsCount = 1;
        int maxCarsCount = 10;
        int carsCount = ConsoleUtils.GetRandomNumber(minCarsCount, maxCarsCount + 1);

        for (int i = 0; i < carsCount; i++)
        {
            cars.Add(_carsFactory.Create());
        }

        return new Garage(cars, FillWerehouse());
    }

    private List<CarPart> FillWerehouse()
    {
        int partsCount = 5;

        List<CarPart> parts = new List<CarPart>
        {
            new CarPart("Engine", 1000),
            new CarPart("Body", 500),
            new CarPart("Wheel", 200),
            new CarPart("Brake", 100),
            new CarPart("Tire", 50)
        };

        List<CarPart> allParts = new List<CarPart>();

        foreach (CarPart part in parts)
        {
            for (int i = 0; i < 5; i++)
            {
                allParts.Add(part.Copy());
            }
        }

        return allParts;
    }
}

public class Garage
{
    private List<Car> _cars;

    private List<CarPart> _newParts;

    private int _money;

    public Garage(List<Car> cars, List<CarPart> newParts)
    {
        _money = 3000;
        _cars = cars;
        _newParts = newParts;
    }

    public void Work()
    {
        const int RepairCommand = 1;
        const int RefuseCommand = 2;

        int cancelPrice = 50;

        Console.WriteLine($"Welcome to the garage.");

        while (_cars.Count > 0 && _money > cancelPrice)
        {
            Console.WriteLine($"You have {_cars.Count} cars waiting for repair.");

            ShowCar();

            Console.WriteLine($"Our bank is {_money}$.");

            Console.WriteLine(
                $"Do you want to repair it or refuse it? {RepairCommand} - repair, {RefuseCommand} - refuse");
            int userInput = ConsoleUtils.ReadInt();
            Console.Clear();

            switch (userInput)
            {
                case RepairCommand:
                    Repair();
                    break;

                case RefuseCommand:
                    RefuseCar();
                    break;

                default:
                    Console.WriteLine("Wrong command. Try again");
                    break;
            }
        }

        if (_money <= cancelPrice)
            Console.WriteLine("You don't have enough money. You can't continue.");
        else
            Console.WriteLine("No more cars left.");
    }

    private void Repair()
    {
        const int StopRepairingCommand = -1;
        
        int profitMoney = 0;

        int brokenPartsCount = GetBrokenPartsCount();

        bool isOpen = true;

        do
        {
            ShowCar();

            ShowWarehouse();

            Console.WriteLine($"Choose part to replace. Be careful, you can burn part if you choose wrong one. If you decided to stop repairing press {StopRepairingCommand}.");
            int userInput = ConsoleUtils.ReadInt();
            Console.Clear();

            if (userInput > 0 && userInput <= _newParts.Count)
            {
                CarPart carPart = _newParts[userInput - 1];
                
                _newParts.RemoveAt(userInput - 1);

                bool isPartRepaired = _cars[0].TryRepair(carPart);

                if (isPartRepaired)
                {
                    profitMoney += carPart.Price;
                    brokenPartsCount--;
                }
                else
                {
                    Console.WriteLine("Wrong part. You burned part.");
                }
                
                isOpen = brokenPartsCount > 0;
            }
            else if (userInput == StopRepairingCommand)
            {
                isOpen = false;
            }
            else
            {
                Console.WriteLine("Wrong input or part not found.");
            }
        } while (isOpen);

        if (brokenPartsCount > 0)
        {
            int penalty = GetMidRefusalPenalty();

            _money -= penalty;

            Console.WriteLine($"You decided not to repair car.\n You have to pay {penalty}$.");
        }
        else
        {
            _money += profitMoney;

            Console.WriteLine("Car repaired. You can continue.");
            Console.WriteLine($"You earned {profitMoney}$.");
        }
        
        _cars.RemoveAt(0);
    }

    private int GetMidRefusalPenalty()
    {
        int penalty = 0;

        foreach (CarPart carPart in _cars[0].Parts)
        {
            if (carPart.IsBroken)
                penalty += carPart.Price;
        }

        return penalty;
    }

    private int GetBrokenPartsCount()
    {
        int brokenPartsCount = 0;

        foreach (CarPart carPart in _cars[0].Parts)
        {
            if (carPart.IsBroken)
                brokenPartsCount++;
        }

        return brokenPartsCount;
    }

    private void ShowWarehouse()
    {
        Console.WriteLine("Our warehouse: ");

        for (int i = 0; i < _newParts.Count; i++)
            Console.WriteLine($"{i + 1}) {_newParts[i].GetInfo()}");
    }

    private void ShowCar()
    {
        Console.WriteLine();
        _cars[0].ShowInfo();
    }

    private void RefuseCar()
    {
        const int RefuseCommand = 1;

        int refusalPrice = 50;

        _money -= refusalPrice;

        Console.WriteLine(
            $"Are you sure you want to refuse car?\nRefusal price - {refusalPrice}\n {RefuseCommand} - Yes, Any other button - No");
        int userInput = ConsoleUtils.ReadInt();

        if (userInput == RefuseCommand)
        {
            _cars.RemoveAt(0);
        }
    }
}

public class CarsFactory
{
    private CarPartsFactory _carPartsFactory;

    private List<CarPart> _parts;

    public CarsFactory()
    {
        _carPartsFactory = new CarPartsFactory();
    }

    public Car Create()
    {
        _parts = _carPartsFactory.Fill();

        DestroyRandomParts();

        return new Car(_parts);
    }

    private void DestroyRandomParts()
    {
        int maxBrokenParts = 3;
        int minBrokenParts = 1;
        int brokenPartsCount = ConsoleUtils.GetRandomNumber(minBrokenParts, maxBrokenParts + 1);

        List<int> brokenPartsIndexes = new List<int>();

        while (brokenPartsIndexes.Count < brokenPartsCount)
        {
            int brokenPartIndex = ConsoleUtils.GetRandomNumber(brokenPartsCount + 1);

            if (brokenPartsIndexes.Contains(brokenPartIndex) == false)
            {
                _parts[brokenPartIndex].Break();

                brokenPartsIndexes.Add(brokenPartIndex);
            }
        }
    }
}

public class Car
{
    private List<CarPart> _parts;

    public Car(List<CarPart> parts)
    {
        _parts = parts;
    }

    public List<CarPart> Parts => _parts.ToList();

    public void ShowInfo()
    {
        foreach (CarPart part in _parts)
        {
            if (part.IsBroken)
                Console.WriteLine($" {part.GetInfo()}");
        }
    }

    public bool TryRepair(CarPart carPart)
    {
        CarPart? part = _parts.Find(p => p.Name == carPart.Name && p.IsBroken);

        if (part == null)
        {
            return false;
        }

        _parts.Remove(part);

        _parts.Add(carPart);

        return true;
    }
}

public class CarPartsFactory
{
    public CarPartsFactory()
    {
    }

    public List<CarPart> Fill()
    {
        return
        [
            new CarPart("Engine", 1000),
            new CarPart("Body", 500),
            new CarPart("Wheel", 200),
            new CarPart("Brake", 100),
            new CarPart("Tire", 50)
        ];
    }
}

public class CarPart
{
    public CarPart(string name, int price)
    {
        Name = name;
        Price = price;
        IsBroken = false;
    }

    public int Price { get;}

    public string Name { get;}

    public bool IsBroken { get; private set; }

    public CarPart Copy()
    {
        return new CarPart(Name, Price);
    }

    public void Break()
    {
        IsBroken = true;
    }

    public string GetInfo()
    {
        return $"Part - {Name}, Price - {Price}, Broken - {IsBroken}";
    }
}

public class ConsoleUtils
{
    private static Random s_random = new Random();

    public static int GetRandomNumber(int minNumber, int maxNumber)
    {
        int random = s_random.Next(minNumber, maxNumber);

        return random;
    }

    public static int GetRandomNumber(int maxNumber)
    {
        int random = s_random.Next(maxNumber);

        return random;
    }

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