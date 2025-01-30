namespace Lab3.Models;

public class ReturnTransaction: Transaction
{
    private Book _bookReturned;
    
    public Book BookReturned { get; set; }
    
    public ReturnTransaction(Member member, DateTime transactionDate, Book bookReturn) : base(member, transactionDate)
    {
        this.BookReturned = bookReturn;
        Execute();
    }

    public ReturnTransaction() : base()
    {
        
    }

    public override void Execute()
    {
        Console.WriteLine("Returning Book");
        Result = true;
    }
}