using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

/*
https://www.interviewcake.com/question/merge-sorted-arrays
In order to win the prize for most cookies sold, my friend Alice and I are going to merge our Girl Scout Cookies orders and enter as one unit.

Each order is represented by an "order id" (an integer). We have our lists of orders sorted numerically already, in arrays. 

Write a function to merge our arrays of orders into one sorted array.

For example:

my_array     = [3, 4, 6, 10, 11, 15]
alices_array = [1, 5, 8, 12, 14, 19]

print merge_arrays(my_array, alices_array)
# prints [1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19]

Do you have an answer?
*/
namespace testing
{
    [TestClass]
    public class MergeSortedArrays
    {
        int[] lhsArray = new int[] { 3, 4, 6, 10, 11, 15 };
        int[] rhsArray = new int[] { 1, 5, 8, 12, 14, 19 };
        int[] answer = new int[] { 1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19 };

        [TestMethod]
        public void DoMergeSortedArrays_simple()
        {
            List<int> foo = new List<int>(lhsArray);
            foo.AddRange(rhsArray);
            foo.Sort();
            CollectionAssert.AreEqual(foo, answer);
        }

        [TestMethod]
        public void DoMergeSortedArrays_copymerge()
        {
            List<int> merge = new List<int>(lhsArray.Length + rhsArray.Length);
            merge.AddRange(lhsArray);
            foreach (int val in rhsArray)
            {
                merge.Add(int.MinValue);
                int last = -1;
                for (int i = 0; i < merge.Count; ++i)
                {
                    if (last >= 0)
                    {
                        int next = merge[i];
                        merge[i] = last;
                        last = next;
                    }
                    else if (merge[i] > val)
                    {
                        last = merge[i];
                        merge[i] = val;
                    }
                    else if (i == merge.Count - 1)
                    {
                        merge[i] = val;
                    }
                }
            }
            CollectionAssert.AreEqual(merge, answer);
        }
    }
}
