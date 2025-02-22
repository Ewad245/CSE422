using Lab5.Strategy;

namespace Lab5.Models
{
    public abstract class Document
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }  // Physical location in library
        public List<Loan> Loans { get; set; }
        protected ILoanFeeStrategy _loanFeeStrategy;

        public Document()
        {
            Loans = new List<Loan>();
        }

        public void SetLoanFeeStrategy(ILoanFeeStrategy strategy)
        {
            _loanFeeStrategy = strategy;
        }

        public decimal CalculateLateFee(int daysOverdue)
        {
            return _loanFeeStrategy.CalculateFee(daysOverdue);
        }
    }
} 