using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Transform firePoint;
    Animator anim;
    Weapon weaponScript;
    public int health;
    public GameObject YSW;
    public GameObject respawn;
    public GameObject ammoObject;
    public GameObject healthObject;
    public GameObject scoreObject;
    public ParticleSystem dmgPP;
    public Button respawnButton;
    TextMeshProUGUI healthText;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI scoreTextDie;
    public int score;
    public int highScore;
    public bool isDying;

    bool isMinusTen;
    int damage;
    bool coloror;
    bool isHighScore;

    public bool alive = true;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Weapon").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Weapon").GetComponent<SpriteRenderer>().enabled = true;
        alive = true;
        ammoObject.SetActive(true);
        healthObject.SetActive(true);
        scoreObject.SetActive(true);
        YSW.SetActive(false);
        respawn.SetActive(false);
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        healthText = healthObject.GetComponent<TextMeshProUGUI>();
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        scoreTextDie = YSW.GetComponent<TextMeshProUGUI>();
        health = 100;
        moveSpeed = 4;
        firePoint = GameObject.Find("FirePoint").transform;
        weaponScript = GameObject.Find("Weapon").GetComponent<Weapon>();
        anim = GameObject.Find("Weapon").GetComponent<Animator>();
        isMinusTen = false;
        NormalColor();
        coloror = false;
        isDying = false;
        isHighScore = false;
        respawnButton.onClick.AddListener(Respawn);
    }

    void Update()
    {
        MovementControls();
        FaceMouse();
        healthText.text = health.ToString();
        if (health <= 0 && isDying == false)
        {
            isDying = true;
            Invoke("Die", 0.2f);

        }
        if (score > highScore)
        {
            isHighScore = true;
            PlayerPrefs.SetInt("highScore", score);
        }
        highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = score + "/" + highScore;
        if(health < 0)
        {
            health = 0;
        }
        //respawn.GetComponent<Button>().onClick.AddListener(Respawn);
    }

    void MovementControls()
    {
        if(alive == true)
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
            dmgPP.Play();
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
        dmgPP.Stop();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Weapon").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Weapon").GetComponent<SpriteRenderer>().enabled = false;
        if(isHighScore == false){scoreTextDie.text = "YOUR SCORE WAS " + score + " OUT OF " + highScore + "!";}
        else if(isHighScore == true){scoreTextDie.text = "NEW HIGH SCORE, " + highScore + "!";}
        ammoObject.SetActive(false);
        healthObject.SetActive(false);
        scoreObject.SetActive(false);
        YSW.SetActive(true);
        respawn.SetActive(true);
        alive = false;
        isDying = false;
        health = 100;
    }

    void Respawn()
    {   
        Debug.Log("Respawning");
        isHighScore = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Weapon").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Weapon").GetComponent<SpriteRenderer>().enabled = true;
        YSW.SetActive(false);
        respawn.SetActive(false);
        ammoObject.SetActive(true);
        healthObject.SetActive(true);
        scoreObject.SetActive(true);
        transform.position = new Vector2(0, 0);
        score = 0;
        health = 100;
        weaponScript.pistolAmmo = 10;
        weaponScript.pistolTotalAmmo = 30;
        weaponScript.akAmmo = 60;
        weaponScript.akTotalAmmo = 180;
        alive = true;
    }
}
