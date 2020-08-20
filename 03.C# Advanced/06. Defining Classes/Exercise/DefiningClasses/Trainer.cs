using DefiningClasses;
using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }
    public int BadgesCount { get; set; }
    public List<Pokemon> PokemonCollection { get; set; }

    public Trainer()
    {
        this.PokemonCollection = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.PokemonCollection.Add(pokemon);
    }

    public void ReduceHealth()
    {
        for (int i = this.PokemonCollection.Count - 1; i >= 0; i--)
        {
            this.PokemonCollection[i].Health -= 10;

            if (this.PokemonCollection[i].Health <= 0)
            {
                this.PokemonCollection.Remove(this.PokemonCollection[i]);
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.BadgesCount} {this.PokemonCollection.Count}";
    }
}