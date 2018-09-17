using System.Collections.Generic;
using ConsoleApplication1.poke.model;
using ConsoleApplication1.pokemon.model;

namespace pokemon.savs
{
    using Attack = poke.model.Attack;
    using Pokemon = poke.model.Pokemon;

    public class Generate
    {
        private static Dictionary<string, Attack> _dictionaryOfAttacks = new Dictionary<string, Attack>();

        private static Dictionary<string, Pokemon> _dictionaryOfPokemons = new Dictionary<string, Pokemon>();
        
        private static Dictionary<string,Item> _dictionaryOfItems = new Dictionary<string, Item>();

        //private Dictionary<string, Typ> _typsDictionary= new Dictionary<string, Typ>();
        /*
		public void generatTyps()
		{
			_typsDictionary["fire"] = new Typ();
			_typsDictionary["fire"].Name = "Fire";
			_typsDictionary["fire"].Typstrength.Add("plants");
			_typsDictionary["fire"].Typstrength.Add("Ice");
			_typsDictionary["fire"].Typstrength.Add("");
			_typsDictionary["fire"].Typstrength.Add("");
			_typsDictionary["fire"].Typweaknes.Add("water");
			_typsDictionary["fire"].Typweaknes.Add("");
		}
		*/

        public static void GeneratItems()
        {
            _dictionaryOfItems.Add("SmallHealPotion",new Item("SmallHealPotion",FunktionOfItem.Heal,50,10));
            _dictionaryOfItems.Add("SmallHeath");
        }
        

        public static void GeneratAttack()
        {
            _dictionaryOfAttacks[""] = new Attack("", "", 0);
            _dictionaryOfAttacks["vines"] = new Attack("Vines", "plants", 200);
            _dictionaryOfAttacks["scratch"] = new Attack("Scratch", "normal", 12);
            _dictionaryOfAttacks["thunder"] = new Attack("thunder", "electricity", 40);
            _dictionaryOfAttacks["glow"] = new Attack("Glow", "fire", 25);
            _dictionaryOfAttacks["spark"] = new Attack("Spark", "electricity", 10);
            _dictionaryOfAttacks["flamethrower"] = new Attack("Flamethrower", "fire", 50);
        }

        public static void GeneratPokemon()
        {
            PokemonHash.Add("Psyduck", new Pokemon("Psyduck", "Psyduck", 10, 10, "water", "", 0, 0, 0,
                _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["flamethrower"], _dictionaryOfAttacks["flamethrower"],
                _dictionaryOfAttacks["flamethrower"]));

            PokemonHash.Add("Squirtle",
                new Pokemon("Squirtle", "Squirtle", 275, 275, "water", "", 5, 5, 30, _dictionaryOfAttacks[""], _dictionaryOfAttacks[""],
                    _dictionaryOfAttacks[""], _dictionaryOfAttacks[""]));

            PokemonHash.Add("empty",
                new Pokemon("", "", 0, 0, "", "", 0, 0, 0, _dictionaryOfAttacks[""], _dictionaryOfAttacks[""], _dictionaryOfAttacks[""],
                    _dictionaryOfAttacks[""]));

            PokemonHash["pikatchu"] = new Pokemon("Pikatchu", "pikatchu", 200, 200, "electricity", "", 20, 20, 5,
                _dictionaryOfAttacks["spark"], _dictionaryOfAttacks["thunder"], _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["glow"]);

            _dictionaryOfPokemons.Add("charmander",
                new Pokemon("Charmander", "charmander", 225, 225, "fire", "", 5, 20, 10, _dictionaryOfAttacks["glow"],
                    _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["flamethrower"], _dictionaryOfAttacks["flamethrower"]));

            _dictionaryOfPokemons.Add("evoli", new Pokemon("evoli", "evoli", 150, 150, "normal", "", 20, 5, 10,
                _dictionaryOfAttacks["scratch"], _dictionaryOfAttacks["flamethrower"], _dictionaryOfAttacks["flamethrower"],
                _dictionaryOfAttacks["flamethrower"]));

            _dictionaryOfPokemons.Add("Snivy",
                new Pokemon("Snivy", "snivy", 150, 150, "plants", "sds", 30, 10, 10, null, null, null, null));
        }

        public static Dictionary<string, Attack> AttackHash
        {
            get => _dictionaryOfAttacks;
            set => _dictionaryOfAttacks = value;
        }

        public static Dictionary<string, Pokemon> PokemonHash
        {
            get => _dictionaryOfPokemons;
            set => _dictionaryOfPokemons = value;
        }
    }
}