using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; } //made this a list to test the IComparable implementation
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count { get { return Participants.Count; } }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public void Add(Car car)
        {
            //checking if we have enough space for a new car and if the license plate is not already registered and if it meets the HP requirement
            if (Capacity > Count && !Participants.Any(c => c.LicensePlate.Equals(car.LicensePlate)) && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car carToRemove = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
            return Participants.Remove(carToRemove);
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            return $"Race: {Name} - Type: {Type} (Laps: {Laps}){Environment.NewLine}{string.Join(Environment.NewLine, Participants)}";
        }

    }
}
