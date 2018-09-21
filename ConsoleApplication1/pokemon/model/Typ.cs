using System.Collections.Generic;

namespace pokemon.savs
{
	public class Typ
	{
		//Diese Klasse Gehört nicht zum Projekt(Zukünftige Weiterentwiklung
		private string name;
		private List<string> typstrength = new List<string>();
		private List<string> typweaknes = new List<string>();




		public string Name
		{
			get => name;
			set => name = value;
		}

		public List<string> Typstrength
		{
			get => typstrength;
			set => typstrength = value;
		}

		public List<string> Typweaknes
		{
			get => typweaknes;
			set => typweaknes = value;
		}
	}
	
	

}