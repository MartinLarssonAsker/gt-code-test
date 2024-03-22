using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test
{
    public static class RotatedSquarePrinter
    {
        public static string Print(int diagonalLength)
        {
            if (diagonalLength % 2 != 1) {
                throw new ArgumentException("It has to be a odd number");
            }
            var sb = new StringBuilder();
            int starCount = 1;
            int paddingLength;
            bool isGrowing = true;
            bool hasStars = true;
            string row, stars, padding;
            while (hasStars)
            {
                paddingLength = (diagonalLength - starCount) / 2;
                stars = new string('*', starCount);
                padding = new string(' ', paddingLength);
                row = $"{padding}{stars}{padding}" + Environment.NewLine;
                sb.Append(row);
                isGrowing = isGrowing && starCount != diagonalLength;
                starCount = isGrowing ? starCount + 2 : starCount - 2;                
                hasStars = starCount > 0;                
            }
            return sb.ToString();
        }
    }
}
