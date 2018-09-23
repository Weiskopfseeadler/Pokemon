using System;
using System.Collections.Generic;
using System.Linq;
using poke.model;

namespace pokemon.savs
{
    public class TeamEnemy : TeamInterface
    {
        private int _ActivePokemon;
        private List<Pokemon> _Team = new List<Pokemon>();
        private Random Random = new Random();
        

        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = !(_Team[_ActivePokemon].LivePoints > 0);

            return checkIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool death = true;
            for (int i = 0; i < Team.Count; i++)
            {
                if (_Team[i].LivePoints != 0)
                {
                    death = false;
                }
            }

            return death;
        }

        public void ChangeAttack(int IndexPokemon, int IndexAttacke, string AttackKey)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeAktivePokemon()
        {
            Console.WriteLine("enemy ChangeshPokemon");
            bool PokemonNotChosen = true;
            while (PokemonNotChosen)
            {
                int RandomNumber = Random.Next(0, 5);

                if (_Team[RandomNumber].LivePoints != 0)
                {
                    PokemonNotChosen = false;
                    _ActivePokemon = RandomNumber;
                }
            }
        }


        public void RandomEnemy(bool IsSingelPokemon)
        {
            int RadomNumber = Random.Next(0, 5);

            if (IsSingelPokemon)
            {
                RadomNumber = 0;
            }
            _Team.Clear();
            for (int i = 0; i <= 5; i++)
            {
                if (RadomNumber<6)
                {
                    int Rand = Random.Next(1, Generate.DictionaryOfPokemons.Count);
                    Console.WriteLine(Generate.DictionaryOfPokemons.Count);
                    Console.WriteLine(Rand);
                
                    _Team.Add(new Pokemon(Generate.DictionaryOfPokemons.ElementAt(Rand).Value));
                    Console.WriteLine(_Team[i].ToString());
                }
                else
                {
                 Team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));   
                }

                RadomNumber++;
            }
        }


        public int ActivePokemon
        {
            get => _ActivePokemon;
            set => _ActivePokemon = value;
        }

        public List<Pokemon> Team
        {
            get => _Team;
            set => _Team = value;
        }
    }
}