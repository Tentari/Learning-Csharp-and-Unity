namespace Soldiers_merge;

class Program
{
    static void Main(string[] args)
    {
        List<string> soldiers =
        [
            "John",
            "Jane",
            "Joe",
            "Jill",
            "Jim",
            "Bomba",
        ];
        
        List<string> betterSoldiers =
        [
            "Amogus",
        ];

        betterSoldiers = betterSoldiers.Concat(soldiers.Where(soldiers => soldiers.StartsWith("B"))).ToList();
        
        soldiers = soldiers.Where(soldiers => soldiers.StartsWith("B") == false).ToList();
        
        betterSoldiers.ForEach(soldier => Console.WriteLine(soldier));
    }
}
