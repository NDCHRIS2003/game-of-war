using CardGameOfWar.Abstractions;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.App.Models
{
    public class GameOfWarPlayer :
        IGameOfWarPlayer
    {
        public List<Card> CardDeck { get; set; }

        public List<Card> ScoreDeck { get; set; }

        private readonly Random random ;

        public GameOfWarPlayer()
        {
            CardDeck = new List<Card>();
            ScoreDeck = new List<Card>();
            random = new Random();
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

        public Card DrawCard()
        {
            if (CardDeck.Count.Equals(0))
            {
                var scoreDeck = ShufflePlayerDeck(ScoreDeck);
                CardDeck.AddRange(scoreDeck);
                ScoreDeck.Clear();
            }
            var card = CardDeck[0];
            CardDeck.RemoveAt(0);
            
            return card;
        }

        private List<Card> ShufflePlayerDeck(List<Card> cardDeck)
        {
            var playerCards = new List<Card>();

            do
            {
                var cardNumber = random.Next(0, cardDeck.Count - 1);
                playerCards.Add(cardDeck.ElementAt(cardNumber));
                cardDeck.RemoveAt(cardNumber);

            } while (cardDeck.Count > 0);

            return playerCards;
        }
    }
}
