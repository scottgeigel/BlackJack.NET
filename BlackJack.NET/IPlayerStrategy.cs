namespace BlackJack.NET
{
    public interface IPlayerStrategy {
        void Play(IPlayer player, IGameController game);
        public int StayingScore { get; }
        bool WillStay(IPlayer player)
        {
            return player.Score >= StayingScore;
        }
    }
}
