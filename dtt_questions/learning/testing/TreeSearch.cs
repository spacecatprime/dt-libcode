using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace testing
{
    /*
    https://www.interviewcake.com/question/word-cloud
    You want to build a word cloud, an infographic where the size of a word corresponds to how often 
    it appears in the body of text.

    To do this, you'll need data. 

    Write code that takes a long string and builds its word cloud data in a hash map,
    where the keys are words and the values are the number of times the words occured.

    Think about capitalized words. For example, look at these sentences:

        'After beating the eggs, Dana read the next step:'
        'Add milk and eggs, then add flour and sugar.'
    
        What do we want to do with "After", "Dana", and "add"? 
        In this example, your final hash should include one "Add" or "add" with a value of 2. 
        Make reasonable (not necessarily perfect) decisions about cases like "After" and "Dana".

    Assume the input will only contain words and standard punctuation.
    */
    [TestClass]
    public class TreeSearch
    {
        [DebuggerDisplay("word={word};count={count}")]
        class WordEntry
        {
            public string word;
            public int count;

            public WordEntry(string aWord)
            {
                word = aWord.ToLower();
                count = 1;
            }
        }

        class WordCloud : IComparer
        {
            public ArrayList m_array = new ArrayList();

            public void HashThem(List<string> lines)
            {
                foreach (string l in lines)
                {
                    string[] words = l.Split(
                        new char[] { ' ', ',', '.', ';', ':', '!', '(', ')' }, 
                        StringSplitOptions.RemoveEmptyEntries);
                    HashWords(words);
                }
            }

            private void HashWords(string[] words)
            {
                foreach (string w in words)
                {
                    WordEntry entry = new WordEntry(w);
                    int idx = m_array.BinarySearch(entry, this);
                    if (idx < 0)
                    {
                        m_array.Add(entry);
                        m_array.Sort(this);
                    }
                    else
                    {
                        WordEntry e = (WordEntry)m_array[idx];
                        e.count++;
                    }
                }
            }

            public int GetValueAt (string key)
            {
                WordEntry entry = new WordEntry(key);
                int idx = m_array.BinarySearch(entry, this);
                if (idx < 0)
                {
                    return -1;
                }
                WordEntry e = (WordEntry)m_array[idx];
                return e.count;
            }

            public int Compare(object x, object y)
            {
                WordEntry lhs = (WordEntry)x;
                WordEntry rhs = (WordEntry)y;
                return lhs.word.CompareTo(rhs.word);
            }
        }

        [TestMethod]
        public void DoWordCloud()
        {
            List<string> lines = new List<string> {
                "After beating the eggs, Dana read the next step:",
                "Add milk and eggs, then add flour and sugar."
            };
            WordCloud cloud = HashWordCloud(lines);
            Assert.AreEqual(2, cloud.GetValueAt("add"));
        }

        private WordCloud HashWordCloud(List<string> lines)
        {
            WordCloud wc = new WordCloud();
            wc.HashThem(lines);
            return wc;
        }
    }

    /*
    https://www.interviewcake.com/question/coin
    Imagine you landed a new job as a cashier...
    Your quirky boss found out that you're a programmer and has a weird request about 
    something they've been wondering for a long time.

    Write a function that, given:

    an amount of money
    a list of coin denominations
    computes the number of ways to make amount of money with coins of the available denominations.

    Example: for amount=4 (4¢) and denominations=[1,2,3] (1¢, 2¢ and 3¢), 
    your program would output 4—the number of ways to make 4¢ with those denominations:



    1¢, 1¢, 1¢, 1¢
    1¢, 1¢, 2¢
    1¢, 3¢
    2¢, 2¢
    */
    [TestClass]
    public class MakeChange
    {
        [TestMethod]
        public void DoMakeChange()
        {
            int amount = 4;
            int[] denominations = new int[]{1,2,3};

            int coinTarget = 20;
            int[] coins = { 1, 5, 10, 20 };

            var rawChange = MakeChangeBag(denominations, amount);
            Assert.AreEqual(4, rawChange.Count);
            var coinChange = MakeChangeBag(coins, coinTarget);
            Assert.AreEqual(10, coinChange.Count);
        }

        private List<List<int>> MakeChangeBag(int[] coin, int sum)
        {
            var bag = new HashSet<List<int>>(new IntListEqualityComparer());
            MakeChangeCountDown(coin, sum, new List<int>(), ref bag);
            return bag.ToList();
        }

        private void MakeChangeCountDown(int[] coin, int sum, List<int> change, ref HashSet<List<int>> bag)
        {
            if (sum == 0)
            {
                change.Sort();
                bag.Add(change);
                return;
            }
            else if (sum < 0)
            {
                return;
            }
            for (int i = 0; i < coin.Length; ++i)
            {
                var clone = new List<int>(change);
                clone.Add(coin[i]);
                MakeChangeCountDown(coin, sum - coin[i], clone, ref bag);
            }
        }

        // assumes all added HashSet entry items are already sorted
        class IntListEqualityComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                if (x.Count != y.Count)
                {
                    return false;
                }
                for (int i = 0; i < x.Count; ++i)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(List<int> obj)
            {
                int hashIt = obj[0];
                for(int i = 0; i < obj.Count; i++)
                {
                    hashIt ^= (obj[i] * (i + 1));
                }
                return hashIt;
            }
        }
    }
}
