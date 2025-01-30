namespace Lab3.Models;

public class LibraryCard
{
    private readonly string _cardNumber;
    private Member _owner;
    private DateTime _issueDate;
    
    public Member Owner { get; set; }
    public DateTime IssueDate { get; private set; }

    public LibraryCard(string cardNumber, Member owner)
    {
        _cardNumber = cardNumber;
        _owner = owner;
        _issueDate = DateTime.Now;
    }

    public void RenewCard()
    {
        IssueDate = DateTime.Now;
    }
    
}