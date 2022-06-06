using System;
using System.Collections.Generic;

namespace CarSalesman
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            var engines = new List<Engine>();

            //Engines
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                string displacement = "n/a";
                string efficienty = "n/a";

                if (input.Length == 4)
                {
                    displacement = input[2];
                    efficienty = input[3];
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int result))
                    {
                        displacement = result.ToString();
                    }
                    else
                    {
                        efficienty = input[2];
                    }
                }

                engines.Add(new Engine(model, power, displacement, efficienty));
            }

            int m = int.Parse(Console.ReadLine());

            //Cars
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engine = input[1];
                string weight = "n/a";
                string color = "n/a";

                if (input.Length == 4)
                {
                    weight = input[2];
                    color = input[3];
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int output))
                    {
                        weight = output.ToString();
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                Engine currentEngine = engines.Find(x => x.Model == engine);
                Car currentCar = new Car(model, currentEngine, weight, color);
                cars.Add(currentCar);
            }

            foreach (Car car in cars)
            {
                Console.Write(car);
            }
        }
    }
}
