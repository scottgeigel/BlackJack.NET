namespace BlackJack.NET
{
    public interface IPlayerStrategy {
        void Play(IPlayer player, IGameController game);
        int StayingScore { get; }
        bool WillStay(IPlayer player)
        {
            return player.Score >= StayingScore;
        }
    }
}
