using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchAlgorythm
{
    /// <summary>
    /// contains methods for a binary search
    /// </summary>
    public static class BinarySearchLib
    {
        /// <summary>
        /// searches an element in array using specified <paramref name="comparer"/>
        /// </summary>
        /// <typeparam name="T">type of element for search</typeparam>
        /// <param name="array">array for a search</param>
        /// <param name="elem">element to search</param>
        /// <param name="comparer">comparer object</param>
        /// <returns>position of  <paramref name="elem"/> in <paramref name="array"/> or -1 if not found</returns>
        public static int BinarySearcher<T>(T[] array, T elem, IComparer<T> comparer)
        {
            return BinarySearcher(array, elem, comparer.Compare);
        }
        /// <summary>
        /// searches an element in array using specified <paramref name="comparison"/>
        /// </summary>
        /// <typeparam name="T">type of element for search</typeparam>
        /// <param name="array">array for search</param>
        /// <param name="elem">element for search</param>
        /// <param name="comparison">compare method</param>
        /// <returns></returns>
        public static int BinarySearcher<T>(T[] array, T elem, Comparison<T> comparison = null)
        {
            if (comparison == null)
            {
                if (elem is IComparable<T> element)
                {
                    comparison = (T left, T right) => element.CompareTo(right);
                }
                else
                {
                    throw new InvalidOperationException($"can't compare objects of type {typeof(T)}.");
                }
            }

            if (array.Length == 0 || comparison(elem, array[0]) < 0 || comparison(elem, array[array.Length - 1])> 0)
            {
                return -1;
            }

            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int mid = first + ((last - first) / 2);

                if (comparison(elem, array[mid]) <= 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (comparison (elem, array[last]) == 0)
            {
                return last;
            }
            else
            {
                return -1;
            }
        }
    }
}
