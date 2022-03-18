using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    public int damage;
    public float enemySpeed;
    bool isDying;
    PlayerMove playerMove;
    Vector3 size;
    float sizeNumber;
    public GameObject am;
    public GameObject hp;
    void Start()
    {
        health = Random.Range(90, 130);
        enemySpeed = Random.Range(0.6f, 4f);
        damage = Random.Range(8, 16);
        NormalColor();
        isDying = false;
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        if(enemySpeed <= 1f)
        {
            sizeNumber = Random.Range(1.1f, 1.5f);
            size = new Vector3(sizeNumber, sizeNumber, 1f);
            health = Random.Range(110, 150);
        }
        if(enemySpeed > 1f)
        {
            sizeNumber = Random.Range(0.6f, 1f);
            size = new Vector3(sizeNumber, sizeNumber, 1f);
            health = Random.Range(70, 120);
        }
        transform.localScale = size;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, enemySpeed * Time.deltaTime);
        if(health <= 0)
        {
            if(isDying == false)
            {
                isDying = true;
                GetComponentInChildren<ParticleSystem>().Play();
                GetComponentInChildren<AudioSource>().Play();
                playerMove.score = playerMove.score += 1;
                Invoke("Die", 0.4f);
                Destroy(GetComponent<CircleCollider2D>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<SpriteRenderer>());
            }
        }
        if (Vector2.Distance(GameObject.Find("Player").transform.position, transform.position) > 30){
            Invoke("SimpleDie", 0.06f);
        }
        if (GameObject.Find("Player").GetComponent<PlayerMove>().alive == false){
            Invoke("SimpleDie", 0.06f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "BulletPistol")
        {
            health = health - 20;
            GetComponent<SpriteRenderer>().color = new Color32(255, 100, 0, 255);
            GetComponent<AudioSource>().Play();
            Invoke("NormalColor", 0.1f);
        }
        if(other.tag == "BulletAK")
        {
            health = health - 5;
            GetComponent<SpriteRenderer>().color = new Color32(255, 100, 0, 255);
            GetComponent<AudioSource>().Play();
            Invoke("NormalColor", 0.1f);
        }
    }

    void NormalColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }

    void Die()
    {
        int ra = Random.Range(1,3);
        if(ra == 1){Instantiate(am, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);}
        if(ra == 2){Instantiate(hp, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);}
        GameObject.Find("Spawner").GetComponent<Spawner>().enemyNumber--;
        Destroy(gameObject);
    }
    void SimpleDie()
    {
        GameObject.Find("Spawner").GetComponent<Spawner>().enemyNumber--;
        Destroy(gameObject);
    }
}
