using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int enemyNumber;
    bool isSpawning;
    public GameObject enemyPrefab;

    void Start()
    {
        enemyNumber = 0;
        isSpawning = false;
    }

    void Update()
    {
        if(isSpawning == false && enemyNumber < 30 && GameObject.Find("Player").GetComponent<PlayerMove>().alive == true)
        {
            isSpawning = true;
            Invoke("Spawn", 1f);
        }
    }
    
    void Spawn()
    {   
        Instantiate(enemyPrefab, new Vector3(Random.Range(transform.position.x - 20, transform.position.x + 20), Random.Range(transform.position.y + 12, transform.position.y - 12)), Quaternion.identity);
        enemyNumber++;
        isSpawning = false;
    }
}
