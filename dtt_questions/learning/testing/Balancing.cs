using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// best week
/// worst week
/// work-life-balance
/// Leadership: asking for more
/// Leadership: customer focused, example
/// kind of tech used
/// recent challenges in Austin office (logistics)
/// jesse, 7 years, backend, where to ship, promise team, specialized vs. general, 2 pizzia sized teams
/// </summary>
namespace testing
{
    [TestClass]
    public class Balancing
    {
        /// <summary>
        /// Write a function to see if a binary tree is "superbalanced" (a new tree property we just made up).
        ///  A tree is "superbalanced" if the difference between the depths of any two leaf nodes is no greater than one.
        /// </summary>

        public class TreeNode
        {
            public object value = null;
            public TreeNode left = null;
            public TreeNode right = null;

            public TreeNode(object v)
            {
                value = v;
            }

            public TreeNode MakeKids(params string[] kids)
            {
                if (kids.Length == 0)
                {
                    return this;
                }
                else if (kids.Length == 1)
                {
                    this.left = new TreeNode("leaf=" + kids[0]);
                    return this;
                }
                string lhs = string.Format("left={0}", kids[0]);
                string rhs = string.Format("rght={0}", kids[1]);
                var others = kids.Skip(2).Take(kids.Length - 2).ToArray();
                this.left = new TreeNode(lhs);
                this.right = new TreeNode(rhs);
                int halfSize = others.Length / 2;
                string[] leftItems = others.Take(halfSize).ToArray();
                string[] rightItems = others.Skip(halfSize).ToArray();
                this.left.MakeKids(leftItems);
                this.right.MakeKids(rightItems);
                return this;
            }

            public void PrintKids(int indent)
            {
                System.Diagnostics.Trace.Write("".PadLeft(indent) + value.ToString() + "\n");
                if (left != null)
                {
                    left.PrintKids(indent + 1);
                }
                if(right != null)
                {
                    right.PrintKids(indent + 1);
                }
            }
        }

        [TestMethod]
        public void Balancing_superbalanced()
        {
            TreeNode tree = buildTree(0);
            tree.PrintKids(0);
        }

        private TreeNode buildTree(int type)
        {
            if (type == 0)
            {
                TreeNode root = new TreeNode("root");
                return root.MakeKids(new string[] { "1", "2", "3", "4" , "5", "6" , "7", "8" , "9", "10" , "11", "12" , "13", "14", "15", "16" });
            }
            else if (type == 1)
            {
                return null;
            }
            throw new NotImplementedException();
        }

        //[TestMethod]
        public void Balancing_jugs()
        {
            /*
                Suppose you have a 3 liter jug and a 5 liter jug (this could also be in gallons). 
                The jugs have no measurement lines on them either. 
                How could you measure exactly 4 liter using only those jugs and as much extra water as you need?
                
                This question was actually asked in a popular movie – Die Hard With A Vengeance.
                Try figuring this one out on your own before reading the answer. 
                It should be clear that the goal is to end up with 4 liter in the 5 liter jug, since having 4 liters in the 3 liter jug is impossible. 
                
            The answer, broken down in steps:

            Step 1 : First, fill the 5 liter jug and then pour it into the 3 liter jug. The 5 liter jug now has only 2 liters left.
            Step 2 : Next, empty out the 3 liter jug. Then, pour the 2 liters from the 5 liter jug to the 3 liter jug. So, now the 3 liter jug has 2 liters.
            Step 3 : Fill the 5 liter jug again, and pour 1 liter into the 3 liter jug. Now, what’s left in the 5 liter jug? Well, exactly 4 liters! There’s your answer.       
            */
        }
        //[TestMethod]
        public void Balancing_findHeaviestBall()
        {
            // http://www.quora.com/There-are-8-balls-7-of-them-weigh-the-same-1-of-them-has-a-different-weight-you-dont-know-if-its-heavier-or-lighter-How-do-you-find-the-odd-ball-with-2-weighs
            // There are 8 balls. 7 of them weigh the same. 
            // 1 of them has a different weight, (you don't know if it's heavier or lighter). 
            // How do you find the odd ball with 2 weighs ?

            // prepare: (1)weigh 3x3 with 2 off
            // if 3x3 is balanced, (2)weigh 2 off to find
            // else, leave one off (2)weigh 1x1
            // if 1x1 is balanced, one off to find
        }
    }
}
