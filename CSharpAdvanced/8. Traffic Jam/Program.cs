using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main()
        {
            int numOfCars = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            List<string> passedCars = new List<string>();

            while (command != "end")
            {
                if (command.Equals("green"))
                {
                    for (int i = 0; i < numOfCars; i++)
                    {
                        if (queue.Count == 0)
                        {
                            continue;
                        }
                        string currentCar = queue.Dequeue();
                        passedCars.Add(currentCar);
                        Console.WriteLine($"{currentCar} passed!");
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars.Count} cars passed the crossroads.");
        }
    }
}
