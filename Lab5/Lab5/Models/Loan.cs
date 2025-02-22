namespace Lab5.Models
{
    public class Loan
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DocumentId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        
        // Navigation properties
        public User User { get; set; }
        public Document Document { get; set; }

        public bool IsOverdue()
        {
            return !ReturnDate.HasValue && DateTime.Now > DueDate;
        }

        public int GetOverdueDays()
        {
            if (!IsOverdue()) return 0;
            
            var endDate = ReturnDate ?? DateTime.Now;
            return (int)(endDate - DueDate).TotalDays;
        }
    }
} 