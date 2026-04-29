using _10_GenericTypesCollections;

internal class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
        Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
        Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
        Book book4 = new Book(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
        Book book5 = new Book(5, "Qiriq Budaq", "Elchin", 1998, 350);

        List<Book> allBooks = new List<Book> { book1, book2, book3, book4, book5 };

        Console.WriteLine("=== Books ===");
        foreach (var book in allBooks)
        {
            book.DisplayInfo();
        }

        Console.WriteLine("\n=== Library<T> ===");
        Library<Book> library = new Library<Book>("Milli Kitabxana");

        foreach (var book in allBooks)
        {
            library.Add(book);
        }

        Console.WriteLine($"Count: {library.Count()}");

        library.FindByIndex(0)?.DisplayInfo();
        library.FindByIndex(2)?.DisplayInfo();

        foreach (var book in library.GetAll())
        {
            book.DisplayInfo();
        }

        Console.WriteLine("\n=== Members ===");

        List<Member> members = new List<Member>
            {
                new Member(1, "Ali Memmedov", "ali@mail.com"),
                new Member(2, "Leyla Hesenova", "leyla@mail.com"),
                new Member(3, "Vuqar Eliyev", "vuqar@mail.com")
            };

        var m1 = members[0];

        m1.BorrowBook(book1);
        m1.BorrowBook(book2);

        m1.DisplayBorrowedBooks();

        m1.ReturnBook(1);

        m1.DisplayBorrowedBooks();

        m1.BorrowBook(book3);
        m1.BorrowBook(book4);
        m1.BorrowBook(book5); 

        m1.BorrowBook(book1); 

        
        Console.WriteLine("\n=== Dictionary ===");

        BookManager manager = new BookManager();

        foreach (var book in allBooks)
        {
            manager.AddBook(book);
        }

        var orwellBooks = manager.GetBooksByAuthor("George Orwell");
        Console.WriteLine("George Orwell books:");
        foreach (var b in orwellBooks) b.DisplayInfo();

        var aytmatovBooks = manager.GetBooksByAuthor("Cingiz Aytmatov");
        Console.WriteLine("Aytmatov books:");
        foreach (var b in aytmatovBooks) b.DisplayInfo();

        var londonBooks = manager.GetBooksByAuthor("Jack London");
        Console.WriteLine("Jack London books:");
        foreach (var b in londonBooks) b.DisplayInfo();

        var unknown = manager.GetBooksByAuthor("Dostoyevski");
        Console.WriteLine($"Unknown author count: {unknown.Count}");


        Console.WriteLine("\n=== Queue ===");

        manager.AddToWaitingQueue("Nigar");
        manager.AddToWaitingQueue("Reshad");
        manager.AddToWaitingQueue("Sabine");

        Console.WriteLine($"Queue count: {manager.WaitingQueue.Count}");

        Console.WriteLine($"Serving: {manager.ServeNextInQueue()}");
        Console.WriteLine($"Queue count: {manager.WaitingQueue.Count}");

        Console.WriteLine($"Serving: {manager.ServeNextInQueue()}");
        Console.WriteLine($"Queue count: {manager.WaitingQueue.Count}");

        Console.WriteLine($"Serving: {manager.ServeNextInQueue()}");
        Console.WriteLine($"Queue count: {manager.WaitingQueue.Count}");

        Console.WriteLine("\n=== Stack ===");

        manager.ReturnBook(book1);
        manager.ReturnBook(book2);
        manager.ReturnBook(book3);

        Console.WriteLine($"Stack count: {manager.RecentlyReturned.Count}");

        manager.GetLastReturnedBook()?.DisplayInfo();

        manager.RecentlyReturned.Pop();

        Console.WriteLine($"Stack count: {manager.RecentlyReturned.Count}");

        manager.GetLastReturnedBook()?.DisplayInfo();

        Console.WriteLine("\n=== Search ===");

        var found = manager.SearchByTitle("1984");
        found?.DisplayInfo();

        var notFound = manager.SearchByTitle("Harry Potter");

        if (notFound == null)
        {
            Console.WriteLine("Book not found");
        }

        Console.WriteLine("\n=== Statistics ===");

        Console.WriteLine($"Total books: {manager.Books.Count}");
        Console.WriteLine($"Total members: {members.Count}");
        Console.WriteLine($"Queue count: {manager.WaitingQueue.Count}");
        Console.WriteLine($"Stack count: {manager.RecentlyReturned.Count}");

        int minYear = int.MaxValue;
        int maxYear = int.MinValue;

        foreach (var b in manager.Books)
        {
            if (b.Year < minYear)
                minYear = b.Year;

            if (b.Year > maxYear)
                maxYear = b.Year;
        }

        Console.WriteLine($"Oldest year: {minYear}");
        Console.WriteLine($"Newest year: {maxYear}");
    }
}
