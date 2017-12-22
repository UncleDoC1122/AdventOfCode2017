using AdventOfCodeDay6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests
{
    [TestFixture]
    class Day6Test
    {
        List<int> firstList;
        List<int> secondList;
        List<int> thirdList;

        List<int> resultList;

        [SetUp]
        public void Setup()
        {
            firstList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            secondList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            thirdList = new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            resultList = new List<int>() { 1, 9, 8, 7, 6, 5, 4, 3, 2 };
        }

        [Test]
        public void Day6_Compare()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Task2.Compare(firstList, secondList));

                Assert.IsFalse(Task2.Compare(secondList, thirdList));
            });
        }

        [Test]
        public void Day6_Redistribute()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(Task2.Redistribute(thirdList), resultList);

                Assert.AreNotEqual(Task2.Redistribute(thirdList), thirdList);
            });
        }
    }
}
