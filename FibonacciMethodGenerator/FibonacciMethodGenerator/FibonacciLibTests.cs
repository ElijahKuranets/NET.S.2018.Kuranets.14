using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;
using NUnit.Framework;

namespace FibonacciMethodGenerator
{
    [TestFixture]
    public class FibonacciLibTests
    {
        public static IEnumerable GenerateSequenceTests
        {
            get
            {
                yield return new TestCaseData(0u).Returns(new BigInteger[] { });
                yield return new TestCaseData(1u).Returns(new BigInteger[] { 1 });
                yield return new TestCaseData(2u).Returns(new BigInteger[] { 1, 2 });
                yield return new TestCaseData(10u).Returns(new BigInteger[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 });
                yield return new TestCaseData(20u).Returns(new BigInteger[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946 });
            }
        }

        [TestCaseSource("GenerateSequenceTests")]
        public IEnumerable<BigInteger> GenerateSequenceTest(uint length)
        {
            return FibonacciLib.GenerateSequence(length);
        }
    }
}
