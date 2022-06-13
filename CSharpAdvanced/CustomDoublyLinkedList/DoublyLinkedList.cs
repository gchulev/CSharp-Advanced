using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public int Count { get; private set; }
        public ListNode Head { get; private set; }
        public ListNode Tail { get; private set; }

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
                var previousTail = this.Tail;
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.Tail;
                this.Tail.PreviousNode = newTail;
                this.Tail = newTail;
            }
            this.Count++;
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

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.Tail.Value;

            if (this.Tail.PreviousNode == null)
            {
                this.Tail = this.Head = null;
            }
            else
            {
                this.Tail.NextNode = null;
                this.Tail.PreviousNode = null;

                this.Tail = this.Tail.PreviousNode;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public List<int> ToList(int num)
        {
            List<int> list = new List<int>();
            this.ForEach(n => list.Add(n));
            return list;
        }

        public class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }
        }
    }
}
