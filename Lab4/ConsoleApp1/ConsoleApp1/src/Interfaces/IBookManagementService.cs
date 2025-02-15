public interface IBookManagementService
{
    Result AddBook(Book book);
    Result UpdateBookQuantity(string bookId, int newQuantity);
    Result RemoveBook(string bookId);
    IEnumerable<Book> GetAllBooks();
    Book GetBookById(string bookId);
} 