using System;
using System.Collections.Generic;

namespace poke.model
{
    public class Pokemon
    {
        private string _PokemoName;
        private string _PokemonArt;
        private int _LivePoints;
        private int _maxLivePoints;
        private string _typ1;
        private string _typ2;
        private int _Initiative;
        private int _Strength;
        private int _Defence;
        private List<Attack> _PokeAttackList = new List<Attack>();

        public Pokemon()
        {
        }

        public Pokemon(string PokemoName, string PokemonArt, int LivePoints, int MaxLivePoints, string Typ1,
            string Typ2, int Initiative,
            int Strength, int Defence, Attack A1, Attack A2, Attack A3, Attack A4) 
        {
            this._PokemoName = PokemoName;
            this._PokemonArt = PokemonArt;
            this._LivePoints = LivePoints;
            this._maxLivePoints = MaxLivePoints;
            this._typ1 = Typ1;
            this._typ2 = Typ2;
            this._Initiative = Initiative;
            this._Strength = Strength;
            this._Defence = Defence;
            this._PokeAttackList.Add(A1);
            this._PokeAttackList.Add(A2);
            this._PokeAttackList.Add(A3);
            this._PokeAttackList.Add(A4);
        }

        public Pokemon(Pokemon PokemonFromList)
        {
            this._PokemoName = PokemonFromList._PokemoName;
            this._PokemonArt = PokemonFromList._PokemonArt;
            this._LivePoints = PokemonFromList._LivePoints;
            this._maxLivePoints = PokemonFromList._maxLivePoints;
            this._typ1 = PokemonFromList._typ1;
            this._typ2 = PokemonFromList._typ2;
            this._Initiative = PokemonFromList._Initiative;
            this._Strength = PokemonFromList._Strength;
            this._Defence = PokemonFromList._Defence;
            this._PokeAttackList.Add(new Attack(PokemonFromList._PokeAttackList[0]));
            this._PokeAttackList.Add(new Attack(PokemonFromList._PokeAttackList[1]));
            this._PokeAttackList.Add(new Attack(PokemonFromList._PokeAttackList[2]));
            this._PokeAttackList.Add(new Attack(PokemonFromList._PokeAttackList[3]));
        }


        public virtual string PokeAttacksToString()
        {
            return "Attack 1: " + _PokeAttackList[0] + " Attack 2: " + _PokeAttackList[1] + "\nAttack 3: " +
                   _PokeAttackList[2] + "Attack 4: " + _PokeAttackList[3];
        }

        public override string ToString()
        {
            return "name: " + _PokemoName + " PokemonArt: " + _PokemonArt + " LivePoints: " + _LivePoints +
                   " maxLivePoints: " + _maxLivePoints + " Typ1" + _typ1 +
                   " Typ2: " + _typ2 + " initiative: " + _Initiative + " strength: " + _Strength + " defence: " +
                   _Defence +
                   "\n" + PokeAttacksToString();
        }

        public string ToStringWithOutAttacks()
        {
            return "name: " + _PokemoName + " PokemonArt: " + _PokemonArt + " LivePoints: " + _LivePoints +
                   " maxLivePoints: " + _maxLivePoints + " Typ1" + _typ1 +
                   " Typ2: " + _typ2 + " initiative: " + _Initiative + " strength: " + _Strength + " defence: " +
                   _Defence;
        }


        public string PokemonName
        {
            get => _PokemoName;
            set => _PokemoName = value;
        }

        public string PokemonArt
        {
            get => _PokemonArt;
           
        }

        public int LivePoints
        {
            get => _LivePoints;
            set
            {
                if (value > _maxLivePoints)
                {
                    _LivePoints = _maxLivePoints;
                }
                else if (value <= 0)
                {
                    _LivePoints = 0;
                }
                else
                {
                    _LivePoints = value;
                }
            }
        }

        public int MaxLivePoints
        {
            get => _maxLivePoints;
            set => _maxLivePoints = value;
        }

        public string Typ1
        {
            get => _typ1;
        }

        public string Typ2
        {
            get => _typ2;
        }

        public int Initiative
        {
            get => _Initiative;
            set => _Initiative = value;
        }

        public int Strength
        {
            get => _Strength;
            set => _Strength = value;
        }

        public int Defence
        {
            get => _Defence;
            set => _Defence = value;
        }

        public List<Attack> PokeAttackList
        {
            get => _PokeAttackList;
            set => _PokeAttackList = value;
        }
    }
}