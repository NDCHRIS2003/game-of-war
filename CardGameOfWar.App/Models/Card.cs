using CardGameOfWar.App.Enums;

namespace CardGameOfWar.App.Mosdels
{
    public class Card
    {
        public CardEnum CardValue { get; set; }
        public SuitEnum SuitValue { get; set; }

        public override string ToString()
        {
            return $"{ CardValue} {SuitValue} \n ";
        }
    }
}
