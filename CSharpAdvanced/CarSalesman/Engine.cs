using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine(string displacement = "n/a", string efficiency = "n/a")
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public Engine(string model, int power, string displacement = "n/a", string efficiency = "")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

    }
}
