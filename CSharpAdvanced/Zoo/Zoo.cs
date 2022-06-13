using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (this.Capacity <= this.Animals.Count)
            {
                return "The zoo is full.";
            }
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimalsCount = this.Animals.RemoveAll(a => a.Species == species);
            return removedAnimalsCount;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsByDiet = this.Animals.FindAll(animal => animal.Diet == diet);
            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            var animal = this.Animals.FirstOrDefault(animal => animal.Weight == weight);
            return animal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalsCount = this.Animals.Where(animal => animal.Length <= maximumLength && animal.Length >= minimumLength).Count();
            return $"There are {animalsCount} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
