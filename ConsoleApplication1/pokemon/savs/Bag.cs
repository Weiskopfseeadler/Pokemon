using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.poke.model;
using Newtonsoft.Json.Linq;
using poke.model;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using poke.model;
using Microsoft.CSharp;


namespace pokemon.savs
{
    public class Bag : TeamInterface
    {
        private int _activePokemon;
        private int mony;
        private List<Pokemon> _team = new List<Pokemon>();
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();


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
            _team[indexPokemon].PokeAttackList[indexAttacke] = Generate.DictionaryOfAttacks[attackKey];
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

        public void Serialize()
        {
            string outputJSON =
                Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\TeamSave.json",
                outputJSON + Environment.NewLine);
        }

        public void LoadBAg()
        {
            Serialize();
            dynamic o1 = JToken.Parse(File.ReadAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\TeamSave.json"));
            var LoadedBag = o1;

            foreach (var item in LoadedBag)
            {
                Console.WriteLine(item.Name);


                switch (item.Name)
                {
                    case "ActivePokemon":
                        Console.WriteLine(item.Name);
                        ActivePokemon = item.Value;
                        ;
                        break;
                    case "Team":
                        Console.WriteLine("________");
                        foreach (var item2 in item.Value)
                        {
                            Console.WriteLine("_________________");

                            

                            Console.WriteLine(item2.PokemonArt);
                            Console.WriteLine(item2.PokeAttackList[0].AttackName);
                            
                            string  name = item2.PokemonName;
                            string  PokemonArt = item2.PokemonArt;
                            int     LivePoints = item2.LivePoints;
                            int     MaxLivePoints = item2.MaxLivePoints;
                            string  Typ1 = item2.Typ1;
                            string  Typ2 = item2.Typ2;
                            int     Initiative = item2.Initiative;
                            int     Strength= item2.Strength;
                            int     Defence=item2.Defence;
                            string AttackName1 = item2.PokeAttackList[0].AttackName;
                            
                            Attack A1 = new Attack(item2.PokeAttackList[0].AttackName,item2.PokeAttackList[0].Attacktyp,item2.PokeAttackList[0].Damage);
                            Attack A2 = item2.PokeAttackList[1];
                            Attack A3 = item2.PokeAttackList[2];
                            Attack A4 = item2.PokeAttackList[3];
                            Team.Clear();
                            Team.Add(new Pokemon(name,PokemonArt,LivePoints,MaxLivePoints,Typ1,Typ2,Initiative,Strength,Defence,new Attack(A1), new Attack(A2),new Attack(A3),new Attack(A4)));

                            
                        }

                        Console.WriteLine();
                        break;
                    default:
                        ;
                        break;
                }
            }

            Console.WriteLine("________");
            foreach (var item2 in LoadedBag.Team)
            {
                Console.WriteLine("_________________");
                Console.WriteLine(item2.Name);
                //this._team.Add(new Pokemon(item2.Name,item2.PokemonAre,item2.LivePoints,item2.MaxLivePoints,)
            }

            /*int i = 0;
            foreach (var item2 in item)
            {
                foreach (var item3 in item2)
                {
                    string key = Convert.ToString(((IDictionary<string, JToken>) o1).Keys.ElementAt(i));
                    string name = item2.AttackName;
                    string typ = item2.Attacktyp;
                    int damage = item2.Damage;
                    _dictionaryOfAttacks.Add(key, new Attack(name, typ, damage));
                    Console.WriteLine(_dictionaryOfAttacks[key].ToString());
                }

                i++;
            }*/
        }
    }
}