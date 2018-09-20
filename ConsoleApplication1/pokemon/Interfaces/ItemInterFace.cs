using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.pokemon.model
{
    public interface ItemInterFace
    {
         void ActivateEffectOfItem(Bag Bag,int SelectetPokemon ,Pokemon WildPokemon = null);
    }
}