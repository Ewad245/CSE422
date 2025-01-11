using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Exercise1
{
    public static class App
    {
        static void Main(String[] args)
        {
            int numValue1 = Convert.ToInt32(Console.ReadLine());
            int numValue2 = Convert.ToInt32(Console.ReadLine());

            int[] array1 = new int[numValue1];
            int[] array2 = new int[numValue2];

            for(int i = 0; i < array1.Length; i++)
            {
                array1[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i = 0;i < array2.Length; i++)
            {
                array2[i] = Convert.ToInt32(Console.ReadLine());
            }

            FindMedianSortedArray solution = new FindMedianSortedArray();
            double result = solution.Solution(array1 , array2);
            Console.WriteLine(result);
        }
    }
}
