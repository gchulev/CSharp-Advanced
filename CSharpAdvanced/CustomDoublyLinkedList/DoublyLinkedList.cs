using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }

            private ListNode Head { get; set; }
            private ListNode Tail { get; set; }

            public int Count { get; set; }

            public void AddFirst(int element)
            {
                if (this.Count == 0)
                {
                    this.Head = this.Tail = new ListNode(element);
                }
                else
                {
                    var newHead = new ListNode(element);
                    newHead.NextNode = this.Head;
                    this.Head.PreviousNode = newHead;
                    this.Head = newHead;
                }
                this.Count++;
            }

            public void AddLast(int element)
            {

                if (this.Count == 0)
                {
                    this.Tail = this.Head = new ListNode(element);
                }
                else
                {
                    var newTail = new ListNode(element);
                    newTail.NextNode = this.Tail;
                    this.Tail.PreviousNode = newTail;
                    this.Tail = newTail;
                }
                Count++;
            }

            public int RemoveFirst()
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("The list is empty");
                }

                var firstElement = this.Head.Value;
                this.Head = this.Head.NextNode;

                if (Head != null)
                {
                    this.Head.PreviousNode = null;
                }
                else
                {
                    this.Tail = null;
                }
                Count--;
                return firstElement;
            }
        }
    }
}
