using gt_code_test;

namespace gt_code_test_tests
{
    public class PalindromeCheckerTests
    {
        [Test]
        public void CanIdentifyPalindrome()
        {
            var palindromeWord = "Kayak";
            var result = PalindromeChecker.IsPalindrome(palindromeWord);
            Assert.That(result, Is.True);
        }
    }
}
