using AutoFixture;
using CardGameOfWar.App.Controller;
using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.Test
{
    public class GameOfWarEngineTest
    {
        private readonly GameOfWarPlayer player;
        private readonly Fixture fixture;
        private readonly GameOfWarEngine gameOfWarEngine;
        private const SuitEnum TrumpCard = SuitEnum.Clubs;
       
        public GameOfWarEngineTest()
        {
            player = new GameOfWarPlayer();
            fixture = new Fixture();
            gameOfWarEngine = new GameOfWarEngine();
        }

        [Fact]
        public void ShouldPlayGame()
        {
            var players = GetPlayers();

            gameOfWarEngine.ShuffleDealDeck(players[0], players[1]);
            OriginalCardDeck.ResetCardDeck();
            
            gameOfWarEngine.Gameplay();
        }

        [Fact]
        public void ShouldCompareCardReturnNegativeOneWhenPlayerOneCardIsLess()
        {
            var playerOneCard = new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Diamond };
            var playerTwoCard = new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Diamond };
            var result = gameOfWarEngine.CompareCard(playerOneCard, playerTwoCard);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ShouldCompareCardReturnPositiveOneWhenPlayerTwoCardIsGreater()
        {
            var playerOneCard = new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Diamond };
            var playerTwoCard = new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Diamond };
            var result = gameOfWarEngine.CompareCard(playerOneCard, playerTwoCard);
            Assert.Equal(1, result);
        }

        private List<GameOfWarPlayer> GetPlayers()
        {
            var players = new List<GameOfWarPlayer>()
            {
                new GameOfWarPlayer()
                {
                     CardDeck = fixture.Build<Card>().CreateMany(26).ToList(),
                     ScoreDeck = fixture.Build<Card>().CreateMany(0).ToList(),
                },

                new GameOfWarPlayer()
                {
                     CardDeck = fixture.Build<Card>().CreateMany(26).ToList(),
                     ScoreDeck = fixture.Build<Card>().CreateMany(0).ToList(),
                }
            };

            return players;
        }
    }
}
