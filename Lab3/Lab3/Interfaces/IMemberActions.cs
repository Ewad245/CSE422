using Lab3.Models;

namespace Lab3.Interfaces;

public interface IMemberActions
{
    Boolean BorrowBook(Book book);
    Boolean ReturnBook(Book book);
}