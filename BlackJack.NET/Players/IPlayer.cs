namespace BlackJack.NET
{
    public interface IPlayer : IGameListener
    {
        IPlayerStrategy Strategy { get; }
        bool IsBust => Score > 21;
        int Score { get; }
        public CardCollection Hand { get; }

        void ReceiveCard(Card c);
        void Play(IGameController game) => Strategy.Play(this, game);
    }

    public interface IPlayerListener
    {
        void Stay();
    }
}