using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<GasPump> queue = new Queue<GasPump>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int fuel = int.Parse(input.Split()[0]);
                int distance = int.Parse(input.Split()[1]);
                var pump = new GasPump(i, fuel, distance);
                queue.Enqueue(pump);
            }

            int startingPumpIndex = 0;
            while (true)
            {
                int gasInTank = 0;
                foreach (var pump in queue)
                {
                    int currentIndex = pump.PumpIndex;
                    int currentFuel = pump.Fuel;
                    int distanceToNextPump = pump.Distance;

                    gasInTank += currentFuel;
                    gasInTank -= distanceToNextPump;

                    if (gasInTank < 0)
                    {
                        GasPump itemToMove = queue.Dequeue();
                        queue.Enqueue(itemToMove);
                        startingPumpIndex++;
                        break;
                    }
                }

                if (gasInTank >= 0)
                {
                    Console.WriteLine(startingPumpIndex);
                    return;
                }

            }

        }
    }

    class GasPump
    {
        public int PumpIndex { get; set; }
        public int Fuel { get; set; }
        public int Distance { get; set; }

        public GasPump(int index, int fuel, int distance)
        {
            PumpIndex = index;
            Fuel = fuel;
            Distance = distance;
        }
    }
}
