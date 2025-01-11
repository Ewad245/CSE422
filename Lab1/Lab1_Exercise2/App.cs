using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Exercise2
{
    public static class App
    {
        static void Main(String[] args)
        {
            int divided = Convert.ToInt32(Console.ReadLine());
            int divisor = Convert.ToInt32(Console.ReadLine());

            Solution solution = new Solution();
            int result = solution.Divide(divided, divisor);
            Console.WriteLine(result);
        }
    }
}
