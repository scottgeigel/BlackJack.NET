namespace BlackJack.NET
{
    public interface IPlayerStrategy {
        void Play(Player player, IGameController game);
        public int StayingScore { get; }
    }
}
