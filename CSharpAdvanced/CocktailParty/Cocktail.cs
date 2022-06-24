using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return Ingredients.Sum(x => x.Alcohol); } }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (Capacity > Ingredients.Count && (MaxAlcoholLevel - Ingredients.Sum(i => i.Alcohol) >= ingredient.Alcohol) && !Ingredients.Any(x => x.Name == ingredient.Name))
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return Ingredients.Remove(Ingredients.FirstOrDefault(x => x.Name.Equals(name)));
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name.Equals(name));
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}{Environment.NewLine}{string.Join(Environment.NewLine, Ingredients)}";
        }
    }
}
