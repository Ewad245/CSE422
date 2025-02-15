public class Reader
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<LoanRecord> BorrowedBooks { get; set; } = new();
}

public class LoanRecord
{
    public string BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
} 