namespace BlackJack.NET
{
    public interface IPlayer
    {
        IPlayerStrategy Strategy { get; }
        bool IsBust => Score > 21;
        int Score { get; }

        void ReceiveCard(Card c);
        void Play(IGameController game) => Strategy.Play(this, game);
    }
}