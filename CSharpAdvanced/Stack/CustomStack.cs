using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> Items { get; set; }
        public int Count { get { return this.Items.Count; } }

        public CustomStack(params T[] args)
        {
            this.Items = new List<T>(args);
        }

        public void Push(T element)
        {
            this.Items.Add(element);
        }

        public T Pop()
        {
            var lastElement = this.Items.Last();
            this.Items.Remove(lastElement);
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = this.Items.Count; i >= 0; i--)
            {
                yield return this.Items[i];
            }
        }
    }
}
