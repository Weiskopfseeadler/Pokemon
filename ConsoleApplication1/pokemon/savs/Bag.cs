using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.poke.model;
using ConsoleApplication1.pokemon.Interfaces;
using ConsoleApplication1.pokemon.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.pokemon.savs
{
    public class Bag : BagInterface
    {
       private int _Mony;

       private int _ActivePokemon; 

       private List<Pokemon> _Team = new List<Pokemon>();

       private Dictionary<string, Item> _Items  = new Dictionary<string, Item>();


        public bool CheckIsAktivePokemonKO()
        {
            var CheckIsAktivePokemonKo = !(Team[ActivePokemon].LivePoints > 0);

            return CheckIsAktivePokemonKo;
        }

        public bool CheckAreAllPokemonKO()
        {
            var Death = true;
            for (var I = 0; I < 6; I++)
                if (Team[I].LivePoints != 0)
                    Death = false;

            return Death;
        }

        public void ChoseItem(Pokemon Enemy)
        {
            ListAllItem();

            var ChosenItem = Console.ReadLine();
            ListAllPokemon();
            var ChosenPokemon = Convert.ToInt32(Console.ReadLine());
            
            Items[ChosenItem].ActivateEffectOfItem(this, ChosenPokemon, Enemy);
            Console.WriteLine(Team[ChosenPokemon]);
        }

        public void ListAllItem()
        {
            Console.WriteLine("Item");
            for (var I = 0; I < Items.Count; I++) Console.WriteLine(Items.ElementAt(I).Value.ToString());
        }

        public void ListAllPokemon()
        {
            for (var I = 0; I < Team.Count; I++) Console.WriteLine(I + " " + Team[I].ToStringWithOutAttacks());
        }

        public void ChangeAttack(int IndexPokemon, int IndexAttacke, string AttackKey)
        {
            Team[IndexPokemon].PokeAttackList[IndexAttacke] = Generate.DictionaryOfAttacks[AttackKey];
        }

        public void ChangeAktivePokemon()
        {
            var Index = 0;
            Console.WriteLine("player turn");


            var PokemonNotChosen = true;
            while (PokemonNotChosen)
            {
                Console.Write("Enter Integer 1-6:");
                Console.WriteLine("");

                for (var y = 0; y < 6; y++)
                    if (Team[y].LivePoints > 0)
                        Console.WriteLine("Nummer " + (y + 1) + "   " + Team[y].ToStringWithOutAttacks());
                Index = Convert.ToInt32(Console.ReadLine());
                if (Index > 0 && Index <= 6)
                {
                    PokemonNotChosen = false;
                    Index -= 1;
                    ActivePokemon = Index;
                }
            }
        }

        public void Serialize(Bag Bag)
        {
            var OutputJson = JsonConvert.SerializeObject(Bag, Formatting.Indented) ?? throw new ArgumentNullException("Bag");
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\BagSave.json",
                OutputJson + Environment.NewLine);
        }

        public void LoadBag()
        {
            dynamic ReadFile = JToken.Parse(File.ReadAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\BagSave.json"));
            var LoadedBag = ReadFile;

            foreach (var Item in LoadedBag)
            {
                Console.WriteLine(Item.Name);
                switch (Item.Name)
                {
                    case "Money":
                        Mony = Item.Value;
                        break;
                    case "Items":
                        Items.Clear();
                        foreach (var Item2 in Item.Value)
                        {
                            string ItemName = Item2.Value.ItemName;
                            FunktionOfItem FunktionOfItem = Item2.Value.FunktionOfItem;
                            int ValueeOfEffekt = Item2.Value.ValueOfEffekt;
                            int ValueOfItem = Item2.Value.ValueOfItem;
                            int Price = Item2.Value.Price;
                            Items.Add(Item2.Name,
                                new Item(ItemName, FunktionOfItem, ValueeOfEffekt, ValueOfItem, Price));
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

        public void LoadTeam(dynamic Item)
        {
            var Counter = 0;
            Team.Clear();
            foreach (var Item2 in Item.Value)
            {
                string Name = Item2.PokemonName;
                string PokemonArt = Item2.PokemonArt;
                int LivePoints = Item2.LivePoints;
                int MaxLivePoints = Item2.MaxLivePoints;
                string Typ1 = Item2.Typ1;
                string Typ2 = Item2.Typ2;
                int Initiative = Item2.Initiative;
                int Strength = Item2.Strength;
                int Defence = Item2.Defence;

                Team.Add(new Pokemon(Name, PokemonArt, LivePoints, MaxLivePoints, Typ1, Typ2, Initiative,
                    Strength, Defence, new Attack(), new Attack(), new Attack(), new Attack()));
                for (var i = 0; i < Item2.PokeAttackList.Count; i++)
                {
                    string AttackName1 = Item2.PokeAttackList[i].AttackName;
                    string Attacktyp1 = Item2.PokeAttackList[i].Attacktyp;
                    int Damage1 = Item2.PokeAttackList[i].Damage;
                    var A = new Attack(AttackName1, Attacktyp1, Damage1);
                    Team[Counter].PokeAttackList[i] = A;
                }

                Counter++;
            }
        }

        public void SetDefault()
        {
            ActivePokemon = 0;
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["pikatchu"]));
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
        }

        public int Mony
        {
            get => _Mony;
            set => _Mony = value;
        }

        public int ActivePokemon
        {
            get => _ActivePokemon;
            set => _ActivePokemon = value;
        }

        public List<Pokemon> Team
        {
            get => _Team;
            set => _Team = value;
        }

        public Dictionary<string, Item> Items
        {
            get => _Items;
            set => _Items = value;
        }
    }
}