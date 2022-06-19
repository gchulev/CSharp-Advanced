using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main()
        {
            var swords = new Dictionary<string, int>()
            {
                {"Gladius", 0},
                {"Shamshir", 0 },
                {"Katana", 0 },
                {"Sabre", 0 },
                {"Broadsword", 0}
            };
            var steel = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            var carbon = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (steel.Count > 0 && carbon.Count > 0)
            {
                var currentSteel = steel.Dequeue();
                var currentCarbon = carbon.Pop();
                var sum = currentCarbon + currentSteel;

                switch (sum)
                {
                    case 70:
                        swords["Gladius"]++;
                        break;
                    case 80:
                        swords["Shamshir"]++;
                        break;
                    case 90:
                        swords["Katana"]++;
                        break;
                    case 110:
                        swords["Sabre"]++;
                        break;
                    case 150:
                        swords["Broadsword"]++;
                        break;
                    default:
                        currentCarbon += 5;
                        carbon.Push(currentCarbon);
                        break;
                }
            }

            if (swords.Any(x => x.Value > 0))
            {
                Console.WriteLine($"You have forged {swords.Sum(sw => sw.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
            var swordsForged = swords.Where(sword => sword.Value > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            if (swordsForged.Any(x => x.Value > 0))
            {
                foreach (var sword in swordsForged.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
