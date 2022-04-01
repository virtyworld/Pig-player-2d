using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyComponent : BaseComponent
{
    [SerializeField] private float accelerationTime = 3f;
    [SerializeField] private float movespeed = 1;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private float timeLeft;
    private bool isDirty,isAttack;

    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetBool("isAttack",isAttack);
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "DownBorder") movement = Vector2.up;
        if (other.transform.name == "UpBorder") movement = Vector2.down;
        if (other.transform.name == "LeftBorder") movement = Vector2.right;
        if (other.transform.name == "RightBorder") movement = Vector2.left;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = true;
            Attack();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) isAttack = false;
    }


    private void Move()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            NewDirectoryToMove();
        }

        transform.Translate(movement * (movespeed * Time.deltaTime));
    }

    private void NewDirectoryToMove()
    {
        int random = Random.Range(0, 3);
        if (random == 0) movement = Vector2.up;
        if (random == 1) movement = Vector2.down;
        if (random == 2) movement = Vector2.left;
        if (random == 3) movement = Vector2.right;

        timeLeft += accelerationTime;
    }

    private void Attack()
    {
        StartCoroutine(Hit());
    }
    
    private IEnumerator Hit(){
        isAttack = true;
        animator.SetBool("isAttack",true);
      
        
        yield return new WaitForSeconds(1);
        mediator.Notify(this,"Player");
        animator.SetBool("isAttack",false);
        isAttack = false;
        
    }

    public void SoDirty()
    {
        if (isDirty) Die();
        isDirty = true;
        animator.SetBool("isDirty",true);
        animator.SetLayerWeight(1,1);
    }

    private void Die()
    {
        if (isDirty) Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
