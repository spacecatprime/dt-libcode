using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/*
    https://www.interviewcake.com/question/stock-price

    Writing coding interview questions hasn't made me rich. Maybe trading Apple stocks will.

    I have an array stock_prices_yesterday where:

    The indices are the time in minutes past trade opening time, which was 9:30am local time.

    The values are the price in dollars of Apple stock at that time.

    For example, the stock cost $500 at 10:30am, so stock_prices_yesterday[60] = 500.

    Write an efficient algorithm for computing the best profit I could have made from 1 purchase and 1 sale of 1 Apple stock yesterday.

    No "shorting"—you must buy before you sell. You may not buy and sell in the same time step 
    (at least 1 minute must pass).
*/
namespace testing
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class StockPrice
    {
        static int[] small;

        static int[] large;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // TODO: when stock prices are higher, so they do not affect the timing of the tests
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            small = null;
            large = null;
        }

        [TestMethod]
        public void DoStockPrice_sort()
        {
            for (int i = 0; i <= 4; ++i )
            {
                int highestIdx = 0;
                int lowestIdx = 0;

                int expectedHi = 0;
                int expectedLo = 0;
                int expectedProfit = 0;

                int[] prices = BuildStockPricesKnown(i, ref expectedHi, ref expectedLo, ref expectedProfit);
                findHighAndLow_twopass(prices, ref lowestIdx, ref highestIdx);
                Assert.AreEqual(lowestIdx, expectedLo);
                Assert.AreEqual(highestIdx, expectedHi);

                int profit = findHighAndLow_highestProfit(prices);
                Assert.AreEqual(expectedProfit, profit);
            }
        }

        private void findHighAndLow_mapped(int[] prices, ref int smallestIdx, ref int largestIdx)
        {
            largestIdx = 0;
            smallestIdx = int.MinValue;

            Dictionary<int, int> mappedPrices = new Dictionary<int, int>(prices.Length);
            for (int i = 0; i < prices.Length; ++i)
            {
                mappedPrices[i] = prices[i];
            }
            var sorted = from entry in mappedPrices orderby entry.Value descending select entry;
            var highest = sorted.Last();
            largestIdx = highest.Key;
            foreach (var kvp in sorted)
            {
                if (kvp.Key < highest.Key)
                {
                    smallestIdx = kvp.Key;
                    break;
                }
            }
        }

        private int findHighAndLow_highestProfit(int[] prices)
        {
            int smallestPrice = prices[0];
            int mostProfit = 0;

            for (int i = 0; i < prices.Length; ++i)
            {
                int current = prices[i];
                smallestPrice = (smallestPrice < current) ? smallestPrice : current;
                mostProfit = (mostProfit > (current - smallestPrice)) ? mostProfit : (current - smallestPrice);
            }

            return mostProfit;
        }

        private void findHighAndLow_twopass(int[] prices, ref int smallestIdx, ref int largestIdx)
        {
            largestIdx = 0;
            smallestIdx = 0;

            // find the highest of the day
            for (int i = 0; i < prices.Length; ++i)
            {
                if (prices[i] > prices[largestIdx])
                {
                    largestIdx = i;
                }
            }

            // go backwards to find the lowest of the day from the highest
            smallestIdx = largestIdx;
            for (int k = largestIdx; k >= 0; --k)
            {
                if (prices[k] < prices[smallestIdx])
                {
                    smallestIdx = k;
                }
            }
        }

        private static int[] BuildStockPricesKnown(int count, ref int highest, ref int lowest, ref int profit)
        {
            if( count == 0 )
            {
                int[] values = new int[] { 0, 1, 2, 3, 4, 5, 6 };
                highest = 6;
                lowest = 0;
                profit = 6;
                return values;
            }
            else if (count == 1)
            {
                int[] values = new int[] { 53, 7, 13, 100, 2, 3, 4, 5, 101 };
                highest = 8;
                lowest = 4;
                profit = 99;
                return values;
            }
            else if (count == 2)
            {
                int[] values = new int[] { 53, 7, 13, 100, 7 };
                highest = 3;
                lowest = 1;
                profit = 93;
                return values;
            }
            else if (count == 3)
            {
                const int many = 1000 * 1000;
                List<int> manyPrices = Enumerable.Repeat(10, many).ToList();
                manyPrices[manyPrices.Count - 2] = 100;
                manyPrices[0] = 1;
                highest = manyPrices.Count - 2;
                lowest = 0;
                profit = manyPrices[highest] - manyPrices[lowest];
                return manyPrices.ToArray();
            }
            else if (count == 4)
            {
                int[] values = new int[] { 2, 2, 1, 10, 3, 4, 20 };
                highest = values.Length - 1;
                lowest = 2;
                profit = 19;
                return values;
            }
            throw new NotImplementedException();
        }

        private static int[] BuildStockPricesRandom(int count, ref int highest, ref int lowest)
        {
            int low = int.MaxValue;
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<int> intList = new List<int>();
            for (int i = 0; i < count; ++i)
            {
                int next = rnd.Next();
                low = Math.Min(low, next);
                intList.Add(next);
            }
            lowest = intList.Find((int i) => i == low);

            int high = int.MinValue;
            for (int k = lowest; k < intList.Count; ++k)
            {
                if (intList[k] > high)
                {
                    high = intList[k];
                    highest = k;
                }
            }
            return intList.ToArray();
        }
    }
}
