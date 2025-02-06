using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library myLibrary = new Library();

        myLibrary.AddBook(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979));
        myLibrary.AddBook(new Book("Pride and Prejudice", "Jane Austen", 1813));
        myLibrary.AddBook(new Book("1984", "George Orwell", 1949));

        myLibrary.DisplayAllBooks();

        Library emptyLibrary = new Library();
        emptyLibrary.DisplayAllBooks();
    }
}