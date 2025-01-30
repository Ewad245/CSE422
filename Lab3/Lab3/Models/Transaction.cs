namespace Lab3.Models;

public abstract class Transaction
{
    private static int count = 0;
    private int _transactionId;
    private DateTime _transactionDate;
    private Member _member;
    private Boolean result;
    
    public int TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public Member Member { get; set; }
    public Boolean Result { get; set; }

    protected Transaction(Member member, DateTime transactionDate)
    {
        this.TransactionId = count;
        count++;
        this.Member = member;
        this.TransactionDate = transactionDate.Date;
    }

    protected Transaction()
    {
        throw new NotImplementedException();
    }

    public abstract void Execute();
}