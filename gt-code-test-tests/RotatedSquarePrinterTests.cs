using gt_code_test;

namespace gt_code_test_tests
{
    public class RotatedSquarePrinterTests
    {
        [Test]
        public void ShouldRequireOddNumberAsDiagonalLength()
        {
            Assert.Throws<ArgumentException>(() => RotatedSquarePrinter.Print(4));
        }

        [Test]
        public void ShouldPrintANiceSquareWithDiagonalLengthOfFive()
        {
            var result = RotatedSquarePrinter.Print(5);
            var expected = "  *  \r\n *** \r\n*****\r\n *** \r\n  *  \r\n";
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
