using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
https://www.interviewcake.com/question/linked-list-cycles
You have a singly-linked list ↴ and want to check if it contains a cycle.
A singly-linked list is built with Nodes, where each node has:

node.next — the next node in the list.
node.data — the data held in the node. 

For example, if our linked list stores people in line at the movies, node.data might be the person's name.

A cycle occurs when a node’s next points back to a previous node in the list. 

The linked list is no longer linear with a beginning and end—instead, it cycles through a loop of nodes.

Write a function contains_cycle() that takes the first node in a singly-linked list and returns a boolean indicating whether the list contains a cycle.

For this problem, you cannot make any changes to the Node class.

Do you have an answer?
*/
namespace testing
{
    [TestClass]
    public class LinkedListCycles
    {
        [TestMethod]
        public void DoLinkedListCycles()
        {
            ListNode qux = new ListNode(null, "qux");
            ListNode baz = new ListNode(qux, "baz");
            ListNode bar = new ListNode(baz, "bar");
            ListNode foo = new ListNode(bar, "foo");
            ListNode head = new ListNode(foo, "head");
            qux.next = baz;
            Assert.IsTrue(ContainsCycle(head));
        }

        public bool ContainsCycle(ListNode node)
        {
            if (node == null)
            {
                return false;
            }
            else if (node.next == null)
            {
                return false;
            }
            else if (node.next.next == node)
            {
                return true;
            }
            return ContainsCycle(node.next);
        }
    }

    public class ListNode
    {
        public ListNode next;
        public Object data;

        public ListNode(ListNode n, Object d)
        {
            next = n;
            data = d;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
