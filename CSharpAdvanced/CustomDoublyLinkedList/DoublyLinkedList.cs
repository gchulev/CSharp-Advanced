using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; }
        public ListNode Head { get; private set; }
        public ListNode Tail { get; private set; }

        public void AddFirst(T element)
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

        public void AddLast(T element)
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

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.Tail.Value;
            this.Tail = this.Tail.PreviousNode;

            if (this.Tail != null)
            {
                this.Tail.NextNode = null;
            }
            else
            {
                this.Head = null;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            this.ForEach(n => list.Add(n));
            return list;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentVal = Head.Value;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentVal;
                currentVal = Head.NextNode.Value;
            }
            return array;

        }
        public class ListNode
        {
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }
    }
}
