using Lab3.Interfaces;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab3.Models;

public class Member:IPrintable, IMemberActions
{
    private int _memberId;
    private string _name;
    private string _email;
    private Stack<Transaction> _transactions;
    
    //Properties
    public int MemberId { get => _memberId; set => _memberId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Email { get => _email; set => _email = value; }
    public Stack<Transaction> Transactions { get; set; }

    public Member()
    {
        MemberId = Random.Shared.Next(1000, 9999);
        Transactions = new Stack<Transaction>();
    }

    public virtual string DisplayInfo()
    {
        return $"Name: {_name}, Email: {_email}";
    }

    public void PrintDetails()
    {
        DisplayInfo();
    }

    public virtual Boolean BorrowBook(Book book)
    {
        throw new NotImplementedException();
    }

    public virtual Boolean ReturnBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Boolean isPremium(Member member)
    {
        if (member.GetType() == typeof(PremiumMember))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}