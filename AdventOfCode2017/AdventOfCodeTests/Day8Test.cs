using NUnit.Framework;
using AdventOfCodeDay8;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    [TestFixture]
    class Day8Test
    {
        string inputOne;
        string inputTwo;

        List<Operation> operations;
        List<Register> registers;

        [SetUp]
        public void Setup()
        {
            inputOne = "me dec -71 if p <= 222";
            inputTwo = "me inc 186 if ppl > -270";

            operations = new List<Operation>();
            registers = new List<Register>();
        }

        [Test]
        public void Day8_OperationConstructor()
        {
            operations.Add(new Operation(inputOne, ref registers));
            operations.Add(new Operation(inputTwo, ref registers));

            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, registers.Count);

            });

            
        }

    }
}
