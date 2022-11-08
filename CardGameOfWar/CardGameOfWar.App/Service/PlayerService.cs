using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.App.Service
{
    public class PlayerService
    {
        Random random = new Random();
        
        public void CheckIfCardsAvailableToPlay(Player player)
        {            
            if (player.CardDeck.Count.Equals(0))
            {      
                var scoreDeck = ShufflePlayerDeck(player.ScoreDeck);
                player.CardDeck.AddRange(scoreDeck);
                player.ScoreDeck.Clear();
            }               
        }

        public Card DrawCard(Player player)
        {
            var card = player.CardDeck[0];
            player.CardDeck.RemoveAt(0);
            return card;            
        }        

        public List<Card> ShufflePlayerDeck(List<Card> cardDeck)
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

        public void ShuffleDealDeck(List<Player> players)
        {
            
            do
            {
                foreach (var player in players)
                {
                    var cardNumber = random.Next(0, OriginalCardDeck.CardDeck.Count - 1);                    
                    
                    player.CardDeck.Add(OriginalCardDeck.CardDeck.ElementAt(cardNumber));
                    OriginalCardDeck.CardDeck.RemoveAt(cardNumber);
                }

            } while (OriginalCardDeck.CardDeck.Count > 0);
        }
    }
}
