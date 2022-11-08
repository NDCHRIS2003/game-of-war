using AutoFixture;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;
using CardGameOfWar.App.Service;

namespace CardGameOfWar.Test
{
    public class PlayerServiceTest
    {
        private readonly PlayerService playerService;
        private readonly Fixture fixture;
        public PlayerServiceTest()
        {
            playerService = new PlayerService();
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldCheckIfCardAvailableToPlay()
        {    
            var player = fixture.Build<Player>().Create();            
            
            player.CardDeck.Clear();          

            playerService.CheckIfCardsAvailableToPlay(player);
        }

        [Fact]
        public void ShouldDrawCardForPlayer()
        {
            var player = fixture.Build<Player>().Create();

            var result = playerService.DrawCard(player);
            
            Assert.IsType<Card>(result).Equals(player.CardDeck);            
        }
    }
}
