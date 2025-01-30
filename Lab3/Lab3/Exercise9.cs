using Lab3.Models;

namespace Lab3;

public class Exercise9
{
    public static void Test()
    {
        // Create instances of BookClass
        var bookClass1 = new BookClass { ISBN = "123", Title = "C# Basics", Author = "John Doe" };
        var bookClass2 = new BookClass { ISBN = "123", Title = "C# Basics", Author = "John Doe" };

        // Create instances of BookRecord
        var bookRecord1 = new BookRecord("123", "C# Basics", "John Doe");
        var bookRecord2 = new BookRecord("123", "C# Basics", "John Doe");
        
        //Compare class hash
        Console.WriteLine(bookClass1.GetHashCode());
        Console.WriteLine(bookClass2.GetHashCode());
        Console.WriteLine(bookRecord1.GetHashCode());
        Console.WriteLine(bookRecord2.GetHashCode());
        
        // Compare using == operator
        Console.WriteLine("Class Comparison using ==: " + (bookClass1 == bookClass2)); // False (reference equality)
        Console.WriteLine("Record Comparison using ==: " + (bookRecord1 == bookRecord2)); // True (value equality)
        
        // Modify properties
        var modifiedBookRecord = bookRecord1 with { Title = "Advanced C#" };

        // Print results
        Console.WriteLine("Original BookRecord: " + bookRecord1.Title);
        Console.WriteLine("Modified BookRecord: " + modifiedBookRecord.Title);
    }
}