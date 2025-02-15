public interface IBookRepository
{
    Book GetById(string id);
    IEnumerable<Book> SearchByTitle(string title);
    IEnumerable<Book> SearchByCategory(string category);
    void Add(Book book);
    void Update(Book book);
} 