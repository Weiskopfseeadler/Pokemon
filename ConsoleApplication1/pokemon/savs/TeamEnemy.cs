using System;
using System.Collections.Generic;
using System.Linq;
using poke.model;

namespace pokemon.savs
{
    public class TeamEnemy : TeamInterface
    {
        public int ActivePokemon { get; set; }
        public List<Pokemon> Team { get; set; } = new List<Pokemon>();
        public Random Random = new Random();
        
        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = !(Team[ActivePokemon].LivePoints > 0);

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
            Console.WriteLine("enemy turn");
            bool pokemonNotChosen = true;
            while (pokemonNotChosen)
            {
                
                int randomNumber = Random.Next(0, 5);

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

        public void RandomEnemy()
        { 
            
            for (int i = Random.Next(0, 5); i < 6; i++)
            {
                Team[i]=Generate.PokemonHash.ElementAt(Random.Next(0, Generate.AttackHash.Count)).Value;
                Console.WriteLine(Team[i].ToString());
            }
            
             
        }
    }
}