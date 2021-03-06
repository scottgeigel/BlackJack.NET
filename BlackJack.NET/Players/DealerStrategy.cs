using System;

namespace BlackJack.NET
{
    public class DealerStrategy : IPlayerStrategy
    {
        public int StayingScore => 21;
        public void Play(IPlayer player, IGameController game)
        {
            if (player.IsBust)
            {
                throw new InvalidOperationException("Player is already bust");
            }
            int otherScore = game.ObserveOtherPlayerScore(player);
            if (player.Score < StayingScore && player.Score < otherScore)
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
