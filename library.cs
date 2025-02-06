using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> Books { get; set; } = new List<Book>();
    private int nextLibraryId = 1; // To generate unique IDs

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddBook(string title, string author, int publishDate) // Overload to auto-generate ID
    {
        Books.Add(new Book(title, author, publishDate, nextLibraryId++));
    }
    public void DisplayAllBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("The library is empty.");
            return;
        }

        Console.WriteLine("Books in the library:");
        foreach (Book book in Books)
        {
            book.Display();
        }
    }

    public void CheckOutBook()
    {
        Console.Write("Enter the title of the book to check out: ");
        string title = Console.ReadLine();

        List<Book> matchingBooks = Books.FindAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (matchingBooks.Count == 0)
        {
            Console.WriteLine($"No books found with the title '{title}'.");
            return;
        }

        Console.WriteLine("Matching books:");
        foreach (Book book in matchingBooks)
        {
            book.Display();
        }

        Console.Write("Enter the Library ID of the book to check out: ");
        if (!int.TryParse(Console.ReadLine(), out int libraryId))
        {
            Console.WriteLine("Invalid Library ID.");
            return;
        }

        foreach (Book book in matchingBooks)
        {
            if (book.LibraryId == libraryId && book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine($"{book.Title} (ID: {book.LibraryId}) checked out successfully.");
                return;
            }
        }

        Console.WriteLine($"Book with title '{title}' and ID '{libraryId}' not found or unavailable.");
    }

    public void FindBook()
    {
        bool found = false;
        while (!found) // Loop until the user finds the book or chooses to stop
        {
            Console.Write("Enter search term (title, author, or year, or type 'exit' to stop): ");
            string searchTerm = Console.ReadLine();

            if (searchTerm.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return; // Exit the FindBook method if the user types 'exit'
            }

            List<Book> matchingBooks = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    book.PublishDate.ToString().Contains(searchTerm))
                {
                    matchingBooks.Add(book);
                }
            }

            if (matchingBooks.Count == 0)
            {
                Console.WriteLine("No matching books found. Please try again.");
            }
            else if (matchingBooks.Count == 1) // If only one match is found, assume it's the right one
            {
                Console.WriteLine("Found book:");
                matchingBooks[0].Display();
                found = true; // Set found to true to exit the loop
            }
            else // Multiple matches, ask the user to choose
            {
                Console.WriteLine("Multiple matches found. Please specify which book you are looking for:");
                for (int i = 0; i < matchingBooks.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    matchingBooks[i].Display();
                }

                Console.Write("Enter the number of the book you want, type 'n' if you want to search again, or type 'exit' to stop: ");
                string bookChoice = Console.ReadLine();

                if (bookChoice.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return; // Exit FindBook if user types 'exit'
                }

                if (int.TryParse(bookChoice, out int choice) && choice > 0 && choice <= matchingBooks.Count)
                {
                    Console.WriteLine("Found book:");
                    matchingBooks[choice - 1].Display();
                    found = true; // Found the book, exit loop
                }
                else
                {
                    Console.WriteLine("Sorry we didn't find the book you were looking for. Please try again.");
                }
            }
        }
    }
    public void ReturnBook()
    {
        Console.Write("Enter the title of the book to return: ");
        string title = Console.ReadLine();

        List<Book> matchingBooks = Books.FindAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (matchingBooks.Count == 0)
        {
            Console.WriteLine($"No books found with the title '{title}'.");
            return;
        }

        Console.WriteLine("Matching books:");
        foreach (Book book in matchingBooks)
        {
            book.Display();
        }

        Console.Write("Enter the Library ID of the book to return: ");
        if (!int.TryParse(Console.ReadLine(), out int libraryId))
        {
            Console.WriteLine("Invalid Library ID.");
            return;
        }

        foreach (Book book in matchingBooks)
        {
            if (book.LibraryId == libraryId)
            {
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"{book.Title} (ID: {book.LibraryId}) returned successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine($"{book.Title} (ID: {book.LibraryId}) is already available.");
                    return;
                }
            }
        }

        Console.WriteLine($"Book with title '{title}' and ID '{libraryId}' not found.");
    }
}