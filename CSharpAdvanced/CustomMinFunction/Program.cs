using System;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> result = n => n.Min();

            Console.WriteLine(result(input)); 
        }
    }
}
