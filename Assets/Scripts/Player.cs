using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : BaseComponent
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Bomb bomb, bombPrefab;
    private EnemyMediator enemyMediator;

    public void Setup(Bomb bombPrefab, EnemyMediator enemyMediator)
    {
        this.bombPrefab = bombPrefab;
        this.enemyMediator = enemyMediator;
    }

    void Update()
    {
        Move();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                Attack();
            }
        }
    }


    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cursor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                -Camera.main.transform.position.z));
            cursor.z = 0f;

            StopAllCoroutines();
            StartCoroutine(MoveTo(transform.position, cursor, moveSpeed));
        }
    }

    IEnumerator MoveTo(Vector2 start, Vector2 destination, float speed)
    {
        while ((start - destination).magnitude > 0.01f)
        {
            movement = destination - start;
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void Attack()
    {
        bomb = Instantiate(bombPrefab, transform.parent);
        bomb.transform.position = transform.position;
        bomb.Setup(enemyMediator);
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}