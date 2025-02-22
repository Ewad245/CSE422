namespace Lab5.Strategy
{
    public interface ILoanFeeStrategy
    {
        decimal CalculateFee(int daysOverdue);
    }
} 