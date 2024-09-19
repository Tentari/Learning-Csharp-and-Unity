namespace Library;

class Program
{
    static void Main(string[] args)
    {
        BookShelve bookShelve = new BookShelve();

        bookShelve.Work();

        Console.ReadKey();
    }
}

class BookShelve
{
    private List<Book> _books;

    public BookShelve()
    {
        _books = new List<Book>();
    }

    public void Work()
    {
        const int AddBookCommand = 1;
        const int RemoveBookCommand = 2;
        const int ShowBooksCommand = 3;
        const int ShowBooksByParameterCommand = 4;
        const int ExitCommand = 5;

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine(
                $"\n{AddBookCommand} - Add book.\n{RemoveBookCommand} - Remove book.\n{ShowBooksCommand} - Show books.\n{ShowBooksByParameterCommand} - Show books by parameter.\n{ExitCommand} - Exit.");
            int userCommandInput = ReadInt();

            Console.Clear();

            switch (userCommandInput)
            {
                case AddBookCommand:
                    AddBook(ReadYear());
                    break;

                case RemoveBookCommand:
                    ShowBooks();
                    RemoveBook(ReadIndex());
                    break;

                case ShowBooksCommand:
                    ShowBooks();
                    break;

                case ShowBooksByParameterCommand:
                    SearchBooksByParameter();
                    break;

                case ExitCommand:
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    private int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        return number;
    }

    private int ReadYear()
    {
        Console.WriteLine("Year: ");
        return ReadInt();
    }

    private int ReadIndex()
    {
        Console.WriteLine("Index: ");
        return ReadInt();
    }

    private void AddBook(int year)
    {
        Console.WriteLine("Author: ");
        string author = Console.ReadLine();

        Console.WriteLine("Title: ");
        string title = Console.ReadLine();

        _books.Add(new Book(author, title, year));

        Console.WriteLine($"{author} - {title} {year} was added.");
    }

    private void RemoveBook(int index)
    {
        if (index > _books.Count || index < 1)
        {
            Console.WriteLine("Bad input.");
        }
        else
        {
            _books.RemoveAt(index - 1);
        }
    }

    private void ShowBooks()
    {
        foreach (Book book in _books)
        {
            book.ShowBook();
        }
    }

    private void SearchBooksByParameter()
    {
        int authorChoice = 1;
        int titleChoice = 2;

        Console.WriteLine($"Search by author({authorChoice}) or title({titleChoice}) ?");

        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
            if (userChoice == authorChoice)
            {
                ShowBooksByAuthor();
            }
            else if (userChoice == titleChoice)
            {
                ShowBooksByTitle();
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }

    private void ShowBooksByAuthor()
    {
        Console.WriteLine("Enter parameter: ");
        string userAuthorInput = Console.ReadLine().ToLower();

        bool isFound = false;

        foreach (Book book in _books)
        {
            if (book.Author.ToLower().Contains(userAuthorInput))
            {
                book.ShowBook();
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Not found.");
        }
    }

    private void ShowBooksByTitle()
    {
        Console.WriteLine("Enter parameter: ");
        string userParameterInput = Console.ReadLine().ToLower();

        bool isFound = false;

        foreach (Book book in _books)
        {
            if (book.Title.ToLower().Contains(userParameterInput))
            {
                book.ShowBook();
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Not found.");
        }
    }
}

class Book
{
    private static int s_idCounter;

    private int _id;
    private int _year;

    public Book(string author, string title, int year)
    {
        _id = ++s_idCounter;
        Author = author;
        Title = title;
        _year = year;
    }

    public string Author { get; private set; }
    public string Title { get; private set; }

    public void ShowBook()
    {
        Console.WriteLine($"{_id}.{Author} - {Title} {_year}.");
    }
}