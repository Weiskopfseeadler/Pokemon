using System.Collections.Generic;

namespace pokemon.savs
{
	using Attack = poke.model.Attack;
	using Pokemon = poke.model.Pokemon;

	public class Teams
	{
		private List<Pokemon> player = new List<Pokemon>();
		private static int aPP;
		private List<Pokemon> enemy = new List<Pokemon>();
		private static int aEP;
		private Generate generator = new Generate();

		public virtual void setTeams()
		{

				

				aPP = 0;
				aEP = 0;

				
				player.Add(generator._pokemonHash["pikatchu"]);
				player.Add(generator._pokemonHash["evoli"]);
				player.Add(generator._pokemonHash["empty"]);
				player.Add(generator._pokemonHash["empty"]);
				player.Add(generator._pokemonHash["empty"]);
				player.Add(generator._pokemonHash["empty"]);

				enemy.Add(generator._pokemonHash["charmander"]);
				enemy.Add(generator._pokemonHash["evoli"]);
				enemy.Add(generator._pokemonHash["empty"]);
				enemy.Add(generator._pokemonHash["empty"]);
				enemy.Add(generator._pokemonHash["empty"]);
				enemy.Add(generator._pokemonHash["empty"]);
		}

		public  void changeAttack(int indexPokemon, int indexAttacke, string attackKey)
		{
			player[indexPokemon].PokeAttackHash[indexAttacke] = generator._attackHash[attackKey];

		}
		public  void changePlayerPokemon(int index, string pokemonKey)
		{
			player[index] = generator._pokemonHash[pokemonKey];
		}
		public  void changeEnemyPokemon(int index, string pokemonKey)
		{
			enemy[index] = generator._pokemonHash[pokemonKey];
		}


		public List<Pokemon> Player
		{
			get => player;
			set => player = value;
		}

		public List<Pokemon> Enemy
		{
			get => enemy;
			set => enemy = value;
		}

		public static  int APp
		{
			get => aPP;
			set => aPP = value;
		}

		public static int AEp
		{
			get => aEP;
			set => aEP = value;
		}
	}

}