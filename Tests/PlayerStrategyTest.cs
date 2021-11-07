using BlackJack.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    class TestPlayer : IPlayer
    {
        public int ManualScore { get; set; } = 0;
        public int Score => ManualScore;

        public IPlayerStrategy Strategy => TestHarnessStrategy;
        public IPlayerStrategy TestHarnessStrategy { get; set; }
        public void Play(IGameController game)
        {
            throw new NotImplementedException();
        }

        public Action OnReceiveCardCalled { get; set; }

        public CardCollection Hand => throw new NotImplementedException();

        public void ReceiveCard(Card c)
        {
            OnReceiveCardCalled();
        }

        public void NewGame()
        {
            throw new NotImplementedException();
        }
    }

    class TestGame : IGameController
    {
        private Stack<Card> deck;
        public TestGame(List<Card> deck)
        {
            this.deck = new Stack<Card>(deck);
        }

        public Card Hit()
        {
            return deck.Pop();
        }

        public int ManualScore { get; set; }
        public int ObserveOtherPlayerScore(IPlayer current) => ManualScore;

        public void Stay()
        {
        }
    }

    public class PlayerStrategyTest
    {
        [Fact(DisplayName = "It should hit when the hand is less than 16")]
        public void testLessThan16()
        {
            bool functionGotCalled = false;
            TestGame testGame = new TestGame(new List<Card> { new Card { Face = Face.Two, Suite = Suite.Spade } });
            PlayerStrategy playerStrategy = new PlayerStrategy();
            TestPlayer testPlayer = new TestPlayer()
            {
                ManualScore = 4,
                TestHarnessStrategy = playerStrategy,
                OnReceiveCardCalled = () => functionGotCalled = true
            };

            playerStrategy.Play(testPlayer, testGame);
            Assert.True(functionGotCalled, "Player did not Hit when they should have");
        }

        [Fact(DisplayName = "It should no hit when the hand is 16")]
        public void testEq16()
        {
            TestGame testGame = new TestGame(new List<Card> { new Card { Face = Face.Two, Suite = Suite.Spade } });
            PlayerStrategy playerStrategy = new PlayerStrategy();
            TestPlayer testPlayer = new TestPlayer()
            {
                ManualScore = 16,
                TestHarnessStrategy = playerStrategy,
                OnReceiveCardCalled = () => Assert.True(false, "Hit was called when it should not have been")
            };

            playerStrategy.Play(testPlayer, testGame);
        }

        [Fact(DisplayName = "Dealer should hit if score is <= than player's")]
        public void testDealerLessThanPlayer()
        {
            bool functionGotCalled = false;
            TestGame testGame = new TestGame(new List<Card> { new Card { Face = Face.Two, Suite = Suite.Spade } }) { ManualScore = 16 };
            DealerStrategy playerStrategy = new DealerStrategy();
            TestPlayer testPlayer = new TestPlayer()
            {
                ManualScore = 4,
                TestHarnessStrategy = playerStrategy,
                OnReceiveCardCalled = () => functionGotCalled = true
            };

            playerStrategy.Play(testPlayer, testGame);
            Assert.True(functionGotCalled, "Dealer did not Hit when they should have");

        }

        [Fact(DisplayName = "DealerStrategy should not hit if score > player score")]
        public void testDealerGreaterThanPlayer()
        {
            TestGame testGame = new TestGame(new List<Card> { new Card { Face = Face.Two, Suite = Suite.Spade } }) { ManualScore = 16 };
            DealerStrategy playerStrategy = new DealerStrategy();
            TestPlayer testPlayer = new TestPlayer()
            {
                ManualScore = 19,
                TestHarnessStrategy = playerStrategy,
                OnReceiveCardCalled = () => Assert.True(false, "Hit was called when it should not have been")
            };

            playerStrategy.Play(testPlayer, testGame);
        }
    }
}
