using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var trainers = new List<Trainer>();

        string command;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            var pokemonInfo = command.Split();
            var trainerName = pokemonInfo[0];

            var pokemon = new Pokemon(pokemonInfo[1], pokemonInfo[2], int.Parse(pokemonInfo[3]));

            var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer();
                trainer.Name = trainerName;
                trainer.AddPokemon(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                trainer.AddPokemon(pokemon);
            }
        }

        while ((command = Console.ReadLine()) != "End")
        {
            switch (command)
            {
                case "Fire":
                    ProceedCommand(command, trainers);
                    break;
                case "Water":
                    ProceedCommand(command, trainers);
                    break;
                case "Electricity":
                    ProceedCommand(command, trainers);
                    break;
                default:
                    break;
            }
        }

        PrintResult(trainers);
    }

    private static void PrintResult(List<Trainer> trainers)
    {
        foreach (var trainer in trainers.OrderByDescending(x => x.BadgesCount))
        {
            Console.WriteLine(trainer);
        }
    }

    private static void ProceedCommand(string command, List<Trainer> trainers)
    {
        foreach (var trainer in trainers)
        {
            if (trainer.PokemonCollection.Any(p => p.Element == command))
            {
                trainer.BadgesCount += 1;
            }
            else
            {
                trainer.ReduceHealth();
            }
        }
    }
}