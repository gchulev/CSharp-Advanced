using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }

        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.");
            return sb.ToString();
        }
    }
}
