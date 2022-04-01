public class EnemyMediator : IMediator
{
    private EnemyComponent farmer;
    private EnemyComponent dog;
    private Player player;
    private Bomb bomb;
    
    public EnemyMediator(EnemyComponent farmer,EnemyComponent dog,Player player)
    {
        this.farmer = farmer;
        this.farmer.SetMediator(this);
        this.dog = dog;
        this.dog.SetMediator(this);
        this.player = player;
        this.player.SetMediator(this);
    }
    
    public void Notify(object sender, string ev)
    {
        if (ev == "Farmer")farmer.SoDirty();
        if (ev == "Dog")dog.SoDirty();
        if (ev == "Player") player?.Die();
    }
}
