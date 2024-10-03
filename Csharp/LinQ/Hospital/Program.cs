namespace Hospital;

class Program
{
    static void Main(string[] args)
    {
        DataBaseFactory dataBaseFactory = new DataBaseFactory();

        Hospital hospital = dataBaseFactory.Create();

        hospital.Work();
    }
}

public class DataBaseFactory
{
    private PatientFactory _patientFactory;

    public DataBaseFactory()
    {
        _patientFactory = new PatientFactory();
    }

    public Hospital Create()
    {
        return new Hospital(Fill());
    }

    public List<Patient> Fill()
    {
        int patientsCount = 15;

        List<Patient> patients = new List<Patient>();

        for (int i = 0; i < patientsCount; i++)
        {
            patients.Add(_patientFactory.Create());
        }

        return patients;
    }
}

public class Hospital
{
    private List<Patient> _patients;

    public Hospital(List<Patient> patients)
    {
        _patients = patients;
    }

    public void Work()
    {
        const int SortPatientsByFullNameCommand = 1;
        const int SortPatientsByAgeCommand = 2;
        const int TransferPatientsByDiseaseCommand = 3;
        const int ExitCommand = 4;

        bool isOpen = true;


        while (isOpen)
        {
            Console.WriteLine("Hello user, what do you want to do?\n");

            ShowPatients();

            Console.WriteLine($"\nThere are {_patients.Count} patients in the hospital.\n");

            Console.WriteLine($"{SortPatientsByFullNameCommand} - sort patients by full name." +
                              $"\n{SortPatientsByAgeCommand} - sort patients by age." +
                              $"\n{TransferPatientsByDiseaseCommand} - transfer patients by disease." +
                              $"\n{ExitCommand} - exit.");
            int userInput = ConsoleUtils.ReadInt();

            Console.Clear();

            switch (userInput)
            {
                case SortPatientsByFullNameCommand:
                    SortByFullName();
                    break;

                case SortPatientsByAgeCommand:
                    SortByAge();
                    break;

                case TransferPatientsByDiseaseCommand:
                    TransferPatientsByDisease();
                    break;

                case ExitCommand:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please enter a valid command.");
                    break;
            }
        }
    }

    private void SortByAge()
    {
        _patients = _patients.OrderBy(patients => patients.Age).ToList();
    }

    private void SortByFullName()
    {
        _patients = _patients.OrderBy(patients => patients.FullName).ToList();
    }

    private void TransferPatientsByDisease()
    {
        Console.WriteLine("Enter disease: ");
        string disease = Console.ReadLine();

        if (_patients.Any(patients => patients.Disease
                .Equals(disease, StringComparison.OrdinalIgnoreCase)))
        {
            _patients = _patients
                .Where(patients =>
                    patients.Disease
                        .Equals(disease, StringComparison.OrdinalIgnoreCase) == false).ToList();
        }
        else
        {
            Console.WriteLine("No patients with this disease.");
        }
    }

    private void ShowPatients()
    {
        if (_patients.Count > 0)
        {
            foreach (Patient patient in _patients)
            {
                patient.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("No patients.");
        }
    }
}

public class PatientFactory
{
    public Patient Create()
    {
        return new Patient(GetRandomFullName(), GetRandomDisease(), GetRandomAge());
    }

    private string GetRandomFullName()
    {
        List<string> fullNames =
        [
            "John Smith",
            "Jane Doe",
            "Michael Johnson",
            "Emily Williams",
            "David Brown",
            "Sarah Davis",
            "Olivia Taylor",
            "William Anderson",
            "Emma Thomas",
            "Daniel Jackson",
            "Ava Martinez",
            "Joseph Smith",
            "Liam Johnson",
            "Mason Williams"
        ];

        return fullNames[ConsoleUtils.GetRandomNumber(fullNames.Count)];
    }

    private int GetRandomAge()
    {
        int maxAge = 100;
        int minAge = 10;

        return ConsoleUtils.GetRandomNumber(minAge, maxAge + 1);
    }

    private string GetRandomDisease()
    {
        List<string> nationalities =
            ["Cancer", "Heart attack", "Stroke", "Covid-19", "Infection", "Influenza", "Flu", "Malaria"];

        return nationalities[ConsoleUtils.GetRandomNumber(nationalities.Count)];
    }
}

public class Patient
{
    public Patient(string fullName, string disease, int age)
    {
        FullName = fullName;
        Disease = disease;
        Age = age;
    }

    public string FullName { get; }
    public string Disease { get; }
    public int Age { get; }

    public void ShowInfo()
    {
        Console.WriteLine($"{FullName}) {Age} years old - {Disease}");
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