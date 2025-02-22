using Lab5.Strategy;

namespace Lab5.Models
{
    public class Magazine : Document
    {
        public Magazine()
        {
            _loanFeeStrategy = new MagazineLoanFeeStrategy();
        }
    }
} 