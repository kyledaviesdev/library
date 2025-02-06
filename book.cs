using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; } // Use properties (better practice)
    public string Author { get; set; }
    public int PublishDate { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, int publishDate)
    {
        Title = title;
        Author = author;
        PublishDate = publishDate;
        IsAvailable = true;
    }

    public void Display()
    {
        Console.WriteLine($"{Title} ({Author}) {PublishDate} | {(IsAvailable ? "Available" : "Unavailable")}"); // Nicer output
    }
}