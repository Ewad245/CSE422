using Lab3.Models;

namespace Lab3;

public class Exercise4
{
    public static void Iterate()
    {
        Transaction[] transactions = new Transaction[10];
        for (int i = 0; i < transactions.Length-1;)
        {
            transactions[i++] = new BorrowTransaction();
            transactions[i++] = new ReturnTransaction();
        }

        for (int i = 0; i < transactions.Length; i++)
        {
            transactions[i].Execute();
        }
    }
}