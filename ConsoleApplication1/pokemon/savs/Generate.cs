using System.Collections.Generic;

namespace pokemon.savs
{
    using Attack = poke.model.Attack;
    using Pokemon = poke.model.Pokemon;

    public class Generate
    {
        private static Dictionary<string, Attack> _attackHash = new Dictionary<string, Attack>();

        private static Dictionary<string, Pokemon> _pokemonHash = new Dictionary<string, Pokemon>();

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

        public static void GeneratAttack()
        {
            _attackHash[""] = new Attack("", "", 0);
            _attackHash["vines"] = new Attack("Vines", "plants", 200);
            _attackHash["scratch"] = new Attack("Scratch", "normal", 12);
            _attackHash["thunder"] = new Attack("thunder", "electricity", 40);
            _attackHash["glow"] = new Attack("Glow", "fire", 25);
            _attackHash["spark"] = new Attack("Spark", "electricity", 10);
            _attackHash["flamethrower"] = new Attack("Flamethrower", "fire", 50);
        }

        public static void GeneratPokemon()
        {
            PokemonHash.Add("Psyduck", new Pokemon("Psyduck", "Psyduck", 10, 10, "water", "", 0, 0, 0,
                _attackHash["scratch"], _attackHash["flamethrower"], _attackHash["flamethrower"],
                _attackHash["flamethrower"]));

            PokemonHash.Add("Squirtle",
                new Pokemon("Squirtle", "Squirtle", 275, 275, "water", "", 5, 5, 30, _attackHash[""], _attackHash[""],
                    _attackHash[""], _attackHash[""]));

            PokemonHash.Add("empty",
                new Pokemon("", "", 0, 0, "", "", 0, 0, 0, _attackHash[""], _attackHash[""], _attackHash[""],
                    _attackHash[""]));

            PokemonHash["pikatchu"] = new Pokemon("Pikatchu", "pikatchu", 200, 200, "electricity", "", 20, 20, 5,
                _attackHash["spark"], _attackHash["thunder"], _attackHash["scratch"], _attackHash["glow"]);

            _pokemonHash.Add("charmander",
                new Pokemon("Charmander", "charmander", 225, 225, "fire", "", 5, 20, 10, _attackHash["glow"],
                    _attackHash["scratch"], _attackHash["flamethrower"], _attackHash["flamethrower"]));

            _pokemonHash.Add("evoli", new Pokemon("evoli", "evoli", 150, 150, "normal", "", 20, 5, 10,
                _attackHash["scratch"], _attackHash["flamethrower"], _attackHash["flamethrower"],
                _attackHash["flamethrower"]));

            _pokemonHash.Add("Snivy",
                new Pokemon("Snivy", "snivy", 150, 150, "plants", "sds", 30, 10, 10, null, null, null, null));
        }

        public static Dictionary<string, Attack> AttackHash
        {
            get => _attackHash;
            set => _attackHash = value;
        }

        public static Dictionary<string, Pokemon> PokemonHash
        {
            get => _pokemonHash;
            set => _pokemonHash = value;
        }
    }
}