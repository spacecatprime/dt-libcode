using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace testing
{
    [TestClass]
    public class Sudoku
    {
        int[][] boardGood = new int[9][]
        {
            //         0,0     1,0    2,0
            new int[] {4,3,5, 2,6,9, 7,8,1},
            new int[] {6,8,2, 5,7,1, 4,9,3},
            new int[] {1,9,7, 8,3,4, 5,6,2},

            //         0,1     1,1    2,1
            new int[] {8,2,6, 1,9,5, 3,4,7},
            new int[] {3,7,4, 6,8,2, 9,1,5},
            new int[] {9,5,1, 7,4,3, 6,2,8},

            //         0,2     1,2    2,2      
            new int[] {5,1,9, 3,2,6, 8,7,4},
            new int[] {2,4,8, 9,5,7, 1,3,6},
            new int[] {7,6,3, 4,1,8, 2,5,9}
        };

        int[] firstGoodBlock = new int[9] { 4, 3, 5, 6, 8, 2, 1, 9, 7 };

        [TestMethod]
        public void DoSudoku()
        {
            Assert.IsTrue(IsGoodSolution_Splits(boardGood));
            Assert.IsTrue(IsGoodSolution_Hashed(boardGood));
        }

        private int TotalCount(int[][] board)
        {
            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    total += board[i][k];
                }
            }
            return total;
        }

        private bool IsGoodSolution_Splits(int[][] board)
        {
            const int kMaxTotal = 405; // (9+8+...+1) * 9
            int total = 0;
            var groups = new List<List<int>>();
            groups.Add(new List<int>());
            groups.Add(new List<int>());
            groups.Add(new List<int>());
            for (int i = 0; i < 9; ++i)
            {
                if (ValidateArray(board[i]) == false)
                {
                    return false;
                }
                List<int> column = new List<int>();
                for (int k = 0; k < 9; ++k)
                {
                    total += board[i][k];
                    if (total > kMaxTotal)
                    {
                        return false;
                    }
                    column.Add(board[i][k]);
                }
                if (ValidateArray(column.ToArray()) == false)
                {
                    return false;
                }
                if (i == 3 || i == 6)
                {
                    groups.Add(new List<int>());
                    groups.Add(new List<int>());
                    groups.Add(new List<int>());
                }
                groups[groups.Count - 3].AddRange(board[i].Skip(0).Take(3));
                groups[groups.Count - 2].AddRange(board[i].Skip(3).Take(3));
                groups[groups.Count - 1].AddRange(board[i].Skip(6).Take(3));
            }
            foreach (var g in groups)
            {
                if (ValidateArray(g.ToArray()) == false)
                {
                    return false;
                }
            }
            return total == kMaxTotal;
        }

        private bool IsGoodSolution_Hashed(int[][] board)
        {
            const int kMaxTotal = 405; // (9+8+...+1) * 9
            int total = 0;
            var blocks = new Dictionary<int, List<int>>();
            for (int i = 0; i < 9; ++i)
            {
                if (ValidateArray(board[i]) == false)
                {
                    return false;
                }
                List<int> column = new List<int>();
                for (int k = 0; k < 9; ++k)
                {
                    total += board[i][k];
                    if (total > kMaxTotal)
                    {
                        return false;
                    }
                    column.Add(board[i][k]);

                    //int blockNum = (i % 3) + (k / 3);
                    //int blockNum = ((i % 3) * 1) | ((k / 3) * 100);
                    //int blockNum = (i % 3) | (k / 3);
                    //int blockNum = (i / 3) + (k % 3);
                    //int blockNum = (i % 3) + ((k / 3) * (i % 3));
                    //int blockNum = (i % 3) | ((k / 3) + (k % 3));
                    //int blockNum = (i % 3) + ((k / 3) + (i % 3));
                    int blockKey = (k % 3) + (i / 3);
                    if (blocks.ContainsKey(blockKey))
                    {
                        blocks[blockKey].Add(board[i][k]);
                    }
                    else
                    {
                        blocks.Add(blockKey, new List<int>());
                        blocks[blockKey].Add(board[i][k]);
                    }
                }
                if (ValidateArray(column.ToArray()) == false)
                {
                    return false;
                }
            }
            foreach (var block in blocks.Values)
            {
                if (ValidateArray(block.ToArray()) == false)
                {
                    return false;
                }
            }
            return total == kMaxTotal;
        }

        private bool ValidateArray(int[] values)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int i in values)
            {
                if (i < 1 || i > 9)
                {
                    return false;
                }
                if (set.Contains(i))
                {
                    return false;
                }
                set.Add(i);
            }
            return true;
        }
    }
}
