using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; } 
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }
    }
}
