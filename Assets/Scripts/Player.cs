using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate (Vector3.left * (movespeed * Time.deltaTime)); 
        }
        if(Input.GetKey (KeyCode.D)) {
            transform.Translate (Vector3.right * (movespeed * Time.deltaTime));
        }
        if(Input.GetKey (KeyCode.S)) {
            transform.Translate (Vector3.down * (movespeed * Time.deltaTime));
        }
        if(Input.GetKey (KeyCode.W)) {
            transform.Translate (Vector3.up * (movespeed * Time.deltaTime));
        }
    }
}