using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.NET
{
    public class CardCollection
    {
        private static readonly Dictionary<Face, int> lookup = new()
        {
            {Face.Two, 2 },
            {Face.Three, 3 },
            {Face.Four, 4 },
            {Face.Five, 5 },
            {Face.Six, 6 },
            {Face.Seven, 7 },
            {Face.Eight, 8 },
            {Face.Nine, 9 },
            {Face.Ten, 10 },
            {Face.Jack, 10 },
            {Face.Queen, 10 },
            {Face.King, 10 },
        };

        private readonly List<Card> cardCollection = new();

        public CardCollection(List<Card> initial = null)
        {
            if (initial != null)
            {
                cardCollection.AddRange(initial);
            }
        }

        public void AddCard(Card card)
        {
            cardCollection.Add(card);
        }

        public int Sum()
        {
            int sum = 0;
            var nonAce = cardCollection.Where(c => c.Face != Face.Ace);
            var ace = cardCollection.Where(c => c.Face == Face.Ace);

            foreach (Card c in nonAce)
            {
                sum += lookup[c.Face];
            }
            foreach (Card c in ace)
            {
                if ((sum + 11) > 21)
                {
                    sum++;
                }
                else
                {
                    sum += 11;
                }
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for(int i = 0; i < cardCollection.Count; i++)
            {
                sb.Append(cardCollection[i].ToString());
                if ((i +1 ) < cardCollection.Count)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
    }
}
