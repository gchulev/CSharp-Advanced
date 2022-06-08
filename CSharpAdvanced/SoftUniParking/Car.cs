using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string _make;
        private string _model;
        private int _horsePower;
        private string _registrationNumber;

        public string Make { get { return _make; } set { _make = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int HorsePower { get { return _horsePower; } set { _horsePower = value; } }
        public string RegistrationNumber { get { return _registrationNumber; } set { _registrationNumber = value; } }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"HorsePower: {HorsePower}");
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString();
        }
    }
}
