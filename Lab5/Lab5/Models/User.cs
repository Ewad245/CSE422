namespace Lab5.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Loan> Loans { get; set; }

        public User()
        {
            Loans = new List<Loan>();
        }
    }
} 