namespace Lab3.Models;

public class PremiumMember: Member
{
    private DateTime _membershipExpire;
    private int _maxBooksAllowed;
    
    public DateTime MembershipExpire { get; set; }
    public int MaxBooksAllowed { get; set; }

    public override string DisplayInfo()
    {
        return $"Name: {Name}, Membership expire: {_membershipExpire}, Max books allowed: {_maxBooksAllowed}";
    }

    public override Boolean BorrowBook(Book book)
    {
        if (_membershipExpire > DateTime.Now || MaxBooksAllowed > 0)
        {
            if (book.CopiesAvaialble > 0)
            {
                _maxBooksAllowed--;
                book.CopiesAvaialble--;
                Transaction transaction = new BorrowTransaction(this, DateTime.Now, book);
                Transactions.Push(transaction);
                return true;
            }
        }
        return false;
    }

    public override Boolean ReturnBook(Book book)
    {
        if (_membershipExpire < DateTime.Now)
        {
            _maxBooksAllowed++;
            book.CopiesAvaialble++;
            Transactions.Push(new ReturnTransaction(this,DateTime.Now, book));
            return true;
        }
        return false;
    }
}