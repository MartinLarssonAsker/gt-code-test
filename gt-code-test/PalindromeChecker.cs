using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test
{
    public static class PalindromeChecker
    {
        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Give me something to check");
            }
            var reverse = string.Concat(input.Reverse());
            return reverse?.ToLower() == input.ToLower();
        }
    }
}
