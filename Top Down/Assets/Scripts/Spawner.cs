using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool isSpawning;
    public GameObject enemyPrefab;

    void Start()
    {
        isSpawning = false;
    }

    void Update()
    {
        if(isSpawning == false)
        {
            isSpawning = true;
            Invoke("Spawn", 1f);
        }
    }
    
    void Spawn()
    {
        
        Instantiate(enemyPrefab, new Vector3(Random.Range(transform.position.x - 20, transform.position.x + 20), Random.Range(transform.position.y + 12, transform.position.y - 12)), Quaternion.identity);
        isSpawning = false;
    }
}
