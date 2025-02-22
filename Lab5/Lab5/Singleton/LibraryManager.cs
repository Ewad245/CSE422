using Lab5.Models;
using Lab5.Observer;

namespace Lab5.Singleton
{
    public class LibraryManager
    {
        private static LibraryManager instance;
        private static readonly object lockObject = new object();
        
        private List<Document> documents;
        private List<User> users;
        private List<Loan> loans;
        private List<ILibraryObserver> observers;

        private LibraryManager()
        {
            documents = new List<Document>();
            users = new List<User>();
            loans = new List<Loan>();
            observers = new List<ILibraryObserver>();
        }

        public static LibraryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new LibraryManager();
                        }
                    }
                }
                return instance;
            }
        }

        // Document management
        public void AddDocument(Document document)
        {
            documents.Add(document);
            NotifyObservers($"New document added: {document.Title}");
        }

        public Document GetDocument(string id)
        {
            return documents.FirstOrDefault(d => d.Id == id);
        }

        // User management
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUser(string id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        // Loan management
        public Loan CreateLoan(string userId, string documentId, int loanDays = 14)
        {
            var user = GetUser(userId);
            var document = GetDocument(documentId);

            if (user == null || document == null || !document.IsAvailable)
                return null;

            var loan = new Loan
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                DocumentId = documentId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(loanDays),
                User = user,
                Document = document
            };

            document.IsAvailable = false;
            loans.Add(loan);
            user.Loans.Add(loan);
            document.Loans.Add(loan);

            NotifyObservers($"Document '{document.Title}' has been borrowed by {user.Name}");
            return loan;
        }

        public void ReturnDocument(string loanId)
        {
            var loan = loans.FirstOrDefault(l => l.Id == loanId);
            if (loan == null) return;

            loan.ReturnDate = DateTime.Now;
            loan.Document.IsAvailable = true;

            var overdueDays = loan.GetOverdueDays();
            if (overdueDays > 0)
            {
                loan.LateFee = loan.Document.CalculateLateFee(overdueDays);
            }

            NotifyObservers($"Document '{loan.Document.Title}' has been returned by {loan.User.Name}");
        }

        // Observer pattern methods
        public void AddObserver(ILibraryObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
} 