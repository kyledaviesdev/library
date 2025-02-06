class Program
{
    static void Main(string[] args)
    {
        Library myLibrary = new Library();

        myLibrary.AddBook(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, 1234));
        myLibrary.AddBook(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, 1237));
        myLibrary.AddBook(new Book("Pride and Prejudice", "Jane Austen", 1813, 1235));
        myLibrary.AddBook(new Book("1984", "George Orwell", 1949, 1236));

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Check out a book");
            Console.WriteLine("3. Find a book");
            Console.WriteLine("4. Return a book"); // New option
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myLibrary.DisplayAllBooks();
                    break;
                case "2":
                    myLibrary.CheckOutBook();
                    break;
                case "3":
                    myLibrary.FindBook();
                    break;
                case "4":
                    myLibrary.ReturnBook(); // Call ReturnBook method
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}