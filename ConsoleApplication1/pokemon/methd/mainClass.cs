using System;

namespace poke.methd
{

	using Teams = pokemon.savs.Teams;

	public class mainClass
	{



		/// 
		/// <param name="args"> </param>
		/// <exception cref="IOException"> </exception>
		public static void Main(string[] args)
		{
			// TODO Auto-generated method stub
			// Erstelt Attacken und POkemon Hash

			Teams teams = new Teams();
			teams.setTeams();

			teams.player[0].Name = "Fritz";

			teams.enemy[0].Name = "Hans";

			teams.changeAttack(0, 3, "vines");
			Console.WriteLine(teams.player[0]);
			teams.changePlayerPokemon(1, "evoli");

			teams = Battle.battlePhase(teams);
			Console.WriteLine("_______________");

		}

	}

}