using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace FibonacciMethodGenerator
{
    public static class FibonacciLib
    {
        public static IEnumerable<BigInteger> GenerateSequence(uint length)
        {
            var fibonacci = BigInteger.Zero;
            var fibonacci1 = BigInteger.One;
            for (uint i = 0; i < length; i++)
            {
                yield return fibonacci1 = checked(fibonacci + (fibonacci = fibonacci1));
            }
        }
    }
}
