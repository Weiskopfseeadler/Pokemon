using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using poke.model;

namespace pokemon.savs
{
    public class Generate
    {
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

        public static Dictionary<string, Attack> DictionaryOfAttacks { get; set; } = new Dictionary<string, Attack>();

        public static Dictionary<string, Pokemon> DictionaryOfPokemons { get; set; } =new Dictionary<string, Pokemon>();


        public static void GeneratAttack()
        {
            DictionaryOfAttacks[""] = new Attack("", "", 0);
            DictionaryOfAttacks["vines"] = new Attack("Vines", "plants", 200);
            DictionaryOfAttacks["scratch"] = new Attack("Scratch", "normal", 12);
            DictionaryOfAttacks["thunder"] = new Attack("Thunder", "electricity", 40);
            DictionaryOfAttacks["glow"] = new Attack("Glow", "fire", 25);
            DictionaryOfAttacks["spark"] = new Attack("Spark", "electricity", 10);
            DictionaryOfAttacks["flamethrower"] = new Attack("Flamethrower", "fire", 50);
            DictionaryOfAttacks["bubel"] = new Attack("Bubel", "water", 30);
            DictionaryOfAttacks["waterGun"] = new Attack("Water Gun", "water", 50);
            DictionaryOfAttacks["tackel"] = new Attack("Tackel", "normal", 10);
            DictionaryOfAttacks["petalDance"] = new Attack("Petal Dance", "plant", 40);
        }

        public static void GeneratPokemon()
        {
            DictionaryOfPokemons.Add("empty",
                new Pokemon("", "", 0, 0, "", "", 0, 0, 0, DictionaryOfAttacks[""], DictionaryOfAttacks[""],
                    DictionaryOfAttacks[""],
                    DictionaryOfAttacks[""]));

            DictionaryOfPokemons.Add("Psyduck", new Pokemon("Psyduck", "Psyduck", 10, 10, "water", "", 0, 0, 0,
                DictionaryOfAttacks["scratch"], DictionaryOfAttacks["waterGun"], DictionaryOfAttacks["bubel"],
                DictionaryOfAttacks["tackel"]));

            DictionaryOfPokemons.Add("Squirtle",
                new Pokemon("Squirtle", "Squirtle", 275, 275, "water", "", 5, 5, 30, DictionaryOfAttacks["bubel"],
                    DictionaryOfAttacks["tackel"],
                    DictionaryOfAttacks["scratch"], DictionaryOfAttacks["waterGun"]));


            DictionaryOfPokemons["pikatchu"] = new Pokemon("Pikatchu", "pikatchu", 200, 200, "electricity", "", 20, 20,
                5,
                DictionaryOfAttacks["spark"], DictionaryOfAttacks["thunder"], DictionaryOfAttacks["scratch"],
                DictionaryOfAttacks["vines"]);

            DictionaryOfPokemons.Add("charmander",
                new Pokemon("Charmander", "charmander", 225, 225, "fire", "", 5, 20, 10, DictionaryOfAttacks["glow"],
                    DictionaryOfAttacks["scratch"], DictionaryOfAttacks["flamethrower"],
                    DictionaryOfAttacks["flamethrower"]));

            DictionaryOfPokemons.Add("evoli", new Pokemon("evoli", "evoli", 150, 150, "normal", "", 20, 5, 10,
                DictionaryOfAttacks["scratch"], DictionaryOfAttacks["flamethrower"],
                DictionaryOfAttacks["flamethrower"],
                DictionaryOfAttacks["flamethrower"]));

            DictionaryOfPokemons.Add("Snivy",
                new Pokemon("Snivy", "snivy", 150, 150, "plants", "sds", 30, 10, 10,
                    DictionaryOfAttacks["vines"], DictionaryOfAttacks["tackel"], DictionaryOfAttacks["petalDance"],
                    DictionaryOfAttacks[""]));
        }

        //Nicht in Gebrauch und deshalb nicht im UML
        public static void Serialize()
        {
            var OutputJSON = JsonConvert.SerializeObject(DictionaryOfPokemons,
                Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratorPokemon.json",
                OutputJSON + Environment.NewLine);

            OutputJSON = JsonConvert.SerializeObject(DictionaryOfAttacks,
                Formatting.Indented);
            File.WriteAllText(
                @"C:\Users\vmadmin\RiderProjects\Pokemon\ConsoleApplication1\pokemon\SaveFiles\GeneratAttack.json",
                OutputJSON + Environment.NewLine);
        }
    }
}