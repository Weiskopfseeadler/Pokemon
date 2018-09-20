using System;
using System.CodeDom.Compiler;
using System.Linq;
using ConsoleApplication1.poke.model;
using poke.model;
using pokemon.savs;

namespace poke.methd
{
    public class Battle
    {
        private TeamEnemy _enemy = new TeamEnemy();
        private Bag _bag = new Bag();

        private bool _isBattelTime;
        private static bool _isSingelPokemon;

        public void BattelMenu()
        {
            _isBattelTime = true;
            while (_isBattelTime)
            {
                int ChosenAttack = 0;
                Console.WriteLine(" Battle \n Pokemon \n Items");
                CheckStatus();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        ChosenAttack = ChoseAttack();
                        break;
                    case 2:
                        Bag.CangeAktivePokemon();
                        break;
                    case 3:
                        if (_isSingelPokemon)
                        {
                            Bag.ChoseItem(Enemy.Team[0]);
                        }
                        else
                        {
                            Bag.ChoseItem(null);
                        }
                        
                        break;
                }

                BattlePhase(ChosenAttack);
                CheckStatus();
            }
            Random Rand = new Random();
           int mingain = 100*Enemy.Team.Count;
            int maxgain = 500 * Enemy.Team.Count;
            Bag.Mony = Rand.Next(mingain, maxgain);
        }

        private void CheckStatus()
        {
            Console.WriteLine("Test Status of Bag Pokemon");

            if (Bag.CheckIsAktivePokemonKO())
            {
                Console.WriteLine("Active Pokemon is KO");
                if (Bag.CheckAreAllPokemonKO())
                {
                    Console.WriteLine("All Pokemons are KO");

                    IsBattelTime = false;
                }
                else
                {
                    Bag.CangeAktivePokemon();
                }
            }

            Console.WriteLine("Test Status of Enemy Pokemon");
            if (Enemy.CheckIsAktivePokemonKO())
            {
                Console.WriteLine("Active Pokemon is KO");
                if (Enemy.CheckAreAllPokemonKO())
                {
                    Console.WriteLine("All Pokemons are KO");
                    IsBattelTime = false;
                }
                else
                {
                    Console.WriteLine("Pokemon must be changed");
                    Enemy.CangeAktivePokemon();
                }
            }
            else
            {
                Console.WriteLine("Its All ok");
            }
        }


        private void BattlePhase(int ChosenAttack)
        {
            if (!(ChosenAttack == 0))
            {
                ChosenAttack -= 1;
                if (Bag.Team[_bag.ActivePokemon].Initiative >= Enemy.Team[Enemy.ActivePokemon].Initiative)
                {
                    Console.WriteLine("Bag Turn");
                    turnPlayer(ChosenAttack);
                    if (!Enemy.CheckIsAktivePokemonKO())
                    {
                        Console.WriteLine("Enemy Turn");
                        turnEnemy();
                    }
                }
                else
                {
                    Console.WriteLine("Enemy Turn");
                    turnEnemy();
                    if (!Bag.CheckIsAktivePokemonKO())
                    {
                        Console.WriteLine("Bag Turn");
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
            Console.WriteLine(Bag.Team[Bag.ActivePokemon].PokeAttacksToString());

            for (bool IndexCorrect = false; IndexCorrect == false;)
            {
                Console.Write("Enter Integer 1-4:");

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
            Console.WriteLine("______Player_________");

            DamageCalculation(
                Bag.Team[Bag.ActivePokemon],
                Bag.Team[Bag.ActivePokemon].PokeAttackList[ChosenAttack],
                Enemy.Team[Enemy.ActivePokemon]
            );
            Console.WriteLine("______PlayerTurnEnd_________");
        }


        private void turnEnemy()
        {
            Console.WriteLine("______Enemy_________");
            Random random = new Random();
            int RandomNumber = random.Next(0, 3);

            Console.WriteLine("Randomnumber" + RandomNumber);
            //Console.WriteLine(Enemy.Team[Enemy.ActivePokemon].PokeAttackList[RandomNumber].ToString());

            DamageCalculation(
                Enemy.Team[Enemy.ActivePokemon],
                Enemy.Team[Enemy.ActivePokemon].PokeAttackList[RandomNumber],
                Bag.Team[Bag.ActivePokemon]
            );
            Console.WriteLine("______EnemyTurnEnd_________");
        }


        private void DamageCalculation(Pokemon Attacking, Attack Attack, Pokemon Defending)
        {
            Console.WriteLine("________StartCalculation_______");
            double BonusDamage;
            double DamageAbsorb;
            int TakenDamage = Attack.Damage;
                
            BonusDamage = TakenDamage * ((double) Attacking.Strength / 100);
            TakenDamage += (int) Math.Round(+BonusDamage);
            DamageAbsorb = TakenDamage * ((double) Defending.Defence / 100);
            TakenDamage -= (int) Math.Round(DamageAbsorb);
            if (Defending.LivePoints - TakenDamage < 0)
            {
                Defending.LivePoints = 0;

                Console.WriteLine("DamageAttak" + Attack.Damage);
                Console.WriteLine("Bonusdamage" + BonusDamage);
                Console.WriteLine("Absorbet Damage" + DamageAbsorb);
                Console.WriteLine("TakenDamage" + TakenDamage);
                Console.WriteLine("Livpoints" + Defending.LivePoints);
            }
            else
            {
                Defending.LivePoints -= TakenDamage;
                Console.WriteLine("DamageAttak" + Attack.Damage);
                Console.WriteLine("Bonusdamage" + BonusDamage);
                Console.WriteLine("Absorbet Damage" + DamageAbsorb);
                Console.WriteLine("TakenDamage" + TakenDamage);
                Console.WriteLine("Livpoints" + Defending.LivePoints);
            }

            Console.WriteLine("________CalculationEnd____________");
        }

        
        public TeamEnemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public Bag Bag
        {
            get => _bag;
            set => _bag = value;
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