public interface ILoanService
{
    Result BorrowBook(string readerId, string bookId);
    Result ReturnBook(string readerId, string bookId);
    IEnumerable<LoanRecord> GetActiveLoans(string readerId);
} 