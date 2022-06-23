using System;
using System.Linq;
using System.Collections.Generic;

namespace Masterchef
{
    internal class Program
    {
        static void Main()
        {
            var dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };

            var ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var freshnesLevel = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (ingredients.Count > 0 && freshnesLevel.Count > 0)
            {
                int currentIngredient = ingredients.Peek();
                int currentFreshnesLevel = freshnesLevel.Peek();
                int multyplication = currentIngredient * currentFreshnesLevel;

                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                switch (multyplication)
                {
                    case 150:
                        dishes["Dipping sauce"]++;
                        ingredients.Dequeue();
                        freshnesLevel.Pop();
                        break;
                    case 250:
                        dishes["Green salad"]++;
                        ingredients.Dequeue();
                        freshnesLevel.Pop();
                        break;
                    case 300:
                        dishes["Chocolate cake"]++;
                        ingredients.Dequeue();
                        freshnesLevel.Pop();

                        break;
                    case 400:
                        dishes["Lobster"]++;
                        ingredients.Dequeue();
                        freshnesLevel.Pop();
                        break;
                    default:
                        currentIngredient += 5;
                        ingredients.Dequeue();
                        ingredients.Enqueue(currentIngredient);
                        freshnesLevel.Pop();
                        break;
                }
            }

            var finalDishes = dishes.Where(d => d.Value > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            if (finalDishes.Count >= 4)
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in finalDishes.OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
