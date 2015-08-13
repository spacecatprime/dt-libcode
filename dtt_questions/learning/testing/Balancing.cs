using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/// <summary>
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

        [TestMethod]
        public void Balancing_superbalanced()
        {
            TreeNode tree = TreeNode.BuildTree(0);
            tree.PrintKids(0);
        }

        [TestMethod]
        public void DoDepthFirstSearch()
        {
            Graph g = Graph.CreateGraph(1, null);
            DepthFirstSearch dfs = new DepthFirstSearch(g);
            dfs.m_visit = (data => System.Diagnostics.Debug.WriteLine(data));
            dfs.Compute("z");
            Assert.IsNotNull(dfs.m_found);
            Assert.IsFalse(dfs.FindValueFrom(g.m_vertexList[0], "z"));
        }

        class DepthFirstSearch
        {
            private Graph m_graph;
            private List<Graph.Vertex> m_visited = new List<Graph.Vertex>();
            private List<Graph.Edge> m_edges = new List<Graph.Edge>();

            public Graph.Vertex m_found = null;
            public Action<object> m_visit;

            public DepthFirstSearch(Graph g)
            {
                m_graph = g;
            }

            private void Reset()
            {
                m_visited.Clear();
                m_edges.Clear();
                m_found = null;
            }

            public void Compute(object value)
            {
                Reset();
                while (m_found == null && m_visited.Count < m_graph.m_vertexList.Count)
                {
                    Graph.Vertex next = m_graph.m_vertexList.First(v => m_visited.Contains(v) == false);
                    ExploreVertex(next, value);
                }
            }

            public bool FindValueFrom(Graph.Vertex start, object value)
            {
                Reset();
                ExploreVertex(start, value);
                return m_found != null;
            }

            public void ExploreVertex(Graph.Vertex v, object value)
            {
                if (v.data.Equals(value))
                {
                    SignalVisit(v.data);
                    m_found = v;
                }
                else if(m_visited.Contains(v) == false)
                {
                    SignalVisit(v.data);
                    m_visited.Add(v);
                    var edges = m_graph.m_edgeList.Where(e => e.vertexOut == v);
                    foreach (var e in edges)
                    {
                        if (m_edges.Contains(e))
                        {
                            continue;
                        }
                        SignalVisit(e.data);
                        m_edges.Add(e);
                        ExploreVertex(e.vertexIn, value);
                    }
                }
            }

            private void SignalVisit(object data)
            {
                if (m_visit != null)
                {
                    m_visit.Invoke(data);
                }
            }
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
