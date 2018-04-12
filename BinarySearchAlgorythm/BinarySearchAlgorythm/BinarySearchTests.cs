using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchAlgorythm
{
    [TestFixture]
    public class BinarySearchTests
    {
        public static IEnumerable IntComparisonTests
        {
            get
            {
                int[] array1 = new int[0];
                yield return new TestCaseData(array1, 0, null).Returns(-1);

                int[] array2 = { 1, 3, 5, 7, 9 };
                yield return new TestCaseData(array2, 0, null).Returns(-1);
                yield return new TestCaseData(array2, 1, null).Returns(0);
                yield return new TestCaseData(array2, 4, null).Returns(-1);
                yield return new TestCaseData(array2, 7, null).Returns(3);
                yield return new TestCaseData(array2, 8, null).Returns(-1);
                yield return new TestCaseData(array2, 9, null).Returns(4);
            }
        }

        public static IEnumerable IntComparerTests
        {
            get
            {
                var array = new int[] { 9, 8, 7, 6, 4, 3, 2 };
                var comparer = new IntComparer();
                yield return new TestCaseData(array, 3, comparer).Returns(5);
                yield return new TestCaseData(array, 5, comparer).Returns(-1);
                yield return new TestCaseData(array, 9, comparer).Returns(0);
                yield return new TestCaseData(array, 10, comparer).Returns(-1);

            }
        }

        public static IEnumerable StringComparisonTests
        {
            get
            {
                string[] array = new string[0];
                yield return new TestCaseData(array, "a", null).Returns(-1);

                string[] array1 = { "a", "b", "c", "d", "e" };
                yield return new TestCaseData(array, "A", null).Returns(-1);
                yield return new TestCaseData(array, "a", null).Returns(-1);
                yield return new TestCaseData(array, "с", null).Returns(-1);
                yield return new TestCaseData(array, "z", null).Returns(-1);
                yield return new TestCaseData(array, "e", null).Returns(-1);
                
                var array2 = new string[] { "Y", "o", "M", "f", "A" };
                Comparison<string> comparison = (string l, string r) => r.CompareTo(l);
                yield return new TestCaseData(array2, "z", comparison).Returns(-1);
                yield return new TestCaseData(array2, "F", comparison).Returns(-1);
                yield return new TestCaseData(array2, "Y", comparison).Returns(0);
                yield return new TestCaseData(array2, "o", comparison).Returns(1);
                yield return new TestCaseData(array2, "A", comparison).Returns(4);
            }
        }

        public static IEnumerable StringComparerTests
        {
            get
            {
                var array = new string[] { "Y", "o", "M", "f", "A" };
                var comparer = new StringComparer();
                yield return new TestCaseData(array, "z", comparer).Returns(-1);
                yield return new TestCaseData(array, "F", comparer).Returns(-1);
                yield return new TestCaseData(array, "Y", comparer).Returns(0);
                yield return new TestCaseData(array, "o", comparer).Returns(1);
                yield return new TestCaseData(array, "A", comparer).Returns(4);
            }
        }

        public static IEnumerable ExceptionTests
        {
            get
            {
                var array = new object[5];
                yield return new TestCaseData(array, array[2]);
            }
        }

        [Test, TestCaseSource("IntComparisonTests")]
        public int BinarySearchIntComparisonTest(int[] array, int elem, Comparison<int> comparison)
        {
            {
                return BinarySearchLib.BinarySearcher(array, elem, comparison);
            }
        }

        [Test, TestCaseSource("IntComparerTests")]
        public int BinarySearchIntComparerTest(int[] array, int elem, IComparer<int> comparer)
        {
            return BinarySearchLib.BinarySearcher(array, elem, comparer);
        }

        [Test, TestCaseSource("StringComparisonTests")]
        public int BinarySearchStringComparisonTest(string[] array, string elem, Comparison<string> comparison)
        {
            return BinarySearchLib.BinarySearcher(array, elem, comparison);
        }

        [Test, TestCaseSource("StringComparerTests")]
        public int BinarySearchStringComparerTest(string[] array, string elem, IComparer<string> comparer)
        {
            return BinarySearchLib.BinarySearcher(array, elem, comparer);
        }

        [Test, TestCaseSource("ExceptionTests")]
        public void BinarySearchExceptionTest(object[] array, object elem)
        {
            Assert.Throws<InvalidOperationException>(() => BinarySearchLib.BinarySearcher(array, elem));
        }


        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return y.CompareTo(x);
            }
        }
    }
}

