using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.poke.model;
using poke.model;

namespace pokemon.savs
{
    public class Bag : TeamInterface
    {
        private int _activePokemon;
        private List<Pokemon> _team  = new List<Pokemon>();
        private Dictionary<string ,Item> _items= new Dictionary<string, Item>();
        private int mony;


        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = !(_team[_activePokemon].LivePoints > 0);

            return checkIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool death = true;
            for (int i = 0; i < 6; i++)
            {
                if (_team[i].LivePoints != 0)
                {
                    death = false;
                }
            }

            return death;
        }
        public void ChoseItem()
        {
            Console.WriteLine("Item");
            for (int i = 0; i < this._items.Count; i++)
            {
                Console.WriteLine(this._items.ElementAt(i).Value.Name);
            }

            string ChosenItem = Console.ReadLine();

            for (int i = 0; i < this._team.Count; i++)
            {
                Console.WriteLine(i + " " + this._team[i].ToStringWithOutAttacks());
            }

            int ChosenPokemon = Convert.ToInt32(Console.ReadLine());
            this._items[ChosenItem].ActivateEffectOfItem(this._team[ChosenPokemon]);
            Console.WriteLine(this._team[ChosenPokemon]);
        }

        public void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey)
        {
            _team[indexPokemon].PokeAttackHash[indexAttacke] = Generate.DictionaryOfAttacks[attackKey];
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
                    if (_team[y].LivePoints > 0)
                    {
                        Console.WriteLine("Nummer " + (y + 1) + "   " + _team[y].ToStringWithOutAttacks());
                    }
                }

                index = Convert.ToInt32(Console.ReadLine());

                if (index > 0 && index <= 6)
                {
                    pokemonNotChosen = false;
                    index -= 1;
                    _activePokemon = index;
                }
            }
        }

        public void SetBag()
        {
            this._activePokemon = 0;
            _items = Generate.DictionaryOfItems;

            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["pikatchu"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["evoli"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
        }

        public int ActivePokemon
        {
            get => _activePokemon;
            set => _activePokemon = value;
        }

        public List<Pokemon> Team
        {
            get => _team;
            set => _team = value;
        }

        public Dictionary<string, Item> Items
        {
            get => _items;
            set => _items = value;
        }
    }
}