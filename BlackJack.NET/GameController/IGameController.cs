namespace BlackJack.NET
{
    public interface IGameController : IPlayerListener
    {
        Card Hit();
        int ObserveOtherPlayerScore(IPlayer current);
    }

    public interface IGameListener
    {
        void NewGame();
    }
}