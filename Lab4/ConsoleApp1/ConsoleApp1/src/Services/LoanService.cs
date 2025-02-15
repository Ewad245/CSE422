namespace LibraryManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private const int MaxBooksPerReader = 3;

        public LoanService(IBookRepository bookRepository, IReaderRepository readerRepository)
        {
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
        }

        public Result BorrowBook(string readerId, string bookId)
        {
            var reader = _readerRepository.GetById(readerId);
            var book = _bookRepository.GetById(bookId);

            if (reader.BorrowedBooks.Count(x => x.ReturnDate == null) >= MaxBooksPerReader)
            {
                return new Result { Success = false, Message = "Reader has reached maximum book limit" };
            }

            if (book.Quantity <= 0)
            {
                return new Result { Success = false, Message = "Book is not available" };
            }

            book.Quantity--;
            reader.BorrowedBooks.Add(new LoanRecord 
            { 
                BookId = bookId, 
                BorrowDate = DateTime.Now 
            });

            _bookRepository.Update(book);
            _readerRepository.Update(reader);

            return new Result { Success = true };
        }

        public Result ReturnBook(string readerId, string bookId)
        {
            var reader = _readerRepository.GetById(readerId);
            var book = _bookRepository.GetById(bookId);

            var loan = reader.BorrowedBooks
                .FirstOrDefault(x => x.BookId == bookId && x.ReturnDate == null);

            if (loan == null)
            {
                return new Result { Success = false, Message = "Book not found in reader's loans" };
            }

            loan.ReturnDate = DateTime.Now;
            book.Quantity++;

            _bookRepository.Update(book);
            _readerRepository.Update(reader);

            return new Result { Success = true };
        }

        public IEnumerable<LoanRecord> GetActiveLoans(string readerId)
        {
            var reader = _readerRepository.GetById(readerId);
            return reader.BorrowedBooks.Where(x => x.ReturnDate == null);
        }
    }
} 