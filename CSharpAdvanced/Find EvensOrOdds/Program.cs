using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_EvensOrOdds
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int lowerBound = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            int upperBound = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
            string command = Console.ReadLine();
            var numbers = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEvenOrOdd = null;

            var result = new List<int>();

            if (command.Equals("even"))
            {
                isEvenOrOdd = num => num % 2 == 0;
            }
            else if (command.Equals("odd"))
            {
                isEvenOrOdd = num => num % 2 != 0;
            }
            result = numbers.FindAll(isEvenOrOdd);
            Console.WriteLine(String.Join(' ', result));
        }
    }
}
