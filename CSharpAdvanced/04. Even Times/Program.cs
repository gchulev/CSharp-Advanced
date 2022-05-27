using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }
                numbers[num] += 1;
            }

            int evenTimesNum = numbers.First(x => x.Value % 2 == 0).Key;
            Console.WriteLine(evenTimesNum);
        }
    }
}
