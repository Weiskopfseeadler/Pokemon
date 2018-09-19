using System;
using ConsoleApplication1.pokemon.model;
using poke.model;

namespace ConsoleApplication1.poke.model
{
    public class Item : ItemInterFace
    {
        private string _itemName;
        private FunktionOfItem _funktionOfItem;
        private int _valueOfEffekt;
        private int _valueOfItem;

        public Item(string itemName, FunktionOfItem funktionOfItem, int valueOfEffekt, int valueOfItem)
        {
            _itemName = itemName;
            _funktionOfItem = funktionOfItem;
            _valueOfEffekt = valueOfEffekt;
            _valueOfItem = valueOfItem;
        }

        public void ActivateEffectOfItem(Pokemon Pokemon)
        {
            if (_valueOfItem > 0)
                switch (_funktionOfItem)
                {
                    case FunktionOfItem.Heal:
                        Pokemon.LivePoints += _valueOfEffekt;
                        break;
                    case FunktionOfItem.MoreDefense:
                        Pokemon.Defence += _valueOfEffekt;
                        break;
                    case FunktionOfItem.MoreInitiative:
                        ;
                        break;
                    case FunktionOfItem.MoreStrenth:
                        ;
                        break;
                    case FunktionOfItem.MoreHealth:
                        Pokemon.MaxLivePoints += _valueOfEffekt;
                        Pokemon.LivePoints += _valueOfEffekt;
                        break;
                    case FunktionOfItem.Pokeball:
                        ;
                        break;
                }


            _valueOfEffekt -= 1;
        }

        public string ToString()
        {
            return ItemName + Convert.ToString(FunktionOfItem) + Convert.ToString(ValueOfEffekt) +
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
    }
}