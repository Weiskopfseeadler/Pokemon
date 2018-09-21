using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.poke.model;
using Newtonsoft.Json.Linq;
using poke.model;
using System.Runtime.InteropServices.ComTypes;
using ConsoleApplication1.pokemon.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using poke.model;
using Microsoft.CSharp;


namespace pokemon.savs
{
    public class Bag : TeamInterface
    {
        private int _activePokemon;
        private int _mony;
        private List<Pokemon> _team = new List<Pokemon>();
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();
        


        public bool CheckIsAktivePokemonKO()
        {
            bool CheckIsAktivePokemonKO = !(_team[_activePokemon].LivePoints > 0);

            return CheckIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool Death = true;
            for (int i = 0; i < 6; i++)
            {
                if (_team[i].LivePoints != 0)
                {
                    Death = false;
                }
            }

            return Death;
        }

        public void ChoseItem(Pokemon Enemy)
        {
            ListAllItem();

            string ChosenItem = Console.ReadLine();
            ListAllPokemon();
            int ChosenPokemon = Convert.ToInt32(Console.ReadLine());
            if (Enemy == null)
            {
                this._items[ChosenItem].ActivateEffectOfItem(this, ChosenPokemon,Enemy);
            }
            this._items[ChosenItem].ActivateEffectOfItem(this, ChosenPokemon, Enemy);
            Console.WriteLine(this._team[ChosenPokemon]);
        }

        public void ListAllItem()
        {
            Console.WriteLine("Item");
            for (int i = 0; i < this._items.Count; i++)
            {
                Console.WriteLine(this._items.ElementAt(i).Value.ToString());
            }
        }

        public void ListAllPokemon()
        {
            for (int i = 0; i < this._team.Count; i++)
            {
                Console.WriteLine(i + " " + this._team[i].ToStringWithOutAttacks());
            }
        }

        public void ChangeAttack(int IndexPokemon, int IndexAttacke, string attackKey)
        {
            _team[IndexPokemon].PokeAttackList[IndexAttacke] = Generate.DictionaryOfAttacks[attackKey];
        }

        public void ChangeAktivePokemon()
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

        public void SetDefault()
        {
            this._activePokemon = 0;
            

            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["pikatchu"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            this._team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
        }
        
        public void Serialize(Bag Bag)
        {
            string outputJSON =Newtonsoft.Json.JsonConvert.SerializeObject(Bag, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\BagSave.json",
                outputJSON + Environment.NewLine);
        }

        public void LoadBag()
        {
            dynamic o1 = JToken.Parse(File.ReadAllText(
            @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\BagSave.json"));
            var LoadedBag = o1;

            foreach (var Item in LoadedBag)
            {
                Console.WriteLine(Item.Name);
                switch (Item.Name)
                {
                    case "Money": 
                        Mony= Item.Value;break;
                    case "Items":
                        Items.Clear();
                        foreach (var Item2 in Item.Value)
                        {
                            string ItemName = Item2.Value.ItemName;
                            FunktionOfItem FunktionOfItem = Item2.Value.FunktionOfItem;
                            int ValueeOfEffekt = Item2.Value.ValueOfEffekt;
                            int ValueOfItem = Item2.Value.ValueOfItem;
                            int Price = Item2.Value.Price;
                            Items.Add(Item2.Name, new Item(ItemName, FunktionOfItem, ValueeOfEffekt, ValueOfItem,Price));
                        }
                        ;
                        break;
                    case "ActivePokemon":
                        ActivePokemon = Item.Value;
                        ;
                        break;
                    case "Team":
                        LoadTeam(Item);
                        ;
                        break;
                }
            }
        }

        private void LoadTeam(dynamic item)
        {
            int counter = 0;
            Team.Clear();
            foreach (var item2 in item.Value)
            {
                string name = item2.PokemonName;
                string PokemonArt = item2.PokemonArt;
                int LivePoints = item2.LivePoints;
                int MaxLivePoints = item2.MaxLivePoints;
                string Typ1 = item2.Typ1;
                string Typ2 = item2.Typ2;
                int Initiative = item2.Initiative;
                int Strength = item2.Strength;
                int Defence = item2.Defence;
                
                Team.Add(new Pokemon(name, PokemonArt, LivePoints, MaxLivePoints, Typ1, Typ2, Initiative,
                    Strength, Defence, new Attack(), new Attack(), new Attack(), new Attack()));
                for (int i = 0; i < item2.PokeAttackList.Count; i++)
                {
                    string AttackName1 = item2.PokeAttackList[i].AttackName;
                    string Attacktyp1 = item2.PokeAttackList[i].Attacktyp;
                    int Damage1 = item2.PokeAttackList[i].Damage;
                    Attack A = new Attack(AttackName1, Attacktyp1, Damage1);
                    Team[counter].PokeAttackList[i] = A;
                }

                counter++;
            }
        }

        public int Mony
        {
            get => _mony;
            set => _mony = value;
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