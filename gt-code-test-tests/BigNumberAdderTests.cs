using gt_code_test;

namespace gt_code_test_tests
{
    public class BigNumberAdderTests
    {
        [Test]
        public void ShouldHandleSimpleAddition()
        {
            string n1 = "123";
            string n2 = "12";
            var result = BigNumberAdder.Add(n1, n2);
            Assert.That(result, Is.EqualTo("135"));
        }

        [Test]
        public void ShouldHandleAdditionWithACarryInResult()
        {
            string n1 = "8";
            string n2 = "8";
            var result = BigNumberAdder.Add(n1, n2);
            Assert.That(result, Is.EqualTo("16"));
        }

        [Test]
        public void ShouldHandleNumbersGreaterThanDecimalMaxValue()
        {
            string n1 = "2372387287382738273872837287311122323";
            string n2 = "93872875883901983736634788348376638934";
            var result = BigNumberAdder.Add(n1, n2);
            Assert.Throws<OverflowException>(() => decimal.Parse(result));
            Assert.That(result, Is.EqualTo("96245263171284722010507625635687761257"));
        }
    }
}
