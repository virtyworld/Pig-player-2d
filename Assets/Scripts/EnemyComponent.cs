using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private float accelerationTime = 3f;
    [SerializeField] private float movespeed = 1;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        Move();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.transform.name=="DownBorder")  movement = Vector2.up;
        if (other.transform.name=="UpBorder")  movement = Vector2.down;
        if (other.transform.name=="LeftBorder")  movement = Vector2.right;
        if (other.transform.name=="RightBorder")  movement = Vector2.left;
    }

    private void Move()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            NewDirectoryMove();
        }
        transform.Translate(movement * (movespeed * Time.deltaTime));
    }

    private void NewDirectoryMove()
    {
        int random = Random.Range(0, 3);
        if (random == 0) movement = Vector2.up;
        if (random == 1) movement = Vector2.down;
        if (random == 2) movement = Vector2.left;
        if (random == 3) movement = Vector2.right;

        timeLeft += accelerationTime;
    }
}
