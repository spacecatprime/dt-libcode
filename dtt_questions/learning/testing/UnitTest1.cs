using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Debug.WriteLine("test");
            System.Console.WriteLine("");
        }

        [TestMethod]
        public void FizzBuzz()
        {
            for (int i = 1; i < 100; ++i)
            {
                bool isThrees = (i % 3) == 0;
                bool isFives = (i % 5) == 0;

                if (isThrees && isFives)
                {
                    System.Diagnostics.Debug.WriteLine("FizzBuzz");
                }
                else if (isThrees)
                {
                    System.Diagnostics.Debug.WriteLine("Fizz");
                }
                else if (isFives)
                {
                    System.Diagnostics.Debug.WriteLine("Buzz");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(i.ToString());
                }
            }
        }
    }

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
            if (right != null)
            {
                right.PrintKids(indent + 1);
            }
        }

        public static TreeNode BuildTree(int type)
        {
            if (type == 0)
            {
                TreeNode root = new TreeNode("root");
                return root.MakeKids(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            }
            else if (type == 1)
            {
                return null;
            }
            throw new NotImplementedException();
        }
    }

    // from http://www.codeproject.com/Articles/5603/QuickGraph-A-C-graph-library-with-Graphviz-Sup
    public class Graph
    {
        [DebuggerDisplay("data={data}")]
        public class Vertex
        {
            public object data;

            public Vertex(object d = null)
            {
                data = d;
            }
        }

        [DebuggerDisplay("data={data};{vertexOut.data}->{vertexIn.data}")]
        public class Edge
        {
            public Vertex vertexIn;
            public Vertex vertexOut;
            public object data;

            public Edge(Vertex vout, Vertex vin, object d = null)
            {
                vertexIn = vin;
                vertexOut = vout;
                data = d;
            }
        }

        public List<Vertex> m_vertexList = new List<Vertex>();
        public List<Edge> m_edgeList = new List<Edge>();

        public Vertex AddVertex(object value = null)
        {
            Vertex v = new Vertex(value);
            m_vertexList.Add(v);
            return v;
        }

        public Edge AddEdge(Vertex vout, Vertex vin, object value = null)
        {
            Edge e = new Edge(vout, vin, value);
            m_edgeList.Add(e);
            return e;
        }

        public static Graph CreateGraph(int type, object data)
        {
            if (type == 1)
            {
                Graph g = new Graph();
                Vertex u = g.AddVertex("u");
                Vertex v = g.AddVertex("v");
                Vertex w = g.AddVertex("w");
                Vertex x = g.AddVertex("x");
                Vertex y = g.AddVertex("y");
                Vertex z = g.AddVertex("z");
                g.AddEdge(u, v, "u->v"); // [u] --------> [x]
                g.AddEdge(u, x, "u->x"); //  ^ \         | ^
                g.AddEdge(v, y, "v->y"); //  |  >[v]<----  |
                g.AddEdge(y, x, "y->x"); //  |      \      |     
                g.AddEdge(x, v, "x->v"); //  |       \--> [y]
                g.AddEdge(w, u, "w->u"); // [w]------------^
                g.AddEdge(w, y, "w->y"); //  |
                g.AddEdge(w, z, "w->z"); //   ----------->[z]
                return g;
            }
            throw new NotImplementedException();
        }
    }
}

/*
Some solutions: https://github.com/qrafzv1/InterviewCake/tree/master/src


https://www.interviewcake.com/question/nth-fibonacci
Write a function fib() that a takes an integer nn and returns the nnth fibonacci ↴ number.
Let's say our fibonacci series is 0-indexed and starts with 0. So:

fib(0) # => 0
fib(1) # => 1
fib(2) # => 1
fib(3) # => 2
fib(4) # => 3
...
Do you have an answer?

https://www.interviewcake.com/question/largest-stack

You've implemented a Stack class, but you want to be able to access the largest element in a stack.
Here's the Stack class you have:

  class Stack:

    # initialize an empty list
    def __init__(self):
        self.items = []

    # push a new item to the last index
    def push(self, item):
        self.items.append(item)

    # remove the last item
    def pop(self):
        # if the stack is empty, return None
        # (it would also be reasonable to throw an exception)
        if not self.items: return None

        return self.items.pop()

    # see what the last item is
    def peek(self):
        # if the stack is empty, return None
        if not self.items: return None

        return self.items[len(self.items)-1]
Use your Stack class to implement a new class MaxStack with a function get_max() that returns the largest element in the stack. 
get_max() should not remove the item.

Your stacks will contain only integers.

Do you have an answer?

https://www.interviewcake.com/question/product-of-other-numbers
You have an array of integers, and for each index you want to find the product of every integer except the integer at that index.
Write a function get_products_of_all_ints_except_at_index() that takes an array of integers and returns an array of the products.

For example, given:

  [1, 7, 3, 4]
your function would return:

  [84, 12, 28, 21]
by calculating:

[7*3*4, 1*3*4, 1*7*4, 1*7*3]

Do not use division in your solution.

https://www.interviewcake.com/question/merging-ranges

Your company built an in-house calendar tool called HiCal. 
You want to add a feature to see the times in a day when everyone is available.
To do this, you’ll need to know when any team is having a meeting. 
In HiCal, a meeting is stored as a tuple of integers (start_time, end_time). 
These integers represent the number of 30-minute blocks past 9:00am.

For example:

    (2, 3) # meeting from 10:00 – 10:30 am
    (6, 9) # meeting from 12:00 – 1:30 pm

Write a function condense_meeting_times() that takes an array of meeting time ranges and 
returns an array of condensed ranges.

For example, given:

  [(0, 1), (3, 5), (4, 8), (10, 12), (9, 10)]
your function would return:

  [(0, 1), (3, 8), (9, 12)]

Do not assume the meetings are in order. The meeting times are coming from multiple teams.

In this case the possibilities for start_time and end_time are bounded by the number of 
30-minute slots in a day. But soon you plan to refactor HiCal to store times as Unix 
timestamps (which are big numbers). Write something that's efficient even when we can't 
put a nice upper bound on the numbers representing our time ranges.

https://www.interviewcake.com/question/delete-node

Delete a node from a singly-linked list, given only a variable pointing to that node.

The input could, for example, be the variable b below:

a = Node('A')
b = Node('B')
c = Node('C')

a.next = b
b.next = c

delete_node(b)
Do you have an answer?

*/
