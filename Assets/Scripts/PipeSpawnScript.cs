using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipePref;
    public float spawnRate = 3f;
    public float timer = 0f;
    
    public float highetOffset = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0f;
        }
        
        
    }
    
    void SpawnPipe()
    {
        var transform1 = transform;
        var position = transform1.position;
        
        float lowestPoint = position.y - highetOffset;
        float highestPoint = position.y + highetOffset;
        Instantiate(pipePref, new Vector3(position.x, Random.Range(lowestPoint, highestPoint), 0), transform1.rotation);
    }
}
