using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var colours = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] items = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!colours.ContainsKey(colour))
                {
                    colours.Add(colour, new Dictionary<string, int>());
                }

                Dictionary<string, int> clothes = colours[colour];

                foreach (string item in items)
                {
                    if (!clothes.ContainsKey(item))
                    {
                        clothes.Add(item, 0);
                    }
                    clothes[item]++;
                }
            }
            string[] itemToFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colourToFind = itemToFind[0];
            string itemName = itemToFind[1];

            foreach (var colour in colours)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var item in colour.Value)
                {
                    if (colour.Key.Equals(colourToFind) && item.Key.Equals(itemName))
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
