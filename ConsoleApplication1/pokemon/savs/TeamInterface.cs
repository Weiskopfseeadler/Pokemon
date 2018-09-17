using System.Collections.Generic;
using System.Dynamic;
using poke.model;

namespace pokemon.savs
{
    public interface TeamInterface
    {
        int ActivePokemon
        {
            get;
            set;
        }

        List<Pokemon>  Team 
        {
            get;
            set;
        }

        bool CheckIsAktivePokemonKO();
        bool CheckAreAllPokemonKO();
        void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey);
        void CangeAktivePokemon();
        void SetTeam();








    }
}