using System;
using pokemon.savs;

namespace poke.methd
{
    public class MainMenu
    {


        public static void Main(string[] args)
        {
            // TODO Auto-generated method stub
            
            
            TeamPlayer  Player = new TeamPlayer();
            TeamEnemy Enemy = new TeamEnemy();
            
      
            Player.SetTeam();
            Enemy.SetTeam();
            

            Battle BattleStart = new Battle();
            Player.Team[0].Name = "Fritz";
            Player.ChangeAttack(0, 3, "vines");
            Enemy.Team[0].Name = "Hans";

            Console.WriteLine("1 Items Einsetzen" +
                              "\n2 Kampf gegen Trainer" +
                              "\n3 Kampf gegen Einzelnes Pokemon");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: ;break;
                    
            }

            StartBattel(BattleStart,Enemy,Player);


            Console.WriteLine("battel over");
            Console.WriteLine(Player.ToString());
        }

        private static void StartBattel(Battle BattleStart,TeamEnemy Enemy,TeamPlayer Player)
        {
            BattleStart.Enemy = Enemy;
            BattleStart.Player = Player;
            BattleStart.IsSingelPokemon = false;
            BattleStart.BattelMenu();
        }
    }
}