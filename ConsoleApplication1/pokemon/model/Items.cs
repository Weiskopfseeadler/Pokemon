using ConsoleApplication1.pokemon.model;
using poke.model;

namespace ConsoleApplication1.poke.model
{
    public class Items
    {
        private string _name;
        private FunktionOfItem _funktionOfItem;
        private int _valueOfEffekt;
        private int _valueOfItem;

        public Items(string name, FunktionOfItem funktionOfItem, int valueOfEffekt, int valueOfItem)
        {
            _name = name;
            _funktionOfItem = funktionOfItem;
            _valueOfEffekt = valueOfEffekt;
            _valueOfItem = valueOfItem;
        }

        public void activateEffectOfItem(Items UsedItem, Pokemon Pokemon)
        {
            if (UsedItem.ValueOfItem > 0)
            {
                switch (UsedItem.FunktionOfItem)
                {
                    case FunktionOfItem.Heal:
                        Pokemon.LivePoints += UsedItem.ValueOfEffekt;
                        break;
                    case FunktionOfItem.MoreDefense:
                        Pokemon.Defence += ValueOfEffekt;
                        break;
                    case FunktionOfItem.MoreInitiative:
                        ;
                        break;
                    case FunktionOfItem.MoreStrenth:
                        ;
                        break;
                }
            }

            UsedItem.ValueOfEffekt -= 1;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public FunktionOfItem FunktionOfItem
        {
            get => _funktionOfItem;
            set => _funktionOfItem = value;
        }

        public int ValueOfEffekt
        {
            get => _valueOfEffekt;
            set => _valueOfEffekt = value;
        }

        public int ValueOfItem
        {
            get => _valueOfItem;
            set => _valueOfItem = value;
        }
    }
}