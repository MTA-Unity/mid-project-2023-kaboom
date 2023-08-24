using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapForce = 100f;
    public LogicScript logic;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead )
        {
            rb.velocity = Vector2.up * flapForce;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.GameOver();
        isDead = true;
    }
}