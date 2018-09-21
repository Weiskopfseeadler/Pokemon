namespace poke.model
{
	public class Attack
	{

		private string _attackName;
		private string _attacktyp;
		private int _damage;

		public Attack()
		{

		}

		public Attack(string attackName, string attacktyp, int damage) : base()
		{
			this._attackName = attackName;
			this._attacktyp = attacktyp;
			this._damage = damage;
		}

		public Attack(Attack AttackFromNew)
		{
			this._attackName = AttackFromNew.AttackName;
			this._attacktyp = AttackFromNew.Attacktyp;
			this._damage = AttackFromNew.Damage;
		}
		

		public override string ToString()
		{
			return _attackName + "  " + _attacktyp + "  " + _damage;
		}

		public virtual string AttackName
		{
			get
			{
				return _attackName;
			}
			set
			{
				this._attackName = value;
			}
		}


		public virtual string Attacktyp
		{
			get
			{
				return _attacktyp;
			}
			set
			{
				this._attacktyp = value;
			}
		}


		public virtual int Damage
		{
			get
			{
				return _damage;
			}
			set
			{
				this._damage = value;
			}
		}



	}

}