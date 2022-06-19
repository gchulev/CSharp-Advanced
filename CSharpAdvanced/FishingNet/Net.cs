using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return Fish.Count;
            }
        }

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (this.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Exists(fish => fish.Weight.Equals(weight)))
            {
                Fish fishToRemove = this.Fish.Find(fish => fish.Weight.Equals(weight));
                this.Fish.Remove(fishToRemove);
                return true;
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fishFound = this.Fish.Find(x => x.FishType.Equals(fishType));
            return fishFound;
        }

        public Fish GetBiggestFish()
        {
            Fish longestFish = this.Fish.OrderByDescending(x => x.Length).Max();
            return longestFish;
        }

        public string Report()
        {
            return $"Into the: {Material}: {Environment.NewLine}{string.Join(Environment.NewLine, this.Fish.OrderByDescending(x => x.Length))}";
        }
    }
}
