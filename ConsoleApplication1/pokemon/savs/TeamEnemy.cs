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
        public Random Random = new Random();

        public bool CheckIsAktivePokemonKO()
        {
            bool checkIsAktivePokemonKO = !(_team[_activePokemon].LivePoints > 0);

            return checkIsAktivePokemonKO;
        }

        public bool CheckAreAllPokemonKO()
        {
            bool death = true;
            for (int i = 0; i < 6; i++)
            {
                if (_team[i].LivePoints != 0)
                {
                    death = false;
                }
            }

            return death;
        }

        public void ChangeAttack(int indexPokemon, int indexAttacke, string attackKey)
        {
            throw new System.NotImplementedException();
        }

        public void CangeAktivePokemon()
        {
            Console.WriteLine("enemy ChangescPokemon");
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

        public void SetBag()
        {
            this._activePokemon = 0;

            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["charmander"]));
            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["evoli"]));
            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
            _team.Add(new Pokemon(Generate.DictionaryOfPokemons["empty"]));
        }

        public void RandomEnemy(bool IsSingelPokemon)
        {
            int RadomNumber = Random.Next(0, 5);
            if (IsSingelPokemon)
            {
                RadomNumber = 0;
            }
            else
            {
                RadomNumber = 0;
            }

            for (int i = 0; i <= RadomNumber; i++)
            {
                _team[i] = Generate.DictionaryOfPokemons.ElementAt(Random.Next(0, Generate.DictionaryOfAttacks.Count))
                    .Value;
                Console.WriteLine(_team[i].ToString());
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