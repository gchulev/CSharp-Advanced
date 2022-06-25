using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return Renovators.Count; } }

        public Catalog(string name, int needRenovator, string project)
        {
            Name = name;
            NeededRenovators = needRenovator;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (Count >= NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            return Renovators.Remove(Renovators.FirstOrDefault(x => x.Name.Equals(name)));
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return Renovators.RemoveAll(x => x.Type.Equals(type));
        }

        public Renovator HireRenovator(string name)
        {
            var hiredRenovator = Renovators.FirstOrDefault(r => r.Name.Equals(name));
            if (hiredRenovator != null)
            {
                hiredRenovator.Hired = true;
            }
            return hiredRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            return $"Renovators available for Project {Project}:{Environment.NewLine}{string.Join(Environment.NewLine, Renovators.Where(x => x.Hired == false))}";
        }

    }
}
