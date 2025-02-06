using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Library
{
    private List<Book> Books { get; set; } = new List<Book>();

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

    public void LoadBooksFromJson(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            List<Book> loadedBooks = JsonSerializer.Deserialize<List<Book>>(json);

            if (loadedBooks != null)  // Handle potential null result.
            {
                Books.AddRange(loadedBooks);
            }
            else
            {
                Console.WriteLine($"Error: Could not deserialize the JSON data in {filePath}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file {filePath} was not found.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}