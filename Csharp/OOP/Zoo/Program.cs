namespace Zoo;

class Program
{
    static void Main(string[] args)
    {
        ZooFactory zooFactory = new ZooFactory();

        Zoo zoo = zooFactory.Create();

        zoo.Work();

        Console.ReadKey();
    }
}

public class ZooFactory
{
    private CageFactory _cageFactory;

    public ZooFactory()
    {
        _cageFactory = new CageFactory();
    }

    public Zoo Create()
    {
        List<Cage> cages = new List<Cage>();

        int cagesCount = 5;

        for (int i = 0; i < cagesCount; i++)
        {
            cages.Add(_cageFactory.Create());
        }

        return new Zoo(cages);
    }
}

public class Zoo
{
    private List<Cage> _cages;

    public Zoo(List<Cage> cages)
    {
        _cages = cages;
    }

    public void Work()
    {
        ShowCageByIndex();
    }

    private void ShowCages()
    {
        int cagesNumber = 1;

        for (int i = 0; i < _cages.Count; i++)
        {
            Console.WriteLine($"Cage {cagesNumber++}");
        }
    }

    private void ShowCageByIndex()
    {
        Console.WriteLine("Welcome to Zoo! Choose cage to see animals: ");

        ShowCages();

        int userInput = ConsoleUtils.ReadInt();

        if (userInput > 0 && userInput <= _cages.Count)
            _cages[userInput - 1].ShowAnimals();
        else
            Console.WriteLine("Wrong input.");
    }
}

public class CageFactory
{
    private AnimalFactory _animalFactory;

    public CageFactory()
    {
        _animalFactory = new AnimalFactory();
    }

    public Cage Create()
    {
        int animalsCount = GetAnimalsCount();

        List<Animal> animals = Fill(animalsCount);

        return new Cage(animals);
    }

    private List<Animal> Fill(int animalsCount)
    {
        List<Animal> animals = new List<Animal>();

        Animal animal = _animalFactory.Create(ConsoleUtils.GetRandomNumber(_animalFactory.AnimalsCount));

        for (int i = 0; i < animalsCount; i++)
        {
            animals.Add(animal.Copy());
        }

        return animals;
    }

    private int GetAnimalsCount()
    {
        int minAnimalsCount = 2;
        int maxAnimalsCount = 5;

        return ConsoleUtils.GetRandomNumber(minAnimalsCount, maxAnimalsCount);
    }
}

public class Cage
{
    private List<Animal> _animals;

    public Cage(List<Animal> animals)
    {
        _animals = animals;
    }

    public void ShowAnimals()
    {
        foreach (Animal animal in _animals)
        {
            animal.ShowInfo();
        }
    }
}

public class AnimalFactory
{
    private List<Animal> _baseAnimals;

    public AnimalFactory()
    {
        _baseAnimals = Fill();
    }

    public int AnimalsCount => _baseAnimals.Count;

    public Animal Create(int index)
    {
        return _baseAnimals[index].Copy();
    }

    private List<Animal> Fill()
    {
        return new List<Animal>()
        {
            new("Tiger", "Roar"),
            new("Giraffe", "Grunt"),
            new("Elephant", "Trill"),
            new("Monkey", "Squeak"),
            new("Horse", "Neigh")
        };
    }
}

public class Animal
{
    private string _name;
    private string _sound;
    private string _gender;

    public Animal(string name, string sound)
    {
        _name = name;
        _sound = sound;
        _gender = GenerateGender();
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{_name} - {_sound} - {_gender}");
    }

    public Animal Copy()
    {
        return new Animal(_name, _sound);
    }

    private string GenerateGender()
    {
        string[] genders = { "Male", "Female" };

        return genders[ConsoleUtils.GetRandomNumber(genders.Length)];
    }
}

public class ConsoleUtils
{
    private static Random s_random = new Random();

    public static int GetRandomNumber(int minNumber, int maxNumber)
    {
        return s_random.Next(minNumber, maxNumber + 1);
    }

    public static int GetRandomNumber(int maxNumber)
    {
        return s_random.Next(maxNumber);
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