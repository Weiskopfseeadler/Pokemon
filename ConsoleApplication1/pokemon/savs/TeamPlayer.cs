using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.poke.model;
using poke.model;

namespace pokemon.savs
{
    public class TeamPlayer : TeamInterface
    {
        public int ActivePokemon { get; set; }
        public List<Pokemon> Team { get; set; } = new List<Pokemon>();
        public Dictionary<string ,Item> Items{ get; set; }= new Dictionary<string, Item>();


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
        public void ChoseItem()
        {
            Console.WriteLine("Item");
            for (int i = 0; i < this.Items.Count; i++)
            {
                Console.WriteLine(this.Items.ElementAt(i).Value.Name);
            }

            string ChosenItem = Console.ReadLine();

            for (int i = 0; i < this.Team.Count; i++)
            {
                Console.WriteLine(i + " " + this.Team[i].ToStringWithOutAttacks());
            }

            int ChosenPokemon = Convert.ToInt32(Console.ReadLine());
            this.Items[ChosenItem].activateEffectOfItem(this.Team[ChosenPokemon]);
            Console.WriteLine(this.Team[ChosenPokemon]);
        }

        public void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey)
        {
            Team[indexPokemon].PokeAttackHash[indexAttacke] = Generate.DictionaryOfAttacks[attackKey];
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
                        Console.WriteLine("Nummer " + (y + 1) + "   " + Team[y].ToStringWithOutAttacks());
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
            Items = Generate.DictionaryOfItems;

            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["pikatchu"]));
            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["evoli"]));
            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this.Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
        }
    }
}