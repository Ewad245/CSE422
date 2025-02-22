using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryBookRepository : IBookRepository
{
    private readonly Dictionary<string, Book> _books = new();

    public InMemoryBookRepository()
    {
        // Add sample data
        AddSampleBooks();
    }

    public Book GetById(string id)
    {
        if (_books.TryGetValue(id, out var book))
            return book;
        throw new KeyNotFoundException($"Book with ID {id} not found");
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        return _books.Values
            .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Book> SearchByCategory(string category)
    {
        return _books.Values
            .Where(b => b.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public void Add(Book book)
    {
        if (string.IsNullOrEmpty(book.Id))
            book.Id = Guid.NewGuid().ToString();
        
        _books[book.Id] = book;
    }

    public void Update(Book book)
    {
        if (!_books.ContainsKey(book.Id))
            throw new KeyNotFoundException($"Book with ID {book.Id} not found");
        
        _books[book.Id] = book;
    }

    private void AddSampleBooks()
    {
        var books = new[]
        {
            new Book { Id = "1", Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = "Fiction", Quantity = 5 },
            new Book { Id = "2", Title = "1984", Author = "George Orwell", Category = "Fiction", Quantity = 3 },
            new Book { Id = "3", Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Quantity = 2 }
        };

        foreach (var book in books)
        {
            Add(book);
        }
    }
} 