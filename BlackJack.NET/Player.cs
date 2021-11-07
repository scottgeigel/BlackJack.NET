﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.NET
{

    public class Player : IPlayer, IGameListener
    {
        private CardCollection hand = new CardCollection();
        private IPlayerStrategy strategy;
        public int Score => hand.Sum();

        public bool WillStay => hand.Sum() >= StayingScore;

        public int StayingScore => strategy.StayingScore;

        public IPlayerStrategy Strategy => strategy;

        public Player(IPlayerStrategy strategy)
        {
            this.strategy = strategy;
        }

        public CardCollection Hand => hand;

        public void ReceiveCard(Card c)
        {
            hand.AddCard(c);
        }

        public void NewGame()
        {
            hand = new CardCollection();
        }
    }
}
