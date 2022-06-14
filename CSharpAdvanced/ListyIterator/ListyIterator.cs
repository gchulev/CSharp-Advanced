using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Items { get; private set; }
        private int InternalIndex { get; set; }

        public ListyIterator(List<T> items)
        {
            this.Items = items;
            this.InternalIndex = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                InternalIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            int nextIndex = InternalIndex + 1;
            if (nextIndex >= this.Items.Count)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine($"{this.Items[InternalIndex]}");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var enumerator = this.Items[i];
                yield return enumerator;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var enumerator = this.Items[i];
                yield return enumerator;
            }
        }
    }
}
