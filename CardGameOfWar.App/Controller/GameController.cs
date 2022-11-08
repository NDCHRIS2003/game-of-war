using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;
using CardGameOfWar.App.Service;


namespace CardGameOfWar.App.Controller
{
    public class GameController
    {
        SuitEnum trumpSuit;
        List<Player> player;
        PlayerService playerService;
        public GameController(int trumpSuitNumber)
        {
            try
            {
                trumpSuit = (SuitEnum)trumpSuitNumber;
                OriginalCardDeck.ResetCardDeck();
            }
            catch (Exception)
            {

                throw;
            }
            player = new List<Player> { new Player(), new Player() };
            playerService = new PlayerService();
        }        

        public void PlayGame()
        {

            playerService.ShuffleDealDeck(player);

            int? winnerPlayer = null;
            var gameToContinue = true;

            while (gameToContinue)
            {
                DrawCards();
                playerService.CheckIfCardsAvailableToPlay(player[0]);
                playerService.CheckIfCardsAvailableToPlay(player[1]);                

                (gameToContinue, winnerPlayer) = CheckWinner();
            };

            if (winnerPlayer is null)
            {
                Console.WriteLine("Nobody wins the game");
            }
            else
            {
                Console.WriteLine($"Winner of the game is player {winnerPlayer + 1} with a winning pile of:");
                Console.WriteLine($"Deck in hand: \n {player[winnerPlayer ?? 0]}");
                Console.WriteLine($"Deck in Score Pile: \n {player[winnerPlayer ?? 0].ShowScoreDeck()}");
            }
        }

        public int CompareCard(Card playerOneCard, Card PlayerTwoCard)
        {
            int cardCompareValue = ((int)playerOneCard.CardValue).CompareTo((int)PlayerTwoCard.CardValue);

            if (cardCompareValue > 0)
            {
                return 1;
            }
            else if (cardCompareValue < 0)
            {
                return -1;
            }
            else if (playerOneCard.SuitValue.Equals(trumpSuit))
            {
                return 1;
            }
            else if (PlayerTwoCard.SuitValue.Equals(trumpSuit))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }               

        private (bool isGameContinue, int? winnerPlyr) CheckWinner()
        {
            if (player[0].CardDeck.Count + player[0].ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * OriginalCardDeck.winningRate))
            {
                return (false, 0);
            }
            else if (player[1].CardDeck.Count + player[1].ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * OriginalCardDeck.winningRate))
            {
                return (false, 1);
            }
            else
                return (true, null);
        }

        private void DrawCards()
        {
            var playerOneCard = playerService.DrawCard(player[0]);
            var playerTwoCard = playerService.DrawCard(player[1]);
            int compareCardValue = CompareCard(playerOneCard, playerTwoCard);

            if (compareCardValue > 0)
            {
                player[0].ScoreDeck.Add(playerOneCard);
                player[0].ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 1 wins with Score Pile: {player[0].ShowScoreDeck()}");
                Console.WriteLine($"Player 1 total cards: {player[0].CardDeck.Count + player[0].ScoreDeck.Count}");
                Console.WriteLine($"Player 2 total cards: {player[1].CardDeck.Count + player[1].ScoreDeck.Count}");
            }
            else if (compareCardValue < 0)
            {
                player[1].ScoreDeck.Add(playerOneCard);
                player[1].ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 2 wins with Score Pile: {player[1].ShowScoreDeck()}");
                Console.WriteLine($"Player 2 total cards: {player[1].CardDeck.Count + player[1].ScoreDeck.Count}");
                Console.WriteLine($"Player 1 total cards: {player[0].CardDeck.Count + player[0].ScoreDeck.Count}");
            }
            else
            {
                player[0].ScoreDeck.Add(playerOneCard);
                player[1].ScoreDeck.Add(playerTwoCard);
            }
        }
    }
}
