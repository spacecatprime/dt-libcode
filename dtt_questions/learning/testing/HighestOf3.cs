using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/*
https://www.interviewcake.com/question/highest-product-of-3
Given an array_of_ints, find the highest_product you can get from three of the integers.
The input array_of_ints will always have at least three integers.
*/
namespace testing
{
    [TestClass]
    public class HighestOf3
    {
        static int[] small;
        static int[] large;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            small = new int[] { 32, 16, 1, 2, 3 };

            const int largeSize = 1024 * 1024 * 1;
            List<int> largeItems = new List<int>();
            for (int i = 0; i < largeSize; ++i)
            {
                largeItems.Add(i);
            }
            var rnd = new Random(DateTime.Now.Millisecond);
            var result = largeItems.OrderBy(item => rnd.Next());
            large = result.ToArray();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            small = null;
            large = null;
        }

        [TestMethod]
        public void DoHighestOf3_Small()
        {
            List<int> intList = new List<int>(small);
            intList.Sort(delegate (int lhs, int rhs) { return rhs.CompareTo(lhs);  });
            Assert.AreEqual(32 + 16 + 3, intList[0] + intList[1] + intList[2]);
        }

        [TestMethod]
        public void DoHighestOf3_LargeSort()
        {
            int answer = (large.Length - 1) + (large.Length - 2) + (large.Length - 3);
            List<int> intList = new List<int>(large);
            intList.Sort(delegate (int lhs, int rhs) { return rhs.CompareTo(lhs); });
            Assert.AreEqual(answer, intList[0] + intList[1] + intList[2]);
        }

        [TestMethod]
        public void DoHighestOf3_LargeNoSort()
        {
            int answer = (large.Length - 1) + (large.Length - 2) + (large.Length - 3);
            int high1 = int.MinValue;
            int high2 = int.MinValue;
            int high3 = int.MinValue;

            // cascade the highest result
            for (int i = 0; i < large.Length; ++i)
            {
                if (large[i] > high1)
                {
                    high3 = high2;
                    high2 = high1;
                    high1 = large[i];
                }
                else if (large[i] > high2)
                {
                    high3 = high2;
                    high2 = large[i];
                }
                else if (large[i] > high3)
                {
                    high3 = large[i];
                }
            }
            Assert.AreEqual(answer, high1 + high2 + high3);
        }
    }
}
