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
        void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey);
        void CangeAktivePokemon();
        void SetDefault();
    }
}