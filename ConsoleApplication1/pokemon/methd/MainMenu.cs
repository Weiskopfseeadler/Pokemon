using System;
using System.Collections.Generic;
using System.Linq;
using pokemon.savs;

namespace poke.methd
{
    public class MainMenu
    {
        public static void Main(string[] args)
        {
            // TODO Auto-generated method stub


            Bag Bag = new Bag();
            TeamEnemy Enemy = new TeamEnemy();


            Generate.GeneratAttack();
            Generate.GeneratPokemon();
            Generate.GeneratItems();

            Bag.SetBag();
            Bag.Serialize(Bag);
            Bag.LoadBag();
            Enemy.SetBag();



            Console.WriteLine(Bag.);
            Bag.ChangeAttack(0, 3, "vines");
            Enemy.Team[0].PokemonName = "Hans";
            bool IsPlaying = true;
            while (IsPlaying)
            {
                Console.WriteLine("1 Items Einsetzen" +
                                  "\n2 Kampf gegen Trainer" +
                                  "\n3 Kampf gegen Einzelnes Pokemon" +
                                  "\n4 Shop" +
                                  "\n9 Quit" );
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:

                        Bag.ChoseItem()
                            ;
                        break;
                    case 2:
                        Enemy.RandomEnemy(false);
                        StartBattel(Enemy, Bag, false);
                        break;
                    case 3:
                        Enemy.RandomEnemy(true);
                        StartBattel(Enemy, Bag, true);
                        break;
                    case 9:
                        Bag.Serialize(Bag);
                        IsPlaying = false;
                        break;
                }
            }

            Console.WriteLine("battel over");
            Console.WriteLine(Bag.ToString());
        }


        private static void StartBattel(TeamEnemy Enemy, Bag Bag, bool IsSingelPokemon)
        {
            Battle BattleStart = new Battle();
            BattleStart.Enemy = Enemy;
            BattleStart.Bag = Bag;
            BattleStart.IsSingelPokemon = IsSingelPokemon;
            BattleStart.BattelMenu();
        }
    }
}