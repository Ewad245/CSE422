using Lab3.Models;

namespace Lab3.Services;

public class NotificationService
{
    public virtual void SendNotification(string message)
    {
        Console.WriteLine(message);
    }

    public virtual void SendNotification(string message, string recipient)
    {
        Console.WriteLine(message);
        Console.WriteLine(recipient);
    }

    public void SendNotification(string message, List<string> recipients)
    {
        Console.WriteLine(message);
        Console.WriteLine(string.Join(", ", recipients));
    }

    public void SendNotification(Transaction transaction)
    {
        if (transaction.GetType() == typeof(BorrowTransaction))
        {
            Console.WriteLine($"Borrow transaction made from {transaction.Member.Name} successfully");
            Console.WriteLine($"Date: {transaction.TransactionDate}");
        } 
        else if(transaction.GetType() == typeof(ReturnTransaction))
        {
            Console.WriteLine($"Return transaction made from {transaction.Member.Name} successfully");
            Console.WriteLine($"Date: {transaction.TransactionDate}");
        }
    }
}