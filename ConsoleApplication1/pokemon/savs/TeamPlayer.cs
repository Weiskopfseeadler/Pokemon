using System;
using System.Collections.Generic;
using poke.model;

namespace pokemon.savs
{
    public class TeamPlayer : TeamInterface
    {
        public int ActivePokemon { get; set; }
        public List<Pokemon> Team { get; set; } = new List<Pokemon>();
        

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
            
            
            Team[indexPokemon].PokeAttackHash[indexAttacke] = Generate.AttackHash[attackKey];
        }

        public void CangeAktivePokemon()
        {
            int index = 0;
            Console.WriteLine("player turn");


            bool pokemonNotChosen = true;
            while (pokemonNotChosen)
            {
                Console.Write("Enter Integer 1-6:");
                Console.WriteLine("");

                for (int y = 0; y < 6; y++)
                {
                    if (Team[y].LivePoints > 0)
                    {
                        Console.WriteLine("Nummer " + (y + 1) + "   " + Team[y].ToString());
                    }
                }

                index = Convert.ToInt32(Console.ReadLine());

                if (index > 0 && index <= 6)
                {
                    pokemonNotChosen = false;
                    index -= 1;
                    ActivePokemon = index;
                }
            }
        }

        public void SetTeam()
        {
            this.ActivePokemon = 0;
           
            Generate.GeneratAttack();
            Generate.GeneratPokemon();
            this.Team.Add(new Pokemon(Generate.PokemonHash["pikatchu"]));
            this.Team.Add(new Pokemon(Generate.PokemonHash["evoli"]));
            this.Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            this.Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            this.Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
            this.Team.Add(new Pokemon(Generate.PokemonHash["empty"]));
          
        }
    }
}