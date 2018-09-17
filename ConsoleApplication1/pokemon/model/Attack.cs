namespace poke.model
{
	public class Attack
	{

		private string attackName;
		private string attacktyp;
		private int damage;

		public Attack()
		{

		}

		public Attack(string attakName, string attacktyp, int damage) : base()
		{
			this.attackName = attakName;
			this.attacktyp = attacktyp;
			this.damage = damage;
		}

		public Attack(Attack AttackFromNew)
		{
			this.attackName = AttackFromNew.AttakName;
			this.attacktyp = AttackFromNew.Attacktyp;
			this.damage = AttackFromNew.Damage;
		}

		public override string ToString()
		{
			return attackName + "  " + attacktyp + "  " + damage;
		}

		public virtual string AttakName
		{
			get
			{
				return attackName;
			}
			set
			{
				this.attackName = value;
			}
		}


		public virtual string Attacktyp
		{
			get
			{
				return attacktyp;
			}
			set
			{
				this.attacktyp = value;
			}
		}


		public virtual int Damage
		{
			get
			{
				return damage;
			}
			set
			{
				this.damage = value;
			}
		}



	}

}