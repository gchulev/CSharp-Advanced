using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public List<int> Stones { get; set; }

        public Lake()
        {
            this.Stones = new List<int>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int num in this.Stones)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (int num in this.Stones)
            {
                yield return num;
            }
        }
    }
}
