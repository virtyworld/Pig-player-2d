using UnityEngine;

public class Meta : MonoBehaviour
{
   [SerializeField] private EnemyComponent dogPrefab, farmerPrefab;
   [SerializeField] private Player playerPrefab;
   [SerializeField] Transform level;
   [SerializeField] Bomb bombPrefab;

   private EnemyComponent dog, farmer;
   private Player player;
   private EnemyMediator enemyMediator;
   
   private void Start()
   {
      dog = Instantiate(dogPrefab,level);
      farmer = Instantiate(farmerPrefab,level);
     
     
      player = Instantiate(playerPrefab,level);
      enemyMediator = new EnemyMediator(farmer,dog,player);
      player.Setup(bombPrefab,enemyMediator);
      
   }
}
