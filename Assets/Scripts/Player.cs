using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BaseComponent
{
    [SerializeField] private float movespeed = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movement;
    private Bomb bomb,bombPrefab;
    private EnemyMediator enemyMediator;
    
    public void Setup(Bomb bombPrefab,EnemyMediator enemyMediator)
    {
        this.bombPrefab = bombPrefab;
        this.enemyMediator = enemyMediator;
    }
   
   
    void Update()
    {
        Move();
        Attack();
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
    }

   
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
        rb.MovePosition(rb.position + movement * (movespeed*Time.deltaTime));
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            bomb = Instantiate(bombPrefab,transform.parent);
            bomb.transform.position = transform.position;
            bomb.Setup(enemyMediator);
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}