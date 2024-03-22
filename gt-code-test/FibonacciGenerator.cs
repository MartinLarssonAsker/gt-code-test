using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test
{
    public static class FibonacciGenerator
    {
        public static string GetNthNumberInFibbonaciSequence(int nthNumber)
        {
            if (nthNumber < 1) throw new ArgumentException("Only positive numbers please");
            
            int index = nthNumber - 1;
            return Fibbonaci(index);
        }

        private static string Fibbonaci(int n)
        {
            if (n < 2) return n.ToString();
            string first = "0";
            string second = "1";
            string result = "";
            int current = 1;
            while (current < n)
            {
                result = BigNumberAdder.Add(first, second);
                first = second;
                second = result;
                current++;
            }
            return result;
        }


        private static decimal FibbonaciLimitedByNumericMaxValue(int n)
        {
            if (n < 2) return n;
            decimal first = 0;
            decimal second = 1;
            decimal result = first + second;
            int current = 1;
            while (current < n)
            {
                result = first + second;
                first = second;
                second = result;
                current++;
            }
            return result;
        }
        private static long FibbonaciSlow(int n)
        {
            if (n <= 1) return n;
            return FibbonaciSlow(n - 1) + FibbonaciSlow(n - 2);
        }
    }
}
