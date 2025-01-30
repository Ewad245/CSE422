using Lab3.Interfaces;

namespace Lab3.Models;

public class Book: IPrintable
{
    //Field
    private string _ISBN;
    private string _title;
    private string _author;
    private int _year;
    private int _copiesAvaialble;

    //Properties
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public int Year
    {
        get => _year;
        set => _year = value >=0 ? value : throw new ArgumentException();
    }

    public int CopiesAvaialble
    {
        get => _copiesAvaialble;
        set => _copiesAvaialble = value >= 0 ? value : throw new ArgumentException();
    }

    public string DisplayInfo()
    {
        return ToString();
    }

    public void PrintDetails()
    {
        DisplayInfo();
    }
}