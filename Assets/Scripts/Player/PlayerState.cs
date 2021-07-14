public class PlayerState : IState
{
    public float MoveSpeed = 5f;
    public int Coins = 0;
    public int Experience = 0;

    public void Reset()
    {
        MoveSpeed = 5f;
        Coins = 0;
        Experience = 0;
    }
}
