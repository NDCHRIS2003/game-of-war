using AutoFixture;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.Test
{
    public class GameOfWarPlayerTest
    {        
        private readonly Fixture fixture;
        public GameOfWarPlayerTest()
        {            
            fixture = new Fixture();
        }
        

        [Fact]
        public void ShouldDrawCardForPlayer()
        {
            var player = fixture.Build<GameOfWarPlayer>().Create();

            var result = player.DrawCard();
            
            Assert.IsType<Card>(result).Equals(player.CardDeck);            
        }
    }
}
