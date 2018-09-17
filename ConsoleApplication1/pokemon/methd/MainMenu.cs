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


            TeamPlayer Player = new TeamPlayer();
            TeamEnemy Enemy = new TeamEnemy();


            Generate.GeneratAttack();
            Generate.GeneratPokemon();
            Generate.GeneratItems();

            Player.SetTeam();
            Enemy.SetTeam();


            Player.Team[0].Name = "Fritz";
            Player.ChangeAttack(0, 3, "vines");
            Enemy.Team[0].Name = "Hans";
            bool IsPlaying = true;
            while (IsPlaying)
            {
                Console.WriteLine("1 Items Einsetzen" +
                                  "\n2 Kampf gegen Trainer" +
                                  "\n3 Kampf gegen Einzelnes Pokemon" +
                                  "\n9 Quit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:

                        Player.ChoseItem()
                            ;
                        break;
                    case 2:
                        Enemy.RandomEnemy(false);
                        StartBattel(Enemy, Player, false);
                        break;
                    case 3:
                        Enemy.RandomEnemy(true);
                        break;
                    case 9:
                        IsPlaying = false;
                        break;
                }
            }


            Console.WriteLine("battel over");
            Console.WriteLine(Player.ToString());
        }


        private static void StartBattel(TeamEnemy Enemy, TeamPlayer Player, bool IsSingelPokemon)
        {
            Battle BattleStart = new Battle();
            BattleStart.Enemy = Enemy;
            BattleStart.Player = Player;
            BattleStart.IsSingelPokemon = IsSingelPokemon;
            BattleStart.BattelMenu();
        }
    }
}