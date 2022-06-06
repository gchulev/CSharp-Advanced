using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        private string _model;
        private double _fuelAmount;
        private double _fuelConsumptionPerKilometer;
        private double _travelledDistance;

        public string Model
        {
            get
            {
                return _model;
            }
            set { _model = value; }
        }
        public double FuelAmount
        {
            get
            {
                return _fuelAmount;
            }
            set
            {
                _fuelAmount = value;
            }
        }
        public double FuelconsumptionPerKilometer
        {
            get
            {
                return _fuelConsumptionPerKilometer;
            }
            set
            {
                _fuelConsumptionPerKilometer = value;
            }
        }
        public double TravelledDistance 
        {
            get 
            {
                return _travelledDistance;
            }
            set
            {
                _travelledDistance = value;
            } 
        }

        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelconsumptionPerKilometer = fuelConsumption;
        }

        public void MoveCar(double kmTravelled)
        {
            double fuelNeeded = kmTravelled * FuelconsumptionPerKilometer;
            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += kmTravelled;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
