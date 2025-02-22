using LibraryManagementSystem.Services;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize repositories
        IBookRepository bookRepository = new InMemoryBookRepository();
        IReaderRepository readerRepository = new InMemoryReaderRepository();

        // Initialize services
        ILoanService loanService = new LoanService(bookRepository, readerRepository);
        ILoanService eBookLoanService = new EBookLoanService(bookRepository, readerRepository);
        IReportService reportService = new ReportService(readerRepository, bookRepository);
        IBookManagementService bookManagementService = new BookManagementService(bookRepository);

        // Example usage
        try
        {
            // Add a new book
            var newBook = new Book
            {
                Title = "Design Patterns",
                Author = "Gang of Four",
                Category = "Programming",
                Quantity = 3
            };
            bookManagementService.AddBook(newBook);

            // Borrow a book
            var borrowResult = loanService.BorrowBook("1", "2"); // Reader 1 borrows book 2
            Console.WriteLine($"Borrow result: {borrowResult.Message}");

            // Generate reader report
            var readerReport = reportService.GenerateReaderReport("1");
            Console.WriteLine("\nReader Report:");
            Console.WriteLine(readerReport.Content);

            // Generate overall report
            var overallReport = reportService.GenerateOverallReport();
            Console.WriteLine("\nOverall Library Report:");
            Console.WriteLine(overallReport.Content);

            // Search for books
            var programmingBooks = bookRepository.SearchByCategory("Programming");
            Console.WriteLine("\nProgramming Books:");
            foreach (var book in programmingBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}