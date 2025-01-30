namespace Lab3.Models;

public class BorrowTransaction: Transaction
{
    private Book _bookBorrowed;

    public BorrowTransaction(Member member, DateTime transactionDate, Book bookBorrowed) : base(member, transactionDate)
    {
        this.BookBorrowed = bookBorrowed;
        Execute();
    }

    public BorrowTransaction() : base()
    {
        
    }

    public Book BookBorrowed { get; set; }
    
    
    public override void Execute()
    {
        Console.WriteLine("Borrow Transaction");
        Result = true;
    }
}