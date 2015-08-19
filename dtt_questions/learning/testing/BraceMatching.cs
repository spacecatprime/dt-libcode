using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
    You're working with an intern that keeps coming to you with JavaScript code that won't run because the 
    braces, brackets, and parentheses are off. To save you both some time, you decide to write a 
    braces/brackets/parentheses validator.

    Let's say:

    '(', '{', '[' are called "openers."
    ')', '}', ']' are called "closers."

    Write an efficient function that tells us whether or not an input string's openers and closers are properly nested.

    Examples:

    "{ [ ] ( ) }" should return True
    "{ [ ( ] ) }" should return False
    "{ [ }" should return False
    Breakdown
    We can use a greedy 
    A greedy algorithm iterates through the problem space taking the optimal solution "so far," until it reaches the end.

    The greedy approach is only optimal if the problem has "optimal substructure," which means stitching together optimal 
    solutions to sub-problems yields an optimal solution.

    approach to walk through our string character by character, making sure the string validates "so far" until we 
    reach the end.

    What do we do when we find an opener or closer?
*/
namespace testing
{
    [TestClass]
    public class BraceMatching
    {
        [TestMethod]
        public void DoBraceMatching()
        {
            string test1 = @"{ [ ] ( ) }"; // true
            string test2 = @"{ [ ( ] ) }"; // false
            string test3 = @"{ [ }"; // false
            string test4 = @"
                    {
                      'menu': {
                        'id': 'file',
                        'value': 'File',
                        'popup': {
                                    'menuitem': [
                                      {
                              'value': 'New',
                                        'onclick': 'CreateNewDoc()'
                            },
                            {
                              'value': 'Open',
                              'onclick': 'OpenDoc()'
                            },
                            {
                              'value': 'Close',
                              'onclick': 'CloseDoc()'
                            }
                          ]
                        }
                      }
                    }";
            string test5 = @"
                    {
                      'menu': {
                        'id': 'file',
                        'value': 'File',
                        'popup': {
                                    'menuitem': [
                                      {
                              'value': 'New',
                                        'onclick': 'CreateNewDoc('
                            },
                            {
                              'value': 'Open',
                              'onclick': 'OpenDoc]'
                            },
                            {
                              'value': 'Close',
                              'onclick': 'CloseDoc{'
                            }
                          ]
                        }
                      }
                    }";

            Assert.IsTrue(TestForBraces(test2) == false);
            Assert.IsTrue(TestForBraces(test1) == true);
            Assert.IsTrue(TestForBraces(test3) == false);
            Assert.IsTrue(TestForBraces(test4) == true);
        }

        bool TestForBraces(string source)
        {
            int bracesCount = 0; // {}
            int bracketsCount = 0; // []
            int parenthesesCount = 0; // ()

            foreach (char c in source)
            {
                bracesCount += TestForType(c, '{', '}');
                bracketsCount += TestForType(c, '[', ']');
                parenthesesCount += TestForType(c, '(', ')');

                if (bracesCount < 0 || bracketsCount < 0 || parenthesesCount < 0)
                {
                    return false;
                }
            }
            return (bracesCount + bracketsCount + parenthesesCount) == 0;
        }

        int TestForType(char value, char typeIn, char typeOut)
        {
            if (value == typeIn)
            {
                return 1;
            }
            else if (value == typeOut)
            {
                return -1;
            }
            return 0;
        }
    }
}
