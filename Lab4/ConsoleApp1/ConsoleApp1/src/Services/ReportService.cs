using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class ReportService : IReportService
{
    private readonly IReaderRepository _readerRepository;
    private readonly IBookRepository _bookRepository;

    public ReportService(IReaderRepository readerRepository, IBookRepository bookRepository)
    {
        _readerRepository = readerRepository;
        _bookRepository = bookRepository;
    }

    public Report GenerateReaderReport(string readerId)
    {
        var reader = _readerRepository.GetById(readerId);
        var activeLoans = reader.BorrowedBooks.Where(x => x.ReturnDate == null);
        
        var content = new StringBuilder();
        content.AppendLine($"Report for: {reader.Name}");
        content.AppendLine($"Total books borrowed: {reader.BorrowedBooks.Count}");
        content.AppendLine($"Currently borrowed books: {activeLoans.Count()}");
        content.AppendLine("\nActive Loans:");

        foreach (var loan in activeLoans)
        {
            var book = _bookRepository.GetById(loan.BookId);
            content.AppendLine($"- {book.Title} (Borrowed on: {loan.BorrowDate:d})");
        }

        return new Report
        {
            Title = $"Reader Report - {reader.Name}",
            GeneratedAt = DateTime.Now,
            Content = content.ToString()
        };
    }

    public Report GenerateOverallReport()
    {
        var readers = _readerRepository.GetAll();
        var content = new StringBuilder();
        
        content.AppendLine("Library Overall Report");
        content.AppendLine("=====================");
        
        foreach (var reader in readers)
        {
            var activeLoans = reader.BorrowedBooks.Count(x => x.ReturnDate == null);
            content.AppendLine($"\nReader: {reader.Name}");
            content.AppendLine($"Active loans: {activeLoans}");
            
            if (activeLoans > 0)
            {
                content.AppendLine("Currently borrowed books:");
                foreach (var loan in reader.BorrowedBooks.Where(x => x.ReturnDate == null))
                {
                    var book = _bookRepository.GetById(loan.BookId);
                    content.AppendLine($"- {book.Title}");
                }
            }
        }

        return new Report
        {
            Title = "Library Overall Report",
            GeneratedAt = DateTime.Now,
            Content = content.ToString()
        };
    }
} 