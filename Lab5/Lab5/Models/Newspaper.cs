using Lab5.Strategy;

namespace Lab5.Models
{
    public class Newspaper : Document
    {
        public Newspaper()
        {
            _loanFeeStrategy = new NewspaperLoanFeeStrategy();
        }
    }
} 