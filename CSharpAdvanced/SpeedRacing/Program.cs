using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    internal class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                cars.Add(new Car(carModel, fuelAmount, fuelConsumption));
            }

            while (true)
            {
                string input = Console.ReadLine();
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                if (input.Equals("End"))
                {
                    break;
                }
                else if (command.Equals("Drive"))
                {
                    string carModel = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                    double traveledDistance = double.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                    var currentCar = cars.Find(x => x.Model == carModel);
                    currentCar.MoveCar(traveledDistance);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
