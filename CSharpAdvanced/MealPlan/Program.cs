using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main()
        {
            var meals = new Dictionary<string, int>()
            {
                ["salad"] = 350,
                ["soup"] = 490,
                ["pasta"] = 680,
                ["steak"] = 790
            };

            var mealsQueue = new Queue<string>(Console.ReadLine().Split(" "));
            var calorieDaysStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int initialMealsCount = mealsQueue.Count;
            int currentDayCalories = calorieDaysStack.Peek();
            string currentMealName = mealsQueue.Peek();
            int currentMealCalories = meals[currentMealName];

            while (mealsQueue.Count > 0 && calorieDaysStack.Count > 0)
            {
                if (currentMealCalories == 0)
                {
                    currentMealName = mealsQueue.Peek();
                    currentMealCalories = meals[currentMealName];
                }

                currentDayCalories -= currentMealCalories;
                calorieDaysStack.Pop();
                calorieDaysStack.Push(currentDayCalories);

                if (currentDayCalories <= 0)
                {
                    currentMealCalories = Math.Abs(currentDayCalories);
                    calorieDaysStack.Pop();
                    if (calorieDaysStack.Count > 0)
                    {
                        currentDayCalories = calorieDaysStack.Peek();
                    }
                    else
                    {
                        mealsQueue.Dequeue();
                    }

                }
                else
                {
                    currentMealCalories = 0;
                    mealsQueue.Dequeue();
                }

            }

            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {initialMealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calorieDaysStack)} calories.");
            }
            else if (calorieDaysStack.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {initialMealsCount - mealsQueue.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");
            }

        }
    }
}
