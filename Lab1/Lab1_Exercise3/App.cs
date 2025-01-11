using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Exercise3
{
    public static class App
    {
        static void Main(String[] args)
        {
            int numValue1 = Convert.ToInt32(Console.ReadLine());
            int numValue2 = Convert.ToInt32(Console.ReadLine());
            string word = Console.ReadLine();
            char[][] board = new char[numValue1][];

            for(int i=0; i<numValue1; i++)
            {
                board[i] = new char[numValue2];
            }

            for(int i=0;i<numValue1; i++)
            {
                for(int j=0; j<numValue2; j++)
                {
                    board[i][j] = Convert.ToChar(Console.ReadLine());
                }
            }


            Solution solution = new Solution();
            bool result = solution.Exist(board, word);
            Console.WriteLine(result);
        }
    }
}
