using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public double deadZone = -45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        
        // delete pipe spawn if it is past the deadzone
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
