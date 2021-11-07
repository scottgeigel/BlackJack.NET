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
        private bool stay;
        private readonly Shoe deck = new();
        public List<IGameListener> gameListeners = new();

        public GameController()
        {
            gameListeners.Add(player);
            gameListeners.Add(dealer);
        }
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

        private void NoftifyGameListeners()
        {
            foreach(IGameListener listener in gameListeners)
            {
                listener.NewGame();
            }
        }

        private void PlayerPlay(IPlayer currentPlayer)
        {
            stay = false;
            while (deck.Count > 0 && !(currentPlayer.IsBust || stay))
            {
                currentPlayer.Play(this);
            }
        }

        public void Play()
        {
            const string GAMEOVER_Push = "Result: Push";
            const string GAMEOVER_Player = "Result: Player wins!";
            const string GAMEOVER_Dealer = "Result: Dealer wins";
            Stats stats = new();
            gameListeners.Add(stats);
            stats.StartTimer();
            //4 cards minimum to play, though that's a coin toss
            while (deck.Count > 4)
            {
                NoftifyGameListeners();
                //deal out the cards.
                player.ReceiveCard(deck.Next());
                player.ReceiveCard(deck.Next());
                dealer.ReceiveCard(deck.Next());
                dealer.ReceiveCard(deck.Next());

                //let the player play
                PlayerPlay(player);

                if (!player.IsBust)
                {
                    PlayerPlay(dealer);
                }

                int playerScore = player.Score;
                int dealerScore = dealer.Score;

                Console.Out.WriteLine($"Player hand: {player.Hand} = {playerScore}");
                Console.Out.WriteLine($"Dealer hand: {dealer.Hand} = {dealerScore}");

                string result;
                if (player.IsBust || (!dealer.IsBust && playerScore < dealerScore))
                {
                    //dealer wins. dealer will not play if player busted themselves
                    result = GAMEOVER_Dealer;
                }
                else if (dealer.IsBust || (!player.IsBust && playerScore > dealerScore))
                {
                    //player wins. dealer can only go bust if the player didn't
                    result = GAMEOVER_Player;
                    stats.PlayerWon(playerScore);
                }
                else
                {
                    //neither are bust but tied
                    result = GAMEOVER_Push;
                }

                Console.Out.WriteLine(result);
                Console.Out.WriteLine();
            }
            stats.PrintStats();
            Console.Out.WriteLine();
        }

        public void Stay()
        {
            stay = true;
        }
    }
}
