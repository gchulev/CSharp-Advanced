using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> _cars;
        private int capacity;

        public List<Car> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                _cars = value;
            }
        }
        public int Count
        {
            get
            {
                return _cars.Count;
            }
        }
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(c => c.RegistrationNumber.Equals(car.RegistrationNumber)))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(c => c.RegistrationNumber.Equals(registrationNumber)))
            {
                Cars.Remove(Cars.Find(c => c.RegistrationNumber.Equals(registrationNumber)));
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.First(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string regNum in registrationNumbers)
            {
                RemoveCar(regNum);
            }
        }
    }
}
