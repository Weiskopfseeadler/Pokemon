using System.Collections.Generic;

namespace pokemon.savs
{
	public class Typ
	{
		//Diese Klasse Gehört nicht zum Projekt(Zukünftige Weiterentwiklung
		private string _Name;
		private List<string> _Typstrength = new List<string>();
		private List<string> _Typweaknes = new List<string>();




		public string Name
		{
			get => _Name;
			set => _Name = value;
		}

		public List<string> Typstrength
		{
			get => _Typstrength;
			set => _Typstrength = value;
		}

		public List<string> Typweaknes
		{
			get => _Typweaknes;
			set => _Typweaknes = value;
		}
	}
	
	

}