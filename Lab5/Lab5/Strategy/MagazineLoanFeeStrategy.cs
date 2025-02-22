namespace Lab5.Strategy
{
    public class MagazineLoanFeeStrategy : ILoanFeeStrategy
    {
        public decimal CalculateFee(int daysOverdue)
        {
            // Magazines have medium fees: $0.25 per day
            return daysOverdue * 0.25m;
        }
    }
} 