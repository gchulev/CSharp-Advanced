using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    internal class Program
    {
        static void Main()
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0].Equals("Tournament"))
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name.Equals(trainerName)))
                {
                    var currentTrainer = trainers.Find(x => x.Name.Equals(trainerName));
                    currentTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    var currentTrainer = new Trainer(trainerName);
                    currentTrainer.Pokemons.Add(pokemon);
                    trainers.Add(currentTrainer);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("End"))
                {
                    break;
                }
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            var sortedTrainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();
            
            foreach (Trainer trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
