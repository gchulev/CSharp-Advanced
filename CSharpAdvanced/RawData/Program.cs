using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                float tire1Pressure = float.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                float tire2Pressure = float.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                float tire3Pressure = float.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                float tire4Pressure = float.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                var tire1 = new Tire(tire1Age, tire1Pressure);
                var tire2 = new Tire(tire2Age, tire2Pressure);
                var tire3 = new Tire(tire3Age, tire3Pressure);
                var tire4 = new Tire(tire4Age, tire4Pressure);

                var tires = new List<Tire>();

                tires.Add(tire1);
                tires.Add(tire2);
                tires.Add(tire3);
                tires.Add(tire4);

                Car currentCar = new Car(model, engine, tires, cargo);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();
            if (command.Equals("fragile"))
            {
                var filteredCars = cars.Where(tires => tires.Tires.Any(tire => tire.Pressure < 1)).ToList();
                Console.WriteLine(String.Join(Environment.NewLine, filteredCars.Select(car => car.Model)));
            }
            else if (command.Equals("flammable"))
            {
                var filteredCars = cars.Where(engine => engine.Engine.Power > 250).ToList();
                Console.WriteLine(String.Join(Environment.NewLine, filteredCars.Select(car => car.Model)));
            }
        }
    }
}
