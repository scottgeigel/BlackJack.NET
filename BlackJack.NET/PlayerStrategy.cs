using System;

namespace BlackJack.NET
{
    public class PlayerStrategy : IPlayerStrategy
    {
        public int StayingScore => 16;
        public void Play(Player player, IGameController game)
        {
            if (player.IsBust)
            {
                throw new InvalidOperationException("Player is already bust");
            }
            if (player.Score < StayingScore)
            {
                player.ReceiveCard(game.Hit());
            }
        }
    }
}
