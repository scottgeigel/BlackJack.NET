using BlackJack.NET;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class CardCollectionTest
    {
        [Fact(DisplayName = "Single card check")]
        public void aSingleCardShouldHaveItsValue()
        {
            List<Card> cards = new List<Card> { new Card { Suite = Suite.Club, Face = Face.Ace } };
            Assert.Equal(11, new CardCollection(cards).Sum());
        }

        [Fact(DisplayName = "The Suite does not affect the value")]
        public void disregardSuites()
        {
            List<Card> clubCards = new List<Card> { new Card { Face = Face.Two, Suite = Suite.Club }, new Card { Face = Face.King, Suite = Suite.Club } };
            List<Card> heartCards = new List<Card> { new Card { Face = Face.Two, Suite = Suite.Heart }, new Card { Face = Face.King, Suite = Suite.Heart } };
            List<Card> spadeCards = new List<Card> { new Card { Face = Face.Two, Suite = Suite.Spade }, new Card { Face = Face.King, Suite = Suite.Spade } };
            List<Card> diamondCards = new List<Card> { new Card { Face = Face.Two, Suite = Suite.Diamond }, new Card { Face = Face.King, Suite = Suite.Diamond } };

            Assert.All(new List<List<Card>> { clubCards, heartCards, spadeCards, diamondCards }, cc => Assert.Equal(12, new CardCollection(cc).Sum()));
        }

        [Fact(DisplayName = "Aces will be valued at 1 if running sum is greater than 11")]
        public void aceOverflow()
        {
            List<Card> cards = new List<Card> { new Card { Suite = Suite.Club, Face = Face.Ace }, new Card { Suite = Suite.Club, Face = Face.Ace } };
            Assert.Equal(12, new CardCollection(cards).Sum());
        }
    }
}
