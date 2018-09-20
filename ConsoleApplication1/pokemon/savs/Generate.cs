using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication1.poke.model;
using ConsoleApplication1.pokemon.model;
using Newtonsoft.Json.Linq;

namespace pokemon.savs
{
    using Attack = poke.model.Attack;
    using Pokemon = poke.model.Pokemon;

    public class Generate
    {
        private static Dictionary<string, Attack> _dictionaryOfAttacks = new Dictionary<string, Attack>();

        private static Dictionary<string, Pokemon> _dictionaryOfPokemons = new Dictionary<string, Pokemon>();

        private static Dictionary<string, Item> _dictionaryOfItems = new Dictionary<string, Item>();


        public static void GeneratAttack()
        {
            _dictionaryOfAttacks[""] = new Attack("", "", 0);
            _dictionaryOfAttacks["vines"] = new Attack("Vines", "plants", 200);
            _dictionaryOfAttacks["scratch"] = new Attack("Scratch", "normal", 12);
            _dictionaryOfAttacks["thunder"] = new Attack("Thunder", "electricity", 40);
            _dictionaryOfAttacks["glow"] = new Attack("Glow", "fire", 25);
            _dictionaryOfAttacks["spark"] = new Attack("Spark", "electricity", 10);
            _dictionaryOfAttacks["flamethrower"] = new Attack("Flamethrower", "fire", 50);
            _dictionaryOfAttacks["bubel"] = new Attack("Bubel", "water", 30);
            _dictionaryOfAttacks["waterGun"] = new Attack("Water Gun", "water", 50);
            _dictionaryOfAttacks["tackel"] = new Attack("Tackel", "normal", 10);
            _dictionaryOfAttacks["petalDance"] = new Attack("Petal Dance", "plant", 40);
        }

        public static void GeneratPokemon()
        {
            DictionaryOfPokemons.Add("empty",
                new Pokemon("", "", 0, 0, "", "", 0, 0, 0, _dictionaryOfAttacks[""], _dictionaryOfAttacks[""],
                    _dictionaryOfAttacks[""],
                    _dictionaryOfAttacks[""]));

            DictionaryOfPokemons.Add("Psyduck", new Pokemon("Psyduck", "Psyduck", 10, 10, "water", "", 0, 0, 0,
                _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["waterGun"], _dictionaryOfAttacks["bubel"],
                _dictionaryOfAttacks["tackel"]));

            DictionaryOfPokemons.Add("Squirtle",
                new Pokemon("Squirtle", "Squirtle", 275, 275, "water", "", 5, 5, 30, _dictionaryOfAttacks["bubel"],
                    _dictionaryOfAttacks["tackel"],
                    _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["waterGun"]));


            DictionaryOfPokemons["pikatchu"] = new Pokemon("Pikatchu", "pikatchu", 200, 200, "electricity", "", 20, 20,
                5,
                _dictionaryOfAttacks["spark"], _dictionaryOfAttacks["thunder"], _dictionaryOfAttacks["scratch"],
                _dictionaryOfAttacks["vines"]);

            _dictionaryOfPokemons.Add("charmander",
                new Pokemon("Charmander", "charmander", 225, 225, "fire", "", 5, 20, 10, _dictionaryOfAttacks["glow"],
                    _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["flamethrower"],
                    _dictionaryOfAttacks["flamethrower"]));

            _dictionaryOfPokemons.Add("evoli", new Pokemon("evoli", "evoli", 150, 150, "normal", "", 20, 5, 10,
                _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["flamethrower"],
                _dictionaryOfAttacks["flamethrower"],
                _dictionaryOfAttacks["flamethrower"]));

            _dictionaryOfPokemons.Add("Snivy",
                new Pokemon("Snivy", "snivy", 150, 150, "plants", "sds", 30, 10, 10,
                    _dictionaryOfAttacks["vines"], _dictionaryOfAttacks["tackel"], _dictionaryOfAttacks["petalDance"],
                    _dictionaryOfAttacks[""]));
        }
        public static void Serialize( )
        {
            string outputJSON =Newtonsoft.Json.JsonConvert.SerializeObject(Generate._dictionaryOfPokemons, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json",
                outputJSON + Environment.NewLine);
        }


        public static void LoadGeneratorPokemon()
        {
            dynamic o1 = JToken.Parse(File.ReadAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json"));
            var LoadedBag = o1;

            Console.WriteLine(o1);

            //_dictionaryOfPokemons.Clear();

            foreach (var item in o1)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Name);
                Console.WriteLine("______________");
                Console.WriteLine(item.Value);
                /*string Key = item.Name;
                string Name = item.PokemonName;
                string PokemonArt = item.PokemonArt;
                int LivePoints = item.LivePoints;
                int MaxLivePoints = item.MaxLivePoints;
                string Typ1 = item.Typ1;
                string Typ2 = item.Typ2;
                int Initiative = item.Initiative;
                int Strength = item.Strength;
                int Defence = item.Defence;
                
                _dictionaryOfPokemons.Add(Key,new Pokemon(Name, PokemonArt, LivePoints, MaxLivePoints, Typ1, Typ2, Initiative,
                    Strength, Defence, new Attack(), new Attack(), new Attack(), new Attack()));
                for (int i = 0; i < item.PokeAttackList.Count; i++)
                {
                    string AttackName1 = item.PokeAttackList[i].AttackName;
                    string Attacktyp1 = item.PokeAttackList[i].Attacktyp;
                    int Damage1 = item.PokeAttackList[i].Damage;
                    Attack A = new Attack(AttackName1, Attacktyp1, Damage1);
                    _dictionaryOfPokemons[Key].PokeAttackList[i] = A;
                }
*/



                //}
            }
        }



        public static Dictionary<string, Attack> DictionaryOfAttacks
        {
            get => _dictionaryOfAttacks;
            set => _dictionaryOfAttacks = value;
        }

        public static Dictionary<string, Pokemon> DictionaryOfPokemons
        {
            get => _dictionaryOfPokemons;
            set => _dictionaryOfPokemons = value;
        }

        public static Dictionary<string, Item> DictionaryOfItems
        {
            get => _dictionaryOfItems;
            set => _dictionaryOfItems = value;
        }
    }
}