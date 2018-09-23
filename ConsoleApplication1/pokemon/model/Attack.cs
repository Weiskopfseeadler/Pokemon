namespace poke.model
{
	public class Attack
	{

		private string _AttackName;
		private string _Attacktyp;
		private int _Damage;

		public Attack()
		{

		}

		public Attack(string AttackName, string Attacktyp, int Damage) : base()
		{
			this._AttackName = AttackName;
			this._Attacktyp = Attacktyp;
			this._Damage = Damage;
		}

		public Attack(Attack AttackFromNew)
		{
			this._AttackName = AttackFromNew.AttackName;
			this._Attacktyp = AttackFromNew.Attacktyp;
			this._Damage = AttackFromNew.Damage;
		}
		

		public override string ToString()
		{
			return _AttackName + "  " + _Attacktyp + "  " + _Damage;
		}

		public virtual string AttackName
		{
			get
			{
				return _AttackName;
			}
			set
			{
				this._AttackName = value;
			}
		}


		public  string Attacktyp
		{
			get
			{
				return _Attacktyp;
			}
			set
			{
				this._Attacktyp = value;
			}
		}


		public  int Damage
		{
			get
			{
				return _Damage;
			}
			set
			{
				this._Damage = value;
			}
		}



	}

}