using System;
using System.Collections.Generic;
using System.Linq;
using poke.model;

namespace pokemon.savs
{
    public class TeamEnemy : TeamInterface
    {
        private int _activePokemon;
        private List<Pokemon> _team = new List<Pokemon>();
        private Random Random = new Random();
        

        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = !(_team[_activePokemon].LivePoints > 0);

            return checkIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool death = true;
            for (int i = 0; i < Team.Count; i++)
            {
                if (_team[i].LivePoints != 0)
                {
                    death = false;
                }
            }

            return death;
        }

        public void ChangeAttack(int IndexPokemon, int IndexAttacke, string attackKey)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeAktivePokemon()
        {
            Console.WriteLine("enemy ChangeshPokemon");
            bool pokemonNotChosen = true;
            while (pokemonNotChosen)
            {
                int randomNumber = Random.Next(0, 5);

                if (_team[randomNumber].LivePoints != 0)
                {
                    pokemonNotChosen = false;
                    _activePokemon = randomNumber;
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
            _team.Clear();
            for (int i = 0; i <= 5; i++)
            {
                if (RadomNumber<6)
                {
                    int rand = Random.Next(1, Generate.DictionaryOfPokemons.Count);
                    Console.WriteLine(Generate.DictionaryOfPokemons.Count);
                    Console.WriteLine(rand);
                
                    _team.Add(new Pokemon(Generate.DictionaryOfPokemons.ElementAt(rand).Value));
                    Console.WriteLine(_team[i].ToString());
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
            get => _activePokemon;
            set => _activePokemon = value;
        }

        public List<Pokemon> Team
        {
            get => _team;
            set => _team = value;
        }
    }
}