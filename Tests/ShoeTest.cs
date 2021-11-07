using BlackJack.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ShoeTest
    {
        [Fact(DisplayName = "The deck comes in a random order with all 312 cards")]
        public void ShuffleCheck()
        {
            Shoe shoe = new();
            Assert.Equal(312, shoe.Count);
            Dictionary<Card, int> tally = new();
            while(shoe.Count > 0)
            {
                Card card = shoe.Next();
                if (tally.TryGetValue(card, out int count))
                {
                    tally[card] = count + 1;
                } else
                {
                    tally[card] = 1;
                }
            }

            Assert.Equal(52, tally.Keys.Count);//should be 52 unique cards
            //and there should be 6 copies of those 52 cards
            Assert.All(tally.Values, count => Assert.Equal(6, count));
        }
    }
}
