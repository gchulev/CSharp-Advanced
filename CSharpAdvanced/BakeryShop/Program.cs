using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main()
        {
            Queue<double> waterCollection = new Queue<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            Stack<double> flourCollection = new Stack<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());

            var bakedProducts = new Dictionary<string, int>()
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };

            while (waterCollection.Count > 0 && flourCollection.Count > 0)
            {
                double water = waterCollection.Dequeue();
                double flour = flourCollection.Peek();
                string product = FindProductToBake(water, flour);

                //baking products here
                switch (product)
                {
                    case "Croissant":
                        flourCollection.Pop();//removing the flour (* water has already been removed)
                        bakedProducts["Croissant"]++;
                        break;

                    case "Muffin":
                        flourCollection.Pop();//removing the flour (* water has already been removed)
                        bakedProducts["Muffin"]++;
                        break;

                    case "Baguette":
                        flourCollection.Pop();//removing the flour (* water has already been removed)
                        bakedProducts["Baguette"]++;
                        break;

                    case "Bagel":
                        flourCollection.Pop();//removing the flour (* water has already been removed)
                        bakedProducts["Bagel"]++;
                        break;

                    case "Incorrect ratio":
                        flour -= water;
                        flourCollection.Pop();
                        flourCollection.Push(flour);
                        bakedProducts["Croissant"]++;
                        break;

                    default:
                        break;
                }
            }

            var sortedProducts = bakedProducts.Where(prod => prod.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var kvp in sortedProducts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (waterCollection.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterCollection)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourCollection.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourCollection)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
        public static string FindProductToBake(double water, double flour)
        {
            double waterPersentage = (water / (water + flour)) * 100;
            double flourPersentage = (flour / (water + flour)) * 100;

            if (waterPersentage == 50 && flourPersentage == 50)
            {
                return "Croissant";
            }
            else if (waterPersentage == 40 && flourPersentage == 60)
            {
                return "Muffin";
            }
            else if (waterPersentage == 30 && flourPersentage == 70)
            {
                return "Baguette";
            }
            else if (waterPersentage == 20 && flourPersentage == 80)
            {
                return "Bagel";
            }
            else
            {
                return "Incorrect ratio";
            }
        }
    }
}
