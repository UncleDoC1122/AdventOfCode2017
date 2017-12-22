using NUnit.Framework;
using AdventOfCodeDay4;

namespace AdventOfCodeTests
{
    [TestFixture]
    class Day4Test
    {
        [Test]
        public void Day4_AreEqual()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Task2.AreEqual("aabbcc", "abcabc"));
                Assert.IsTrue(Task2.AreEqual("abc", "cab"));

                Assert.IsFalse(Task2.AreEqual("aaa", "bbb"));
                Assert.IsFalse(Task2.AreEqual("abcdef", "abcdeg"));
            });
                
        }
    }
}
