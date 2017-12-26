using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeTests
{
    [TestFixture]
    class Day25Tests
    {
        string[] input;

        [SetUp]
        public void Setup()
        {
            input = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"..\..\..\..\Input files\input - day 25.txt");
        }

        [Test]
        public void RegexTest()
        {
            Regex stateDescription = new Regex("In state .:");
            Regex writeDescription = new Regex(@"\w*- Write the value .\w*");
            Regex moveDescription = new Regex(@"Move one slot to the \w*.");
            Regex continueDescription = new Regex(@"Continue with state \w.");


            var state = input.Where(a => stateDescription.IsMatch(a)).ToList();
            var write = input.Where(a => writeDescription.IsMatch(a)).ToList();
            var move = input.Where(a => moveDescription.IsMatch(a)).ToList();
            var continues = input.Where(a => continueDescription.IsMatch(a)).ToList();

            state = state.Select(a => a.Substring(a.Length - 2, 1)).ToList();
            write = write.Select(a => a.Substring(a.Length - 2, 1)).ToList();
            move = move.Select(a => a.Split().Last().Substring(0, 1)).ToList();
            continues = continues.Select(a => a.Split().Last().Substring(0, 1)).ToList();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(6, state.Count());
                Assert.AreEqual(12, write.Count());
                Assert.AreEqual(12, move.Count());
                Assert.AreEqual(12, continues.Count());
            });
        }
    }
}
