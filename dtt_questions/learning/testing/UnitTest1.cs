using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}

/*
https://www.interviewcake.com/question/coin
Imagine you landed a new job as a cashier...
Your quirky boss found out that you're a programmer and has a weird request about something they've been wondering for a long time.

Write a function that, given:

an amount of money
a list of coin denominations
computes the number of ways to make amount of money with coins of the available denominations.

Example: for amount=44 (44¢) and denominations=[1,2,3][1,2,3] (11¢, 22¢ and 33¢), your program would output 44—the number of ways to make 44¢ with those denominations:

1¢, 1¢, 1¢, 1¢
1¢, 1¢, 2¢
1¢, 3¢
2¢, 2¢

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
Use your Stack class to implement a new class MaxStack with a function get_max() that returns the largest element in the stack. get_max() should not remove the item.

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
