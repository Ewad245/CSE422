public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public BookType Type { get; set; } = BookType.Physical;
}

public enum BookType
{
    Physical,
    EBook,
    Magazine
} 