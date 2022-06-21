using System;
using System.Linq;
using System.Collections.Generic;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return this.Drones.Count; } }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || !(drone.Range > 5 && drone.Range < 15))
            {
                return "Invalid drone.";
            }
            if (this.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }
            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            return this.Drones.Remove(this.Drones.Find(dr => dr.Name.Equals(name)));
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(dr => dr.Brand.Equals(brand));
        }

        public Drone FlyDrone(string name)
        {
            Drone droneFound = this.Drones.Find(dr => dr.Name.Equals(name));
            if (droneFound != null)
            {
                droneFound.Available = false;
            }
            return droneFound;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var flownDrones = this.Drones.FindAll(dr => dr.Range >= range);
            flownDrones = flownDrones.Select(dr => { dr.Available = false; return dr; }).ToList();
            return flownDrones;
        }

        public string Report()
        {
            return $"Drones available at {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Drones.Where(dr => dr.Available == true))}";
        }
    }
}
