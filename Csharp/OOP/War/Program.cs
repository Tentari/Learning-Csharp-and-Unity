namespace Learning;

class Program
{
    static void Main(string[] args)
    {
        Battlefield battlefield = new Battlefield();

        battlefield.Work();

        Console.ReadKey();
    }
}

public class Battlefield
{
    private CompanyFactory _companyFactory;
    private Company _firstCompany;
    private Company _secondCompany;

    public Battlefield()
    {
        _companyFactory = new CompanyFactory();

        _firstCompany = _companyFactory.Create();
        _secondCompany = _companyFactory.Create();
    }

    public void Work()
    {
        while (_firstCompany.Soldiers.Count > 0 && _secondCompany.Soldiers.Count > 0)
        {
            Console.WriteLine("First company:");
            _firstCompany.ShowInfo();

            Console.WriteLine("Second company:");
            _secondCompany.ShowInfo();

            _firstCompany.Attack(_secondCompany);
            _secondCompany.Attack(_firstCompany);

            Console.WriteLine("Bullets!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        AnnounceWinner();

        Console.ReadKey();
    }

    private void AnnounceWinner()
    {
        if (_firstCompany.Soldiers.Count > 0)
            Console.WriteLine("First company wins!");
        else if (_secondCompany.Soldiers.Count > 0)
            Console.WriteLine("Second company wins!");
        else
            Console.WriteLine("Draw!");
    }
}

public class CompanyFactory
{
    public Company Create()
    {
        return new Company(new List<Soldier>()
            {
                new Trooper("Trooper", 100, 15, 10),
                new Sniper("Sniper", 100, 20, 5),
                new Grenadier("Grenadier", 100, 50, 15),
                new Suppressor("Suppressor", 100, 10, 20)
            }
        );
    }
}

public class Company
{
    private List<Soldier> _soldiers;

    public Company(List<Soldier> soldiers)
    {
        _soldiers = soldiers;
    }

    public IReadOnlyList<Soldier> Soldiers => _soldiers;

    public void Attack(Company company)
    {
        foreach (var soldier in _soldiers)
        {
            soldier.Attack(company);
        }

        company.RemoveDeadSoldiers();
    }

    public Soldier GetRandomSoldier()
    {
        return _soldiers[ConsoleUtils.GetRandomnNumber(0, _soldiers.Count - 1)];
    }

    public void ShowInfo()
    {
        foreach (Soldier soldier in _soldiers)
        {
            soldier.ShowInfo();
        }
    }

    public void RemoveDeadSoldiers()
    {
        List<Soldier> deadSoldiers = new List<Soldier>();

        foreach (Soldier soldier in _soldiers)
        {
            if (soldier.Health <= 0)
            {
                deadSoldiers.Add(soldier);
            }
        }

        foreach (Soldier dead in deadSoldiers)
        {
            _soldiers.Remove(dead);
        }
    }
}

public class Soldier
{
    private string _name;
    private int _armor;

    public Soldier(string name, int health, int damage, int armor)
    {
        _name = name;
        Health = health;
        _armor = armor;
        Damage = damage;
    }

    public int Damage { get; protected set; }
    public int Health { get; protected set; }


    public virtual void TakeDamage(int damage)
    {
        int armorBase = 100;
        int effectiveDamage = damage * (armorBase - _armor) / armorBase;

        if (Health > 0)
        {
            Health -= effectiveDamage;
        }
    }

    public virtual void Attack(Company company)
    {
        Soldier soldier = company.GetRandomSoldier();

        soldier.TakeDamage(Damage);
    }

    public virtual void Attack(Soldier soldier)
    {
        soldier.TakeDamage(Damage);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {_name}, Health: {Health}");
    }
}

public class Trooper : Soldier
{
    public Trooper(string name, int health, int damage, int armor) : base(name, health, damage, armor)
    {
    }
}

public class Sniper : Soldier
{
    public Sniper(string name, int health, int damage, int armor) : base(name, health, damage, armor)
    {
    }

    public override void Attack(Company company)
    {
        int currentDamage = Damage;
        int damageMultiplier = 3;

        Damage *= damageMultiplier;

        base.Attack(company);

        Damage = currentDamage;
    }
}

public class Grenadier : Soldier
{
    public Grenadier(string name, int health, int damage, int armor) : base(name, health, damage, armor)
    {
    }

    public override void Attack(Company company)
    {
        int firstEnemy = ConsoleUtils.GetRandomnNumber(0, company.Soldiers.Count - 1);
        int secondEnemy = firstEnemy;
        int thirdEnemy = firstEnemy;

        base.Attack(company.Soldiers[firstEnemy]);

        if (company.Soldiers.Count() > 1)
        {
            do
            {
                secondEnemy = ConsoleUtils.GetRandomnNumber(0, company.Soldiers.Count - 1);
            } while (secondEnemy == firstEnemy);

            base.Attack(company.Soldiers[secondEnemy]);
        }
        else if (company.Soldiers.Count() > 2)
        {
            do
            {
                thirdEnemy = ConsoleUtils.GetRandomnNumber(0, company.Soldiers.Count - 1);
            } while (thirdEnemy == firstEnemy || thirdEnemy == secondEnemy);

            base.Attack(company.Soldiers[thirdEnemy]);
        }
    }
}

public class Suppressor : Soldier
{
    private int _shotsToFire;

    public Suppressor(string name, int health, int damage, int armor) : base(name, health, damage, armor)
    {
        _shotsToFire = 3;
    }

    public override void Attack(Company company)
    {
        for (int i = 0; i < _shotsToFire; i++)
        {
            base.Attack(company);
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
}