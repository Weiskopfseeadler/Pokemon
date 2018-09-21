using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using pokemon.savs;

namespace poke.methd
{
    public class MainMenu
    {
        public static Bag Bag = new Bag();
        public static TeamEnemy Enemy = new TeamEnemy();

        public static void Main(string[] args)
        {
            Generate.GeneratAttack();
            Generate.GeneratPokemon();
//          Generate.Serialize();
            //Bag.Serialize(Bag);
            Bag.LoadBag();
            bool IsPlaying = true;
            while (IsPlaying)
            {
                Console.WriteLine("1 Items Einsetzen" +
                                  "\n2 Kampf gegen Trainer" +
                                  "\n3 Kampf gegen Einzelnes Pokemon" +
                                  "\n4 Shop" +
                                  "\n9 Quit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:

                        Bag.ChoseItem(null)
                            ;
                        break;
                    case 2:
                        Enemy.RandomEnemy(false);
                        StartBattel(false);
                        break;
                    case 3:
                        Enemy.RandomEnemy(true);
                        StartBattel(true);
                        break;
                    case 4:
                        Console.WriteLine("Was soll gekauft Werden");
                        Bag.ListAllItem();
                        string ItemToBuy = Console.ReadLine();
                        Bag.Items[ItemToBuy].ValueOfItem += 1;
                        Bag.Mony -= Bag.Items[ItemToBuy].Price
                            ;
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


        private static void StartBattel( bool IsSingelPokemon)
        {
            Battle BattleStart = new Battle();
            BattleStart.Enemy = Enemy;
            BattleStart.Bag = Bag;
            BattleStart.IsSingelPokemon = IsSingelPokemon;
            BattleStart.BattelMenu();
        }
    }
}