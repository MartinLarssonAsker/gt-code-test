using gt_code_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gt_code_test_tests
{
    public class BubbleSorterTests
    {
        [Test]
        public void ShouldBeAbleToSortList()
        {
            var list = new int[]
            {
                5, 3, 9, 1
            };
            var result = BubbleSorter.Sort(list);
            var expected = new List<int>()
            {
                9, 5, 3, 1
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldHandleOneElementList()
        {
            var list = new List<int>() { 7 };
            var result = BubbleSorter.Sort(list);
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void ShouldHandleLongList()
        {
            var rand = new Random();
            var list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(rand.Next());
            }
            var result = BubbleSorter.Sort(list);
            var expected = list.OrderByDescending(x => x).ToList();
            Assert.That (result, Is.EqualTo(expected));
        }
    }
}
