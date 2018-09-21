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
        private  static Dictionary<string, Attack> _dictionaryOfAttacks = new Dictionary<string, Attack>();
        private static Dictionary<string, Pokemon> _dictionaryOfPokemons = new Dictionary<string, Pokemon>();
        

   

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

        public  static void Serialize()
        {
         
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(Generate._dictionaryOfPokemons,
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json",
                outputJSON + Environment.NewLine);
            
             outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(Generate._dictionaryOfAttacks,
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratAttack.json",
                outputJSON + Environment.NewLine);
        }

//Dies Funktion ist leider nicht verfügbar. Aus Zeitlichen Gründen Konte sie nicht Fertigestelt Werden
/*        public  void LoadPokemon()
        {
            dynamic o1 = JToken.Parse(File.ReadAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json"));
            var LoadedBag = o1;


            this._dictionaryOfPokemons.Clear();

            foreach (var item in o1)
            {
                Console.WriteLine("______________");
                string Key = item.Name;
                string Name = item.Value.PokemonName;
                string PokemonArt = item.Value.PokemonArt;
                int LivePoints = item.Value.LivePoints;
                int MaxLivePoints = item.Value.MaxLivePoints;
                string Typ1 = item.Value.Typ1;
                string Typ2 = item.Value.Typ2;
                int Initiative = item.Value.Initiative;
                int Strength = item.Value.Strength;
                int Defence = item.Value.Defence;

                this.DictionaryOfPokemons.Add(Key, new Pokemon(Name, PokemonArt, LivePoints, MaxLivePoints, Typ1, Typ2,
                    Initiative, Strength, Defence, new Attack(), new Attack(), new Attack(), new Attack()));
                for (int i = 0; i < item.Value.PokeAttackList.Count; i++)
                {
                    string AttackName1 = item.Value.Poke92AttackList[i].AttackName;
                    string Attacktyp1 = item.Value.PokeAttackList[i].Attacktyp;
                    int Damage1 = item.Value.PokeAttackList[i].Damage;
                    Attack A = new Attack(AttackName1, Attacktyp1, Damage1);
                    this.DictionaryOfPokemons[Key].PokeAttackList[i] = A;
                }
            }
        }*/

        //Dies Funktion ist leider nicht verfügbar. Aus Zeitlichen Gründen Konte sie nicht Fertigestelt Werden
        /*public  void LoadAttack()
        {
            dynamic o1 = JToken.Parse(File.ReadAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json"));
            var LoadedBag = o1;


            this._dictionaryOfAttacks.Clear();

            foreach (var item in o1)
            {
             

                    string key = item.Name;
                    string AttackName1 = item.Value.AttackName;
                    string Attacktyp1 = item.Value.Attacktyp;
                    int Damage1 = item.Value.Damage;
                    Attack A = new Attack(AttackName1, Attacktyp1, Damage1);
                this._dictionaryOfAttacks.Add(key,A);
                

            }
        }
*/

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

  
    }
}