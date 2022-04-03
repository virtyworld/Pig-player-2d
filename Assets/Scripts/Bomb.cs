using UnityEngine;

public class Bomb : BaseComponent
{
    private EnemyMediator enemyMediator;
    
    public void Setup(EnemyMediator enemyMediator)
    {
        this.enemyMediator = enemyMediator;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Farmer"))enemyMediator.Notify(this,"Farmer");
        if (other.CompareTag("Dog"))enemyMediator.Notify(this,"Dog");
        Destroy(gameObject);
    }
    
    

}
