using System.Collections.Generic;
using poke.model;

namespace pokemon.savs
{
    public interface GeneratInterface 
    {
        void GeneratAttack();
        void GeneratPokemon();
        void Serialize();
    }
}