using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Transform firePoint;
    Animator anim;
    Weapon weaponScript;
    public int health;
    TextMeshProUGUI healthText;
    TextMeshProUGUI scoreText;
    public int score;
    public int highScore;
    bool isDying;

    bool isMinusTen;
    int damage;
    bool coloror;

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        healthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        health = 100;
        moveSpeed = 4;
        firePoint = GameObject.Find("FirePoint").transform;
        weaponScript = GameObject.Find("Weapon").GetComponent<Weapon>();
        anim = GameObject.Find("Weapon").GetComponent<Animator>();
        isMinusTen = false;
        NormalColor();
        coloror = false;
    }

    void Update()
    {
        MovementControls();
        FaceMouse();
        healthText.text = health.ToString();
        if (health <= 0)
        {
            isDying = true;
            Invoke("Die", 0.2f);

        }
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = score + "/" + highScore;
        if(health < 0)
        {
            health = 0;
        }
    }

    void MovementControls()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
        transform.position = Vector2.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + moveSpeed), Time.deltaTime);}
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
        transform.position = Vector2.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - moveSpeed), Time.deltaTime);}
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
        transform.position = Vector2.Lerp(transform.position, new Vector3(transform.position.x - moveSpeed, transform.position.y), Time.deltaTime);}
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
        transform.position = Vector2.Lerp(transform.position, new Vector3(transform.position.x + moveSpeed, transform.position.y), Time.deltaTime);}
    }

    void FaceMouse()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
        //firePoint.up = direction;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Pistol" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToPistol", 0.2f);
        }
        if(other.tag == "AK" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToAK", 0.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pistol" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToPistol", 0.2f);
        }
        if(other.tag == "AK" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToAK", 0.2f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Pistol" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToPistol", 0.2f);
        }
        if(other.tag == "AK" && Input.GetKey(KeyCode.E))
        {
            Invoke("ToAK", 0.2f);
        }
    }
    
    void ToPistol()
    {
        weaponScript.currentWeapon = "pistol";
        anim.Play("AFKPistol");
    }

    void ToAK()
    {
        weaponScript.currentWeapon = "AK";
        anim.Play("AFKAK");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Damage();
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(isMinusTen == false && other.gameObject.tag == "Enemy")
        {
            Invoke("Damage", 0.5f);
            isMinusTen = true;  
            damage = other.gameObject.GetComponent<Enemy>().damage;
        }
        
    }

    void Damage()
    {
        if(isDying == false)
        {
            health -= damage;
            isMinusTen = false;
            GetComponent<AudioSource>().Play();
            if(coloror == false)
            {
                coloror = true;
                GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 255);
                Invoke("NormalColor", 0.1f);
            }
        }

    }

    void NormalColor()
    {
        GetComponent<SpriteRenderer>().color = new Color32(0, 179, 255, 255);
        coloror = false;
    }

    void Die()
    {
        transform.position = new Vector2(0, 0);
        health = 100;
        score = 0;
        weaponScript.pistolAmmo = 10;
        weaponScript.pistolTotalAmmo = 30;
        weaponScript.akAmmo = 60;
        weaponScript.akTotalAmmo = 180;
        isDying = false;
    }
}
