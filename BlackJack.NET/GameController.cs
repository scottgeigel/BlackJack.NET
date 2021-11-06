using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.NET
{
    class GameController : IGameController
    {

        protected Player dealer = new Player(new DealerStrategy());
        protected Player player = new Player(new PlayerStrategy());
        private Shoe deck = new Shoe();

        public Card Hit()
        {
            return deck.Next();
        }

        public int ObserveOtherPlayerScore(Player current)
        {
            if (dealer == current)
            {
                return player.Score;
            }
            else if (player == current)
            {
                return dealer.Score;
            }
            else
            {
                throw new InvalidOperationException("unregistered player");
            }
        }


        public void Play()
        {
            //4 cards minimum to play, though that's a coin toss
            while (deck.Count > 4)
            {
                //deal out the cards.
                player.ReceiveCard(deck.Next());
                player.ReceiveCard(deck.Next());
                dealer.ReceiveCard(deck.Next());
                dealer.ReceiveCard(deck.Next());
                
                //let the player play
                while (! (player.IsBust || player.WillStay))
                {
                    player.Play(this);
                }

                //let the dealer play
                while (!(dealer.IsBust || dealer.WillStay))
                {
                    dealer.Play(this);
                }

                int playerScore = player.Score;
                int dealerScore = dealer.Score;

                if (playerScore == dealerScore)
                {
                    Console.Out.WriteLine("Result: Push");
                } 
                else if (playerScore > dealerScore)
                {
                    Console.Out.WriteLine("Result: Player wins!");
                }
                else
                {
                    Console.Out.WriteLine("Result: Dealer wins");
                }
            }
        }
    }
}
