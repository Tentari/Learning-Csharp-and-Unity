﻿namespace Library;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.Work();

        Console.ReadKey();
    }
}

class Library
{
    private List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    public void Work()
    {
        const int AddCommand = 1;
        const int RemoveCommand = 2;
        const int ShowCommand = 3;
        const int ShowByParameterCommand = 4;
        const int ExitCommand = 5;

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine(
                $"\n{AddCommand} - Add book.\n{RemoveCommand} - Remove book.\n{ShowCommand} - Show books.\n{ShowByParameterCommand} - Show books by parameter.\n{ExitCommand} - Exit.");
            int userCommandInput = ReadInt();

            Console.Clear();

            switch (userCommandInput)
            {
                case AddCommand:
                    AddBook();
                    break;

                case RemoveCommand:
                    ShowAllBooks();
                    RemoveBook(ReadIndex());
                    break;

                case ShowCommand:
                    ShowAllBooks();
                    break;

                case ShowByParameterCommand:
                    SearchByParameter();
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

    private int ReadIndex()
    {
        Console.WriteLine("Index: ");
        return ReadInt();
    }

    private void AddBook()
    {
        Console.WriteLine("Author: ");
        string author = Console.ReadLine();

        Console.WriteLine("Title: ");
        string title = Console.ReadLine();

        Console.WriteLine("Years:");
        int year = ReadInt();

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

    private void ShowAllBooks()
    {
        foreach (Book book in _books)
        {
            book.ShowInfo();
        }
    }

    private void SearchByParameter()
    {
        const int AuthorChoice = 1;
        const int TitleChoice = 2;
        const int YearChoice = 3;

        Console.WriteLine($"Search by author({AuthorChoice}) or title({TitleChoice}) or year({YearChoice})?");

        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
            switch (userChoice)
            {
                case AuthorChoice:
                    SearchByAuthor();
                    break;
                
                case TitleChoice:
                    SearchByTitle();
                    break;
                
                case YearChoice:
                    SearchByYear();
                    break;
                
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }

    private void SearchByAuthor()
    {
        Console.WriteLine("Enter parameter: ");
        string userAuthorInput = Console.ReadLine().ToLower();

        bool isFound = false;

        foreach (Book book in _books)
        {
            if (book.Author.ToLower().Contains(userAuthorInput))
            {
                book.ShowInfo();
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Not found.");
        }
    }

    private void SearchByYear()
    {
        Console.WriteLine("Enter parameter: ");
        int userParameterInput = ReadInt();

        bool isFound = false;

        foreach (Book book in _books)
        {
            if (book.Year == userParameterInput)
            {
                book.ShowInfo();
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Not found.");
        }
    }

    private void SearchByTitle()
    {
        Console.WriteLine("Enter parameter: ");
        string userParameterInput = Console.ReadLine().ToLower();

        bool isFound = false;

        foreach (Book book in _books)
        {
            if (book.Title.ToLower().Contains(userParameterInput))
            {
                book.ShowInfo();
                isFound = true;
            }
        }

        if (isFound == false)
        {
            Console.WriteLine("Not found.");
        }
    }


    class Book
    {
        private static int s_idCounter;

        private int _id;

        public Book(string author, string title, int year)
        {
            _id = ++s_idCounter;
            Author = author;
            Title = title;
            Year = year;
        }

        public string Author { get; private set; }
        public string Title { get; private set; }

        public int Year { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{_id}.{Author} - {Title} {Year}.");
        }
    }
}