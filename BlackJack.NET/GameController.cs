using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.NET
{
    class GameController : IGameController
    {

        protected IPlayer dealer = new Player(new DealerStrategy());
        protected IPlayer player = new Player(new PlayerStrategy());
        private Shoe deck = new Shoe();

        public Card Hit()
        {
            return deck.Next();
        }

        public int ObserveOtherPlayerScore(IPlayer current)
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
                while (! (player.IsBust || player.Strategy.WillStay(player)))
                {
                    player.Play(this);
                }

                //let the dealer play
                while (!(dealer.IsBust || dealer.Strategy.WillStay(player)))
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
