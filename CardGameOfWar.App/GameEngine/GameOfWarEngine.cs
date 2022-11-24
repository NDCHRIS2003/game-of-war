using CardGameOfWar.App.Abstractions;
using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;


namespace CardGameOfWar.App.Controller
{
    public class GameOfWarEngine :
        IGameOfWarEngine
    {
        public const double winningRate = 0.75;
        private readonly GameOfWarPlayer playerOne;
        private readonly GameOfWarPlayer playerTwo;
        private SuitEnum trumpSuit;

        public GameOfWarEngine()
        {      
            playerOne = new GameOfWarPlayer();
            playerTwo = new GameOfWarPlayer();
        }        

        public void PlayGame()
        {
            while (true)
            {
                Console.WriteLine("Choose a Trump Suite number to play game then press enter " +
                    "\n(Diamond = 0, Spades = 1, Clubs = 2, Hearts = 3)");
                var trumpNumber = Console.ReadLine()!;
                if (trumpNumber.Equals("Stop", StringComparison.OrdinalIgnoreCase))
                    break;

                if (OriginalCardDeck.TrumSuitRange.Contains(int.Parse(trumpNumber)))
                {
                    trumpSuit = (SuitEnum)int.Parse(trumpNumber);
                    Gameplay();

                    Console.WriteLine("Press any number between 0,1,2,4 to play again or type stop to quit the game");
                }
                else
                {
                    Console.WriteLine("Incorrect option chosen for Trump suite. Choose again");
                }
            }
        }

        public void Gameplay()
        {
            ShuffleDealDeck(playerOne, playerTwo);

            int? winnerPlayer = null;
            var gameToContinue = true;

            while (gameToContinue)
            {
                DrawCards();

                (gameToContinue, winnerPlayer) = CheckWinner();
            };

            ShowWinner(winnerPlayer);
        }

        private void ShowWinner(int? winnerPlayer)
        {
            if (winnerPlayer is null)
            {
                Console.WriteLine("Nobody wins the game");
            }
            else
            {
                Console.WriteLine($"Winner of the game is player {winnerPlayer + 1} with a winning pile of:");
              
                Console.WriteLine($"Deck in hand: \n {(winnerPlayer.Equals(0) ? playerOne : playerTwo)}");
                Console.WriteLine($"Deck in Score Pile: \n  {(winnerPlayer.Equals(0) ? playerOne.ShowScoreDeck() : playerTwo.ShowScoreDeck())}");              
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
            if (playerOne.CardDeck.Count + playerOne.ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * winningRate))
            {
                return (false, 0);
            }
            else if (playerTwo.CardDeck.Count + playerTwo.ScoreDeck.Count >= (OriginalCardDeck.cardsInDeck * winningRate))
            {
                return (false, 1);
            }
            else
                return (true, null);

        }

        private void DrawCards()
        {            
            var playerOneCard = playerOne.DrawCard();
            var playerTwoCard = playerTwo.DrawCard();
            int compareCardValue = CompareCard(playerOneCard, playerTwoCard);

            if (compareCardValue > 0)
            {
                playerOne.ScoreDeck.Add(playerOneCard);
                playerOne.ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 1 wins with Score Pile: {playerOne.ShowScoreDeck()}");
                Console.WriteLine($"Player 1 total cards: {playerOne.CardDeck.Count + playerOne.ScoreDeck.Count}");
                Console.WriteLine($"Player 2 total cards: {playerTwo.CardDeck.Count + playerTwo.ScoreDeck.Count}");
            }
            else if (compareCardValue < 0)
            {
                playerTwo.ScoreDeck.Add(playerOneCard);
                playerTwo.ScoreDeck.Add(playerTwoCard);

                Console.WriteLine($"Player 2 wins with Score Pile: {playerTwo.ShowScoreDeck()}");
                Console.WriteLine($"Player 2 total cards: {playerTwo.CardDeck.Count + playerTwo.ScoreDeck.Count}");
                Console.WriteLine($"Player 1 total cards: {playerOne.CardDeck.Count + playerOne.ScoreDeck.Count}");
            }
            else
            {                
                Console.WriteLine($"!!! War !!! \n");
                Console.WriteLine($"Player 1 card is equal to GameOfWarPlayer 2 card \n");
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
                var playerOneBurnOne = playerOne.DrawCard();
                var playerOneBurnTwo = playerOne.DrawCard();

                var playerTwoBurnOne = playerTwo.DrawCard();
                var playerTwoBurnTwo = playerTwo.DrawCard();

                // Draw cards for battle
                var playerOneCard = playerOne.DrawCard();
                var playerTwoCard  = playerTwo.DrawCard();
                compareCardValue = CompareCard(playerOneCard, playerTwoCard);
                if(compareCardValue > 0)
                {
                    playerOne.ScoreDeck.Add(playerOneBurnOne);
                    playerOne.ScoreDeck.Add(playerOneBurnTwo);
                    playerOne.ScoreDeck.Add(playerTwoBurnOne);
                    playerOne.ScoreDeck.Add(playerTwoBurnTwo);
                    playerOne.ScoreDeck.Add(playerOneCard);
                    playerOne.ScoreDeck.Add(playerTwoCard);
                    playerOne.ScoreDeck.AddRange(warCards);

                    Console.WriteLine($"Player 1 wins with Score Pile: {playerOne.ShowScoreDeck()}");
                    Console.WriteLine($"Player 1 total cards: {playerOne.CardDeck.Count + playerOne.ScoreDeck.Count}");
                    Console.WriteLine($"Player 2 total cards: {playerTwo.CardDeck.Count + playerTwo.ScoreDeck.Count}");
                }
                else if(compareCardValue < 0)
                {
                    playerTwo.ScoreDeck.Add(playerOneBurnOne);
                    playerTwo.ScoreDeck.Add(playerOneBurnTwo);
                    playerTwo.ScoreDeck.Add(playerTwoBurnOne);
                    playerTwo.ScoreDeck.Add(playerTwoBurnTwo);
                    playerTwo.ScoreDeck.Add(playerOneCard);
                    playerTwo.ScoreDeck.Add(playerTwoCard);
                    playerTwo.ScoreDeck.AddRange(warCards);

                    Console.WriteLine($"Player 2 wins with Score Pile: {playerTwo.ShowScoreDeck()}");
                    Console.WriteLine($"Player 2 total cards: {playerTwo.CardDeck.Count + playerTwo.ScoreDeck.Count}");
                    Console.WriteLine($"Player 1 total cards: {playerOne.CardDeck.Count + playerOne.ScoreDeck.Count}");
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

        public void ShuffleDealDeck(GameOfWarPlayer playerOne, GameOfWarPlayer playerTwo)
        {
            var players = new List<GameOfWarPlayer> { playerOne, playerTwo };
            
            var random = new Random();

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
