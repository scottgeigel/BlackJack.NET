namespace BlackJack.NET
{
    public interface IGameController
    {
        Card Hit();
        int ObserveOtherPlayerScore(IPlayer current);
    }
}