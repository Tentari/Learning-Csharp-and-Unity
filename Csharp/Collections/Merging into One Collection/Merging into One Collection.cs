namespace Real;

class Program
{
    static void Main(string[] args)
    {
        int[] firstHalfNumbers = { 1, 2, 2 };
        int[] secondHalfNumbers = { 3, 2 };

        List<int> numbers = new List<int>(firstHalfNumbers.Length + secondHalfNumbers.Length);

        ShowList(numbers,"Our array: ");
        
        MergeArray(firstHalfNumbers, numbers);
        MergeArray(secondHalfNumbers, numbers);
        
        ShowList(numbers,"Sorted array: ");

        Console.ReadKey();
    }

    static void MergeArray(int[] unfilterredNumbers, List<int> numbers)
    {
        for (int i = 0; i < unfilterredNumbers.Length; i++)
        {
            if (numbers.Contains(unfilterredNumbers[i]) == false)
            {
                numbers.Add(unfilterredNumbers[i]);
            }
        }
    }
    
    static void ShowList(List<int> numbers,string text)
    {
        Console.Write(text);
        
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        
        Console.WriteLine();
    }
}
