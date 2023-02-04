public enum FruitType
{
    ATTACK,
    HEAL,
    A_SPEED,
    SPEED
}
public abstract class Fruit
{
    protected PlayerWrapper host;
    public FruitType FruitType; 
    public void CachePlayer(PlayerWrapper givenPlayer)
    {
        host = givenPlayer;
    }

    public abstract void ActivateEffect();



}
