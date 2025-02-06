using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Library myLibrary = new Library();

        // Load books from JSON file
        string jsonFilePath = @"C:\CSE 310\library\books.json";
        myLibrary.LoadBooksFromJson(jsonFilePath);


        myLibrary.DisplayAllBooks();

        Library emptyLibrary = new Library();
        emptyLibrary.DisplayAllBooks();
    }
}