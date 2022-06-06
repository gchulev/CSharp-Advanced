using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Model}: ");
            sb.AppendLine($"  { Engine.Model}: ");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {Engine.Displacement}");
            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine($"Weight: {this.Weight}");
            sb.AppendLine($"Color: {this.Color}");

            return sb.ToString();
        }
    }
}
