using System;
using System.CodeDom.Compiler;
using poke.model;
using pokemon.savs;

namespace poke.methd
{
    

    public class Battle
    {
        private TeamEnemy _enemy;
        private TeamPlayer _player;
        private bool _isBattelTime;
        private bool _isSingelPokemon;

        public void Menu()
        {
            _isBattelTime = true;
            while (_isBattelTime)
            {
                int ChosenAttack = 0;
                Console.WriteLine(" Battle \n Pokemon \n Items\n Flucht");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        ChoseAttack();
                        break;
                    case 2:
                    default:
                        ;
                        break;
                }

                BattlePhase(ChosenAttack);

                Console.WriteLine(_player.ToString());
                if (_player.CheckIsAktivePokemonKO())
                {
                    if (_player.CheckAreAllPokemonKO())
                    {
                        _isBattelTime = false;
                    }
                    else
                    {
                        _player.CangeAktivePokemon();
                    }
                }

                if (_enemy.CheckIsAktivePokemonKO())
                {
                    if (_player.CheckAreAllPokemonKO())
                    {
                        _isBattelTime = false;
                    }
                    else
                    {
                        _enemy.CangeAktivePokemon();
                    }
                }
            }
        }


        private void BattlePhase(int ChosenAttack)
        {

            if (ChosenAttack != 0)
            {
                ChosenAttack -= 1;
                if (_player.Team[_player.ActivePokemon].Initiative >= Enemy.Team[Enemy.ActivePokemon].Initiative)
                {
                    turnPlayer(ChosenAttack);
                    if (!Enemy.CheckIsAktivePokemonKO())
                    {
                        turnEnemy();
                    }
                }
                else
                {
                    turnEnemy();
                    if (!Player.CheckIsAktivePokemonKO())
                    {
                        turnPlayer(ChosenAttack);
                    }
                }
            }
            else
            {
                turnEnemy();
            }
        }


        private int ChoseAttack()
        {
            int index = 0;


            Console.WriteLine("player turn");
            Console.WriteLine(Player.Team[Player.ActivePokemon].PokeAttacksToString());

            for (bool IndexCorrect = false; IndexCorrect == false;)
            {
                Console.Write("Enter Integer 1-4:");
                Console.WriteLine("");

                index = Convert.ToInt32(Console.ReadLine());

                if (index > 0 && index <= 4)
                {
                    IndexCorrect = true;
                }
               
            }

            return index;
        }


        private void turnPlayer(int ChosenAttack)
        {
            Console.WriteLine(Player.Team[Player.ActivePokemon].PokeAttackHash[ChosenAttack]);

            DamageCalculation(
                Player.Team[Player.ActivePokemon],
                Player.Team[Player.ActivePokemon].PokeAttackHash[ChosenAttack],
                Enemy.Team[Enemy.ActivePokemon]
            );
            Console.WriteLine(Player.Team[Player.ActivePokemon]);


            Console.WriteLine(Enemy.Team[Enemy.ActivePokemon].LivePoints);

            Console.WriteLine("_______________");
        }


        private void turnEnemy()
        {
            Console.WriteLine("enamy turn");
            Random random = new Random();
            int randomNumber = random.Next(0, 3);

            Console.WriteLine(randomNumber);
            Console.WriteLine(Enemy.Team[Enemy.ActivePokemon].PokeAttackHash[randomNumber]);

            DamageCalculation(
                Enemy.Team[Enemy.ActivePokemon],
                Enemy.Team[Enemy.ActivePokemon].PokeAttackHash[randomNumber],
                Player.Team[Player.ActivePokemon]
            );
            Console.WriteLine(Player.Team[Player.ActivePokemon].LivePoints);
        }


        private void DamageCalculation(Pokemon attacking, Attack attack, Pokemon defending)
        {
            double BonusDamage;
            int takenDamage = attack.Damage;
            BonusDamage = takenDamage * ((double) attacking.Strength / 100);
            takenDamage = (int) Math.Round(+BonusDamage);
            BonusDamage = takenDamage * ((double) defending.Defence / 100);
            takenDamage = (int) Math.Round(-BonusDamage);
            if (defending.LivePoints - takenDamage < 1)
            {
                defending.LivePoints = 0;
            }
            else
            {
                Console.WriteLine(BonusDamage);
                Console.WriteLine(attack.Damage);
                defending.LivePoints = -(takenDamage);
            }

            Console.WriteLine(defending.LivePoints);
        }

        public TeamEnemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public TeamPlayer Player
        {
            get => _player;
            set => _player = value;
        }

        public bool IsBattelTime
        {
            get => _isBattelTime;
            set => _isBattelTime = value;
        }

        public bool IsSingelPokemon
        {
            get => _isSingelPokemon;
            set => _isSingelPokemon = value;
        }
    }
}