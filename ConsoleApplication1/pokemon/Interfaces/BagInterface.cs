using ConsoleApplication1.pokemon.savs;
using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.pokemon.Interfaces
{
    public interface BagInterface : TeamInterface
    {
        void ChoseItem(Pokemon Enemy);
        void ListAllItem();
        void ListAllPokemon();
        void LoadBag();
        void Serialize(Bag Bag);
        void LoadTeam(dynamic Item);
    }
}