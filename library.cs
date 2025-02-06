using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> Books { get; set; } = new List<Book>(); // Auto-property initializer

    public void AddBook(Book book)
    {
        Books.Add(book);
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
}