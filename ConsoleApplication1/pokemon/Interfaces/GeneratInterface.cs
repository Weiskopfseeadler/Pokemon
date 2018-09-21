using System.Collections.Generic;
using poke.model;

namespace pokemon.savs
{
    public interface GeneratInterface
    {
        Dictionary<string, Attack> DictionaryOfAttacks { get; set; } 

        Dictionary<string, Pokemon> DictionaryOfPokemons { get; set; }
        void GeneratAttack();
        void GeneratPokemon();
        void Serialize();
    }
}