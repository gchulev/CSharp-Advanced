using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public List<Ski> Data { get { return data; } set { data = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (Capacity > Data.Count)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = Data.FirstOrDefault(x => x.Manufacturer.Equals(manufacturer) && x.Model.Equals(model));
            return Data.Remove(skiToRemove);
        }

        public Ski GetNewestSki()
        {
            return Data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.FirstOrDefault(x => x.Manufacturer.Equals(manufacturer) && x.Model.Equals(model));
        }

        public string GetStatistics()
        {
            return $"The skis stored in {Name}:{Environment.NewLine}{string.Join(Environment.NewLine, data)}";
        }
    }
}
