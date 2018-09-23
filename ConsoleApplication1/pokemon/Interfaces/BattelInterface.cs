using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.pokemon.Interfaces
{
    public interface BattelInterface
    {
        // Dies Classe ist zwar beim Jetzigen Stand nicht nötig aber in zukunft werden noch andere Kampfe wie DoppeloKampf
       void BattelMenu();
        void CheckStatus();
        void BattlePhase(int ChosenAttack);
        int ChoseAttack();
        void turnPlayer(int ChosenAttack);
        void turnEnemy();
        void DamageCalculation(Pokemon Attacking, Attack Attack, Pokemon Defending);
    }
}