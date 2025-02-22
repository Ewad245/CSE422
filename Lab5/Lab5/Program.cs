using Lab5.Models;
using Lab5.Factory;
using Lab5.Observer;
using Lab5.Singleton;
using Lab5.Strategy;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get library instance
            var library = LibraryManager.Instance;
            
            // Create users
            var user1 = new LibraryUser { Name = "John" };
            var user2 = new LibraryUser { Name = "Alice" };
            
            // Register users for notifications
            library.AddObserver(user1);
            library.AddObserver(user2);

            // Create document factories
            var bookFactory = new BookFactory();
            var magazineFactory = new MagazineFactory();
            var newspaperFactory = new NewspaperFactory();

            // Create and add documents
            var book = bookFactory.CreateDocument("Design Patterns", "B001");
            var magazine = magazineFactory.CreateDocument("Tech Monthly", "M001");
            var newspaper = newspaperFactory.CreateDocument("Daily News", "N001");

            library.AddDocument(book);
            library.AddDocument(magazine);
            library.AddDocument(newspaper);

            // Demonstrate fee calculation using strategy pattern
            Console.WriteLine($"Late fee for book (5 days): ${book.CalculateLateFee(5)}");

            Console.WriteLine($"Late fee for magazine (5 days): ${magazine.CalculateLateFee(5)}");

            Console.WriteLine($"Late fee for newspaper (5 days): ${newspaper.CalculateLateFee(5)}");

            // We can also change the strategy at runtime if needed
            book.SetLoanFeeStrategy(new MagazineLoanFeeStrategy());
            Console.WriteLine($"Late fee for book with magazine strategy (5 days): ${book.CalculateLateFee(5)}");
        }
    }
}