using Lab3.Models;
using Lab3.Services;

namespace Lab3;

public class Exercise10
{
    public static void Run()
    {
        Library library = new Library();
        NotificationService notificationService = new NotificationService();

        // Create some books and a member
        Book book1 = new Book
        {
            ISBN = "1",
            Title = "C# Programming",
            Author = "John Smith",
            CopiesAvaialble = 3,
            Year = 2000
        };
        Book book2 = new Book
        {
            ISBN = "2",
            Title = "Design Patterns",
            Author = "Eric Freeman",
            CopiesAvaialble = 2,
            Year = 2003
        };
        Member member = new Member();
        member.Email = "john.freeman@gmail.com";
        member.Name = "John Smith";
        PremiumMember member2 = new PremiumMember();
        member2.Email = "john.som@gmail.com";
        member2.Name = "John Somme";
        member2.MembershipExpire = DateTime.Parse("5/01/2026");
        member2.MaxBooksAllowed = 5;

        // Add books to the library
        library.AddBook(book1);
        library.AddBook(book2);
        
        //Add members
        library.AddMember(member);
        library.AddMember(member2);

        // Subscribe method to the OnBookBorrowed event
        library.OnBookBorrowed += notificationService.SendNotification;

        // Borrow a book
        library.BorrowBook(book1, member2);    
    }
}