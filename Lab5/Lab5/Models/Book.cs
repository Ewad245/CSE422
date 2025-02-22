using Lab5.Strategy;

namespace Lab5.Models
{
    public class Book : Document
    {
        public Book()
        {
            _loanFeeStrategy = new BookLoanFeeStrategy();
        }
    }
} 