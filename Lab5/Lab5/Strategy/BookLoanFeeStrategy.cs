namespace Lab5.Strategy
{
    public class BookLoanFeeStrategy : ILoanFeeStrategy
    {
        public decimal CalculateFee(int daysOverdue)
        {
            // Books have higher fees: $0.50 per day
            return daysOverdue * 0.50m;
        }
    }
} 