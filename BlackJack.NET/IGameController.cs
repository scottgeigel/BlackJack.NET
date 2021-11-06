namespace BlackJack.NET
{
    public interface IGameController
    {
        Card Hit();
        int ObserveOtherPlayerScore(Player current);
    }
}