using System;
using System.Runtime.InteropServices;
using ConsoleApplication1.pokemon.model;
using ConsoleApplication1.pokemon.savs;
using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.poke.model
{
    public class Item : ItemInterFace
    {
        private string _ItemName;
        private FunktionOfItem _FunktionOfItem;
        private int _ValueOfEffekt;
        private int _ValueOfItem;
        private int _Price;

        public Item(string ItemName, FunktionOfItem FunktionOfItem, int ValueOfEffekt, int ValueOfItem, int Price)
        {
            _ItemName = ItemName;
            _FunktionOfItem = FunktionOfItem;
            _ValueOfEffekt = ValueOfEffekt;
            _ValueOfItem = ValueOfItem;
            _Price = Price;
        }

        public void ActivateEffectOfItem(Bag Bag, int SelectetPokemon, Pokemon WildPokemon )
        {
            if (_ValueOfItem > 0)
            {
                switch (_FunktionOfItem)
                {
                    case FunktionOfItem.Heal:
                        Bag.Team[SelectetPokemon].LivePoints += _ValueOfEffekt;
                        break;
                    case FunktionOfItem.MoreDefense:
                        Bag.Team[SelectetPokemon].Defence += _ValueOfEffekt;
                        break;
                    case FunktionOfItem.MoreInitiative:
                        Bag.Team[SelectetPokemon].Initiative += _ValueOfEffekt;
                        ;
                        break;
                    case FunktionOfItem.MoreStrenth:
                        Bag.Team[SelectetPokemon].Strength += _ValueOfEffekt;
                        ;
                        break;
                    case FunktionOfItem.MoreHealth:
                        Bag.Team[SelectetPokemon].MaxLivePoints += _ValueOfEffekt;
                        Bag.Team[SelectetPokemon].LivePoints += _ValueOfEffekt;
                        break;
                    case FunktionOfItem.Pokeball:
                        Catch(Bag, WildPokemon);

                        ;
                        break;
                }



                _ValueOfItem -= 1;
            }
            
        }

        private void Catch(Bag Bag, Pokemon WildPokemon)
        {
            if (WildPokemon != null)
            {
                Random Rand = new Random();
                Console.WriteLine("Use pokeball");

                int RandomNumberGenerator = Rand.Next(0, WildPokemon.LivePoints);
                if (RandomNumberGenerator < ((WildPokemon.MaxLivePoints / 20)) * _ValueOfEffekt)
                {
                    Console.WriteLine("captured");
                    Bag.ListAllPokemon();
                    Console.WriteLine("Choose Slot to replac");
                    int slot = Convert.ToInt16(Console.ReadLine());
                    Bag.Team[slot] = new Pokemon(WildPokemon);
                    WildPokemon.LivePoints = 100;
                }
                else
                {
                    Console.WriteLine("Try to Catch faild");
                }
            }
            else
            {
                Console.WriteLine("you can't Captuered a pokemon from a Other Team");
            }
        }


        public string ToString()
        {
            return ItemName +"    "+ Convert.ToString(FunktionOfItem) + "    "+Convert.ToString(ValueOfEffekt) +"    "+
                   Convert.ToString(ValueOfItem);
        }

        public string ItemName
        {
            get => _ItemName;
            set => _ItemName = value;
        }

        public FunktionOfItem FunktionOfItem
        {
            get => _FunktionOfItem;
            set => _FunktionOfItem = value;
        }

        public int ValueOfEffekt
        {
            get => _ValueOfEffekt;
        }

        public int ValueOfItem
        {
            get => _ValueOfItem;
            set => _ValueOfItem = value;
        }

        public int Price
        {
            get => _Price;
            set => _Price = value;
        }
    }
}