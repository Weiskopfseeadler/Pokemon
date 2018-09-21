using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using poke.model;

namespace pokemon.savs
{
    public interface TeamInterface
    {


        bool CheckIsAktivePokemonKO();
        bool CheckAreAllPokemonKO();
        void ChangeAttack(int IndexPokemon, int IndexAttacke, string attackKey);
        void ChangeAktivePokemon();
    }
}