using gt_code_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test_tests
{
    public class FibbonaciGeneratorTests
    {
        [Test]
        public void ShouldReturnZeroAsTheFirstNumberInSequence()
        {
            var result = FibonacciGenerator.GetNthNumberInFibbonaciSequence(1);
            Assert.That(result, Is.EqualTo("0"));
        }

        [Test]
        public void ShouldReturnThreeAsTheFifthNumberInSequence()
        {
            var result = FibonacciGenerator.GetNthNumberInFibbonaciSequence(5);
            Assert.That(result, Is.EqualTo("3"));
        }

        [Test]
        public void ShouldRequirePositiveNumbers()
        {
            Assert.Throws<ArgumentException>(() => FibonacciGenerator.GetNthNumberInFibbonaciSequence(0));
        }

        [Test]
        public void ShouldHandleHighSequenceNumbersWhereTheResultHasMoreThanThirtyDigits()
        {
            var result = FibonacciGenerator.GetNthNumberInFibbonaciSequence(1000);
            var expected = "26863810024485359386146727202142923967616609318986952340123175997617981700247881689338369654483356564191827856161443356312976673642210350324634850410377680367334151172899169723197082763985615764450078474174626";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
