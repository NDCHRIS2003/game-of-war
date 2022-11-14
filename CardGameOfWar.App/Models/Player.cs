using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.App.Models
{
    public class Player
    {
        public List<Card> CardDeck { get; set; }

        public List<Card> ScoreDeck { get; set; }

        public Player()
        {
            CardDeck = new List<Card>();
            ScoreDeck = new List<Card>();
        }

        public override string ToString()
        {
            var cardList = string.Empty;
            int no = 1;

            foreach (var card in CardDeck)
            {
                cardList += $"{no}. {card.CardValue} {card.SuitValue}";
                no++;
            }
            return cardList;
        }

        public string ShowScoreDeck()
        {
            var cardList = string.Empty;
            var no = 1;

            foreach(Card card in ScoreDeck)
            {
                cardList += $"{no}. {card.CardValue} {card.SuitValue} ";
                no++;
            }

            return cardList;
        }
               
    }
}
