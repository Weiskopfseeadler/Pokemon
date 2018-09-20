using System;
using System.Runtime.InteropServices;
using ConsoleApplication1.pokemon.model;
using poke.model;
using pokemon.savs;

namespace ConsoleApplication1.poke.model
{
    public class Item : ItemInterFace
    {
        private string _itemName;
        private FunktionOfItem _funktionOfItem;
        private int _valueOfEffekt;
        private int _valueOfItem;
        private int _price;

        public Item(string itemName, FunktionOfItem funktionOfItem, int valueOfEffekt, int valueOfItem, int price)
        {
            _itemName = itemName;
            _funktionOfItem = funktionOfItem;
            _valueOfEffekt = valueOfEffekt;
            _valueOfItem = valueOfItem;
            _price = price;
        }

        public void ActivateEffectOfItem(Bag Bag, int SelectetPokemon, Pokemon WildPokemon )
        {
            if (_valueOfItem > 0)
            {
                switch (_funktionOfItem)
                {
                    case FunktionOfItem.Heal:
                        Bag.Team[SelectetPokemon].LivePoints += _valueOfEffekt;
                        break;
                    case FunktionOfItem.MoreDefense:
                        Bag.Team[SelectetPokemon].Defence += _valueOfEffekt;
                        break;
                    case FunktionOfItem.MoreInitiative:
                        Bag.Team[SelectetPokemon].Initiative += _valueOfEffekt;
                        ;
                        break;
                    case FunktionOfItem.MoreStrenth:
                        Bag.Team[SelectetPokemon].Strength += _valueOfEffekt;
                        ;
                        break;
                    case FunktionOfItem.MoreHealth:
                        Bag.Team[SelectetPokemon].MaxLivePoints += _valueOfEffekt;
                        Bag.Team[SelectetPokemon].LivePoints += _valueOfEffekt;
                        break;
                    case FunktionOfItem.Pokeball:
                        Catch(Bag, WildPokemon);

                        ;
                        break;
                }



                _valueOfItem -= 1;
            }
            
        }

        private void Catch(Bag Bag, Pokemon WildPokemon)
        {
            if (WildPokemon != null)
            {
                Random rand = new Random();
                Console.WriteLine("Use pokeball");

                int RandomNumberGenerator = rand.Next(0, WildPokemon.LivePoints);
                if (RandomNumberGenerator < ((WildPokemon.MaxLivePoints / 20)) * _valueOfEffekt)
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
            get => _itemName;
            set => _itemName = value;
        }

        public FunktionOfItem FunktionOfItem
        {
            get => _funktionOfItem;
            set => _funktionOfItem = value;
        }

        public int ValueOfEffekt
        {
            get => _valueOfEffekt;
        }

        public int ValueOfItem
        {
            get => _valueOfItem;
            set => _valueOfItem = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }
    }
}