using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;


namespace CardGameOfWar.App.Controller
{
    public class GameController
    {
        private readonly SuitEnum trumpSuit;
        private readonly List<Player> players;        
        private readonly Player player;
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
            players = new List<Player> { new Player(), new Player() };           
            player = new Player();
        }        

        public void PlayGame()
        {

            player.ShuffleDealDeck(players);

            int? winnerPlayer = null;
            var gameToContinue = true;

            while (gameToContinue)
            {
                DrawCards();                              

                (gameToContinue, winnerPlayer) = CheckWinner();
            };

            if (winnerPlayer is null)
            {
                Console.WriteLine("Nobody wins the game");
            }
            else
            {
                Console.WriteLine($"Winner of the game is player {winnerPlayer + 1} with a winning pile of:");
                Console.WriteLine($"Deck in hand: \n {players[winnerPlayer ?? 0].ShowScoreDeck()}");
                Console.WriteLine($"Deck in Score Pile: \n {players[winnerPlayer ?? 0].ShowScoreDeck()}");
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
            if (players[0].CardDeck.Count + players[0].ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * OriginalCardDeck.winningRate))
            {
                return (false, 0);
            }
            else if (players[1].CardDeck.Count + players[1].ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * OriginalCardDeck.winningRate))
            {
                return (false, 1);
            }
            else
                return (true, null);

        }

        private void DrawCards()
        {            
            var playerOneCard = players[0].DrawCard();
            var playerTwoCard = players[1].DrawCard();
            int compareCardValue = CompareCard(playerOneCard, playerTwoCard);

            if (compareCardValue > 0)
            {
                players[0].ScoreDeck.Add(playerOneCard);
                players[0].ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 1 wins with Score Pile: {players[0].ShowScoreDeck()}");
                Console.WriteLine($"Player 1 total cards: {players[0].CardDeck.Count + players[0].ScoreDeck.Count}");
                Console.WriteLine($"Player 2 total cards: {players[1].CardDeck.Count + players[1].ScoreDeck.Count}");
            }
            else if (compareCardValue < 0)
            {
                players[1].ScoreDeck.Add(playerOneCard);
                players[1].ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 2 wins with Score Pile: {players[1].ShowScoreDeck()}");
                Console.WriteLine($"Player 2 total cards: {players[1].CardDeck.Count + players[1].ScoreDeck.Count}");
                Console.WriteLine($"Player 1 total cards: {players[0].CardDeck.Count + players[0].ScoreDeck.Count}");
            }
            else
            {                
                Console.WriteLine($"!!! War !!! \n");
                Console.WriteLine($"Player 1 card is equal to Player 2 card \n");
                Console.WriteLine($"Player 1 card: {playerOneCard.ToString()}");
                Console.WriteLine($"Player 2 card: {playerTwoCard.ToString()}");
                BattleWar(playerOneCard, playerTwoCard);
            }
        }

        private void BattleWar(Card playerOneInitialCard, Card playerTwoInitialCard)
        {
            int compareCardValue;
            do
            {
                List<Card> warCards = new();
                warCards.Add(playerOneInitialCard);
                warCards.Add(playerTwoInitialCard);

                // Burn both players cards
                var playerOneBurnOne = players[0].DrawCard();
                var playerOneBurnTwo = players[0].DrawCard();

                var playerTwoBurnOne = players[1].DrawCard();
                var playerTwoBurnTwo = players[1].DrawCard();

                // Draw cards for battle
                var playerOneCard = players[0].DrawCard();
                var playerTwoCard  = players[1].DrawCard();
                compareCardValue = CompareCard(playerOneCard, playerTwoCard);
                if(compareCardValue > 0)
                {
                    players[0].ScoreDeck.Add(playerOneBurnOne);
                    players[0].ScoreDeck.Add(playerOneBurnTwo);
                    players[0].ScoreDeck.Add(playerTwoBurnOne);
                    players[0].ScoreDeck.Add(playerTwoBurnTwo);
                    players[0].ScoreDeck.Add(playerOneCard);
                    players[0].ScoreDeck.Add(playerTwoCard);
                    players[0].ScoreDeck.AddRange(warCards);

                    Console.WriteLine($"Player 1 wins with Score Pile: {players[0].ShowScoreDeck()}");
                    Console.WriteLine($"Player 1 total cards: {players[0].CardDeck.Count + players[0].ScoreDeck.Count}");
                    Console.WriteLine($"Player 2 total cards: {players[1].CardDeck.Count + players[1].ScoreDeck.Count}");
                }
                else if(compareCardValue < 0)
                {
                    players[1].ScoreDeck.Add(playerOneBurnOne);
                    players[1].ScoreDeck.Add(playerOneBurnTwo);
                    players[1].ScoreDeck.Add(playerTwoBurnOne);
                    players[1].ScoreDeck.Add(playerTwoBurnTwo);
                    players[1].ScoreDeck.Add(playerOneCard);
                    players[1].ScoreDeck.Add(playerTwoCard);
                    players[1].ScoreDeck.AddRange(warCards);

                    Console.WriteLine($"Player 2 wins with Score Pile: {players[1].ShowScoreDeck()}");
                    Console.WriteLine($"Player 2 total cards: {players[1].CardDeck.Count + players[1].ScoreDeck.Count}");
                    Console.WriteLine($"Player 1 total cards: {players[0].CardDeck.Count + players[0].ScoreDeck.Count}");
                }
                else
                {
                    warCards.Add(playerOneBurnOne);
                    warCards.Add(playerOneBurnTwo);
                    warCards.Add(playerTwoBurnOne);
                    warCards.Add(playerTwoBurnTwo);
                    warCards.Add(playerOneCard);
                    warCards.Add(playerTwoCard);
                }
            } while (compareCardValue.Equals(0));
        }
    }
}