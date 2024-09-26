namespace Fish_tank;

class Program
{
    static void Main(string[] args)
    {
        FishMan fishMan = new FishMan();

        fishMan.Work();
    }
}

public class FishMan
{
    private Tank _tank;
    private Shelter _shelter;

    public FishMan()
    {
        _tank = new Tank();
        _shelter = new Shelter();
    }

    public void Work()
    {
        const int ChooseFishCommand = 1;
        const int RemoveFishCommand = 2;
        const int SkipACicleCommand = 3;

        bool isOpen = true;


        while (isOpen)
        {
            Console.WriteLine(
                $"\n{ChooseFishCommand}. - Buy fish\n{RemoveFishCommand}. - Remove fish\n{SkipACicleCommand}. - Skip a cycle\n");

            ShowFishesInTank();

            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case ChooseFishCommand:
                    AddFishToTank();
                    break;

                case RemoveFishCommand:
                    RemoveFishFromTank();
                    break;

                case SkipACicleCommand:
                    SkipACycle();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    break;
            }
        }

        Console.ReadKey();
    }

    public void ShowFishesInTank()
    {
        _tank.ShowFishes();
    }

    public void SkipACycle()
    {
        _tank.SkipACycle();
    }

    public void AddFishToTank()
    {
        Fish fish = _shelter.GetFish();

        _tank.InsertFish(fish);
    }

    public void RemoveFishFromTank()
    {
        _tank.ShowFishes();

        _tank.RemoveFish();
    }
}

public class Tank
{
    private List<Fish> _fishes;

    public Tank()
    {
        _fishes = new List<Fish>();
    }

    public void ShowFishes()
    {
        Viewer.ShowInfo(_fishes);
    }

    public void InsertFish(Fish fish)
    {
        _fishes.Add(fish);
    }

    public void RemoveFish()
    {
        Console.WriteLine("Choose fish number to remove: ");
        int userInput = ConsoleUtils.ReadInt() - 1;

        while (userInput < 0 || userInput >= _fishes.Count)
        {
            Console.WriteLine("Fish wasn't found. Try again: ");
            userInput = ConsoleUtils.ReadInt() - 1;
        }

        Console.WriteLine("Fish removed: " + _fishes[userInput].Name);

        _fishes.RemoveAt(userInput);
    }

    public void SkipACycle()
    {
        for (int i = _fishes.Count - 1; i >= 0; i--)
        {
            if (_fishes[i].IsDead() == false)
            {
                _fishes[i].Grow();
            }
            else
            {
                Console.WriteLine("Fish died: " + _fishes[i].Name);

                _fishes.Remove(_fishes[i]);
            }
        }
    }
}

public class Shelter
{
    private List<Fish> _fishes;

    public Shelter()
    {
        _fishes = new List<Fish>()
        {
            new Fish("Dory"),
            new Fish("Nemo"),
            new Fish("Marlin"),
            new Fish("Bubble"),
            new Fish("Cleo"),
            new Fish("Stuart"),
            new Fish("Snoopy"),
            new Fish("Sally"),
            new Fish("Bulbul")
        };
    }

    public Fish GetFish()
    {
        ShowFishes();

        Console.WriteLine("\nInput fish number to choose fish: ");
        int fishNumber = ConsoleUtils.ReadInt() - 1;

        while (fishNumber < 0 || fishNumber >= _fishes.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid number");

            fishNumber = ConsoleUtils.ReadInt() - 1;
        }

        Console.WriteLine("\nYou choose: " + _fishes[fishNumber].Name);

        return _fishes[fishNumber];
    }

    private void ShowFishes()
    {
        Viewer.ShowInfo(_fishes);
    }
}

public class Fish
{
    private int _age;

    private int _maxAge;

    public Fish(string name)
    {
        Name = name;
        _age = 0;
        _maxAge = 10;
    }

    public string Name { get; private set; }

    public bool IsDead()
    {
        return _age >= _maxAge;
    }

    public void Grow()
    {
        _age++;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} - {_age} years old");
    }
}

public class Viewer
{
    public static void ShowInfo(List<Fish> fishes)
    {
        int fishNumber = 1;

        foreach (Fish fish in fishes)
        {
            Console.Write(fishNumber++ + ". ");

            fish.ShowInfo();
        }
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