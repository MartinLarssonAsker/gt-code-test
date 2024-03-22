using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test
{
    public static class BigNumberAdder
    {
        /// <summary>
        /// Add big numbers like you do with pen and paper
        /// e.g 
        /// 10705
        ///  3401
        /// -----
        /// 14106
        ///  
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static string Add(string n1, string n2)
        {                       
            var (top, bottom) = GetTopAndBottom(n1, n2);
            string result = "";
            int sum, topN, bottomN, rest, carry;
            carry = 0;
            int bottomLength = bottom.Count();
            for (var i = 0; i < top.Count(); i++)
            {
                topN = (int)Char.GetNumericValue(top.ElementAtOrDefault(i));
                bottomN = i < bottomLength ? (int)Char.GetNumericValue(bottom.ElementAtOrDefault(i)) : 0;
                sum = topN + bottomN + carry;
                rest = sum % 10;
                if (sum == rest)
                {
                    result += sum;
                    carry = 0;
                } 
                else
                {
                    result += rest;
                    carry = 1;
                }
            }
            if (carry > 0)
            {
                result += carry;
            }
            return string.Concat(result.Reverse());
        }

        private static (IEnumerable<char> top, IEnumerable<char> bottom) GetTopAndBottom(string n1, string n2)
        {
            var reverseN1 = n1.Reverse();
            var reverseN2 = n2.Reverse();
            return n1.Length > n2.Length ? (reverseN1, reverseN2) : (reverseN2, reverseN1);
        }
    }
}
