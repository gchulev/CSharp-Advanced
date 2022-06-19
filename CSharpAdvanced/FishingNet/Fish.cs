using System;
using System.Diagnostics.CodeAnalysis;

namespace FishingNet
{
    public class Fish : IComparable<Fish>
    {
        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }

        public Fish(string fishType, double length, double weight)
        {
            FishType = fishType;
            Length = length;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }

        public int CompareTo([AllowNull] Fish otherFish)
        {
            if (otherFish != null)
            {
                return -1;
            }
            int result = this.Length.CompareTo(otherFish.Length);
            return result;
        }
    }
}
