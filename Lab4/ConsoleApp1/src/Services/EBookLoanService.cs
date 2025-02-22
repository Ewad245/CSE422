using System;
using System.Collections.Generic;
using System.Linq;

public class EBookLoanService : ILoanService
{
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;
    private const int MaxEBooksPerReader = 5; // Different limit for eBooks

    public EBookLoanService(IBookRepository bookRepository, IReaderRepository readerRepository)
    {
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public Result BorrowBook(string readerId, string bookId)
    {
        var reader = _readerRepository.GetById(readerId);
        var book = _bookRepository.GetById(bookId);

        if (book.Type != BookType.EBook)
        {
            return new Result { Success = false, Message = "This service is for eBooks only" };
        }

        var currentEBooks = reader.BorrowedBooks
            .Count(x => x.ReturnDate == null && 
                       _bookRepository.GetById(x.BookId).Type == BookType.EBook);

        if (currentEBooks >= MaxEBooksPerReader)
        {
            return new Result { Success = false, Message = "Reader has reached maximum eBook limit" };
        }

        // For eBooks, we don't decrease quantity as they can be borrowed multiple times
        reader.BorrowedBooks.Add(new LoanRecord 
        { 
            BookId = bookId, 
            BorrowDate = DateTime.Now 
        });

        _readerRepository.Update(reader);

        return new Result { Success = true };
    }

    // Implement other interface methods similarly
    // ... existing code ...

    public IEnumerable<LoanRecord> GetActiveLoans(string readerId)
    {
        var reader = _readerRepository.GetById(readerId);
        return reader.BorrowedBooks
            .Where(x => x.ReturnDate == null && 
                       _bookRepository.GetById(x.BookId).Type == BookType.EBook);
    }

    public Result ReturnBook(string readerId, string bookId)
    {
        var reader = _readerRepository.GetById(readerId);
        var book = _bookRepository.GetById(bookId);

        if (book.Type != BookType.EBook)
        {
            return new Result { Success = false, Message = "This service is for eBooks only" };
        }

        var loan = reader.BorrowedBooks
            .FirstOrDefault(x => x.BookId == bookId && x.ReturnDate == null);

        if (loan == null)
        {
            return new Result { Success = false, Message = "Book not found in reader's loans" };
        }

        loan.ReturnDate = DateTime.Now;
        _readerRepository.Update(reader);

        return new Result { Success = true };
    }
} 