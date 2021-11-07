using System;

namespace BlackJack.NET
{
    public class PlayerStrategy : IPlayerStrategy
    {
        public int StayingScore => 16;

        public bool WillStay(IPlayer player)
        {
            return player.Score >= StayingScore;
        }

        public void Play(IPlayer player, IGameController game)
        {
            if (player.IsBust)
            {
                throw new InvalidOperationException("Player is already bust");
            }
            if (player.Score < StayingScore)
            {
                player.ReceiveCard(game.Hit());
            }
            else
            {
                game.Stay();
            }
        }
    }
}
