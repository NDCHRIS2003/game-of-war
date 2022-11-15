using AutoFixture;
using CardGameOfWar.App.Controller;
using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.Test
{
    public class GameControllerTest
    {
        private readonly Player player;
        private readonly Fixture fixture;
        private readonly GameController gameController;
        private const SuitEnum TrumpCard = SuitEnum.Clubs;
       
        public GameControllerTest()
        {
            player = new Player();
            fixture = new Fixture();
            gameController = new GameController((int)TrumpCard);
        }

        [Fact]
        public void ShouldPlayGame()
        {
            var players = GetPlayers();
            
            player.ShuffleDealDeck(players);
            OriginalCardDeck.ResetCardDeck();
            
            gameController.PlayGame();
        }

        [Fact]
        public void ShouldCompareCardReturnNegativeOneWhenPlayerOneCardIsLess()
        {
            var playerOneCard = new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Diamond };
            var playerTwoCard = new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Diamond };
            var result = gameController.CompareCard(playerOneCard, playerTwoCard);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ShouldCompareCardReturnPositiveOneWhenPlayerTwoCardIsGreater()
        {
            var playerOneCard = new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Diamond };
            var playerTwoCard = new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Diamond };
            var result = gameController.CompareCard(playerOneCard, playerTwoCard);
            Assert.Equal(1, result);
        }

        private List<Player> GetPlayers()
        {
            var players = new List<Player>()
            {
                new Player()
                {
                     CardDeck = fixture.Build<Card>().CreateMany(26).ToList(),
                     ScoreDeck = fixture.Build<Card>().CreateMany(0).ToList(),
                },

                new Player()
                {
                     CardDeck = fixture.Build<Card>().CreateMany(26).ToList(),
                     ScoreDeck = fixture.Build<Card>().CreateMany(0).ToList(),
                }
            };

            return players;
        }
    }
}
