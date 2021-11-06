using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.NET
{
    public class Shoe
    {
        public Stack<Card> deck;
        public int Count { get => deck.Count; }

        public Shoe()
        {
            Random rnd = new Random();
            List<Card> workingCards = new List<Card>();
            Face[] faces = (Face[])Enum.GetValues(typeof(Face));
            Suite[] suites = (Suite[])Enum.GetValues(typeof(Suite));

            //generate 6 decks
            for (int i = 0; i < 6; i++)
            {
                //for each suite
                foreach(Suite s in suites)
                {
                    //for each face value
                    foreach(Face f in faces)
                    {
                        workingCards.Add(new Card { Face = f, Suite = s });
                    }
                }
            }

            //now shuffle it
            for (int i = 0; i < workingCards.Count; i++)
            {
                int swapIndex = rnd.Next(workingCards.Count);
                Card swap = workingCards[i];
                workingCards[i] = workingCards[swapIndex];
                workingCards[swapIndex] = swap;
            }

            deck = new Stack<Card>(workingCards);
        }

        public Card Next() => deck.Pop();
    }
}
