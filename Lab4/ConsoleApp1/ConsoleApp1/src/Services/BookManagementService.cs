namespace LibraryManagementSystem.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IBookRepository _bookRepository;

        public BookManagementService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Result AddBook(Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                {
                    return new Result { Success = false, Message = "Title and Author are required" };
                }

                if (book.Quantity < 0)
                {
                    return new Result { Success = false, Message = "Quantity cannot be negative" };
                }

                _bookRepository.Add(book);
                return new Result { Success = true, Message = "Book added successfully" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = $"Error adding book: {ex.Message}" };
            }
        }

        public Result UpdateBookQuantity(string bookId, int newQuantity)
        {
            try
            {
                if (newQuantity < 0)
                {
                    return new Result { Success = false, Message = "Quantity cannot be negative" };
                }

                var book = _bookRepository.GetById(bookId);
                book.Quantity = newQuantity;
                _bookRepository.Update(book);

                return new Result { Success = true, Message = "Book quantity updated successfully" };
            }
            catch (KeyNotFoundException)
            {
                return new Result { Success = false, Message = "Book not found" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = $"Error updating book quantity: {ex.Message}" };
            }
        }

        public Result RemoveBook(string bookId)
        {
            try
            {
                var book = _bookRepository.GetById(bookId);
                book.Quantity = 0; // Soft delete by setting quantity to 0
                _bookRepository.Update(book);

                return new Result { Success = true, Message = "Book removed successfully" };
            }
            catch (KeyNotFoundException)
            {
                return new Result { Success = false, Message = "Book not found" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = $"Error removing book: {ex.Message}" };
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.SearchByCategory(""); // Empty category returns all books
        }

        public Book GetBookById(string bookId)
        {
            return _bookRepository.GetById(bookId);
        }
    }
}