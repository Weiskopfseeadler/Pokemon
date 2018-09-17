using System;
using System.Collections.Generic;

namespace poke.model
{
    public class Pokemon
    {
      
        private string _name;
        private string _pokemonArt;
        private int _livePoints;
        private int _maxLivePoints;
        private string _typ1;
        private string _typ2;
        private int _initiative;
        private int _strength;

        private int _defence;

        // private int spezstrength; Nicht Umsetzen
        // private int spezdefence;  Nicht Umsetzen
        private List<Attack> _pokeAttackHash = new List<Attack>();

        public Pokemon()
        {
        }

        public Pokemon(string _name, string _pokemonArt, int _livePoints,int _maxLivePoints ,string _typ1, string _typ2, int _initiative,
            int _strength, int _defence, Attack a1, Attack a2, Attack a3, Attack a4) : base()
        {
            this._name = _name;
            this._pokemonArt = _pokemonArt;
            this._livePoints = _livePoints;
            this._maxLivePoints = _maxLivePoints;
            this._typ1 = _typ1;
            this._typ2 = _typ2;
            this._initiative = _initiative;
            this._strength = _strength;
            this._defence = _defence;
            this._pokeAttackHash.Add(a1);
            this._pokeAttackHash.Add(a2);
            this._pokeAttackHash.Add(a3);
            this._pokeAttackHash.Add(a4);
        }
        public Pokemon(Pokemon PokemonFromList)
        {
            this._name = PokemonFromList._name;
            this._pokemonArt = PokemonFromList._pokemonArt;
            this._livePoints = PokemonFromList._livePoints;
            this._maxLivePoints = PokemonFromList._maxLivePoints;
            this._typ1 = PokemonFromList._typ1;
            this._typ2 = PokemonFromList._typ2;
            this._initiative = PokemonFromList._initiative;
            this._strength = PokemonFromList._strength;
            this._defence = PokemonFromList._defence;
            this._pokeAttackHash.Add(new Attack(PokemonFromList._pokeAttackHash[0]));
            this._pokeAttackHash.Add(new Attack(PokemonFromList._pokeAttackHash[1]));
            this._pokeAttackHash.Add(new Attack(PokemonFromList._pokeAttackHash[2]));
            this._pokeAttackHash.Add(new Attack(PokemonFromList._pokeAttackHash[3]));
        }

   

        public virtual string PokeAttacksToString()
        {
            return "Attack 1: " + _pokeAttackHash[0] + " Attack 2: " + _pokeAttackHash[1] + "\nAttack 3: " +
            _pokeAttackHash[2] + "Attack 4: " + _pokeAttackHash[3];
        }

        public override string ToString()
        {
            return "name: " + _name + " PokemonArt: " + _pokemonArt + " LivePoints: " + _livePoints +" maxLivePoints: " + _maxLivePoints + " Typ1" + _typ1 +
                   " Typ2: " + _typ2 + " initiative: " + _initiative + " strength: " + _strength + " defence: " + _defence +
                   "\n" + PokeAttacksToString();
        }


        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int LivePoints
        {
            get => _livePoints;
            set
            {
                if (_livePoints+value > _maxLivePoints )
                {
                    _livePoints = _maxLivePoints;
                    Console.WriteLine("overLive");
                }else if (_livePoints+value<=0)
                {
                    _livePoints = 0;
                    Console.WriteLine("underLive");
                }
                else
                {
                    _livePoints =  value;
                    Console.WriteLine("normallive");
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
            get => _initiative;
            set => _initiative = value;
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }

        public int Defence
        {
            get => _defence;
            set => _defence = value;
        }

        public List<Attack> PokeAttackHash
        {
            get => _pokeAttackHash;
            set => _pokeAttackHash = value;
        }



    }
}