namespace Lab5.Strategy
{
    public class NewspaperLoanFeeStrategy : ILoanFeeStrategy
    {
        public decimal CalculateFee(int daysOverdue)
        {
            // Newspapers have lower fees: $0.15 per day
            return daysOverdue * 0.15m;
        }
    }
} 