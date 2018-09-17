using System;
using System.Collections.Generic;
using poke.model;

namespace pokemon.savs
{
    public class TeamEnemy : TeamInterface
    {
        public int ActivePokemon { get; set; }
        public List<Pokemon> Team { get; set; }= new List<Pokemon>();

        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = Team[ActivePokemon].LivePoints > 0;

            return checkIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool death = true;
            for (int i = 0; i < 6; i++)
            {
                if (Team[i].LivePoints != 0)
                {
                    death = false;
                }
            }

            return death;
        }

        public void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey)
        {
            throw new System.NotImplementedException();
        }

        public void CangeAktivePokemon()
        {
            int index = 0;
            Console.WriteLine("enemy turn");


            bool pokemonNotChosen = true;
            while (pokemonNotChosen)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 5);

                if (Team[randomNumber].LivePoints == 0)
                {
                    pokemonNotChosen = false;
                    ActivePokemon = randomNumber;
                }
            }
        }

        public void SetTeam()
        {
            this.ActivePokemon = 0;
  
            Team.Add(new Pokemon(Generate.PokemonHash["charmander"]));
            Team.Add(new Pokemon(Generate.PokemonHash["evoli"]));
            Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
        }
    }
}