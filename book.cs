using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishDate { get; set; }
    public int LibraryId { get; set; } // Unique ID for each copy
    public bool IsAvailable { get; set; }

    public Book(string title, string author, int publishDate, int libraryId)
    {
        Title = title;
        Author = author;
        PublishDate = publishDate;
        LibraryId = libraryId;
        IsAvailable = true;
    }

    public void Display()
    {
        Console.WriteLine($"{Title} ({Author}) {PublishDate} (ID: {LibraryId}) | {(IsAvailable ? "Available" : "Unavailable")}");
    }
}