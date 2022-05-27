using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var counterDict = new Dictionary<char, int>();

            foreach (char character in input)
            {
                if (!counterDict.ContainsKey(character))
                {
                    counterDict.Add(character, 0);
                }
                counterDict[character]++;
            }
            var sortedDict = counterDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var kvp in sortedDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
