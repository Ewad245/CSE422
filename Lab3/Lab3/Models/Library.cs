namespace Lab3.Models;

public class Library
{
    private string _libraryName;
    private List<Book> _books;
    private List<Member> _members;
    
    // Declare the event using Action<Book, Member> delegate
    public event Action<Transaction> OnBookBorrowed;

    public Library()
    {
        LibraryName = "Library";
        Books = new List<Book>();
        Members = new List<Member>();
    }

    public Library(string libraryName, List<Book> books)
    {
        LibraryName = libraryName;
        Books = books;
    }

    public Library(Library library)
    {
        LibraryName = library.LibraryName;
        Books = library.Books;
        Members = library.Members;
    }
    
    public string LibraryName { get; set; }
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }

    public void DisplayLibraryInfo()
    {
        Console.WriteLine($"Number of books: {_books.Count}");
        Console.WriteLine($"Number of members: {_members.Count}");
        Console.WriteLine($"Library Name: {_libraryName}");
    }
    
    // Method to borrow a book
    public void BorrowBook(Book book, Member member)
    {
        if (Books.Contains(book))
        {
            if (!member.isPremium(member)) return;
            if (member.BorrowBook(book))
            {
                // Trigger the event when a book is borrowed
                OnBookBorrowed?.Invoke(member.Transactions.Peek());
            }
        }
        else
        {
            Console.WriteLine($"Book {book.Title} is not available.");
        }
    }
    
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddMember(Member member)
    {
        Members.Add(member);
    }
}