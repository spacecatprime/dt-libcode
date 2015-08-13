using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace testing
{
    /// <summary>
    /// create a string source
    /// effectively reverse the string
    /// verify the string has been reversed
    /// </summary>
    [TestClass]
    public class ReverseString
    {
        [TestMethod]
        public void DoReverseString()
        {
            const string foo = "This is a foo string.";
            char[] bar = new char[foo.Length];

            for (int i = 0; i < foo.Length; ++i)
            {
                bar[i] = foo[foo.Length - (i + 1)];
            }
            List<char> answer = new List<char>(foo);
            answer.Reverse();
            CollectionAssert.AreEqual(answer, bar);
        }

        [TestMethod]
        public void DoReverseIntArrayInPlace()
        {
            int[] intArray = new int[] { 1, 2, 4, 8, 16, 32, 64 };
            List<int> answer = new List<int>(intArray);
            answer.Reverse();

            for (int i = intArray.Length - 1; i >= 0; --i)
            {
                if (i < (intArray.Length >> 1))
                {
                    break;
                }
                int k = intArray.Length - (i + 1);
                if (i != k)
                {
                    intArray[i] = intArray[i] ^ intArray[k];
                    intArray[k] = intArray[i] ^ intArray[k];
                    intArray[i] = intArray[i] ^ intArray[k];
                }
            }

            CollectionAssert.AreEqual(answer, intArray);
        }
    }
}
