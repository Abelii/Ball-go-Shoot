using UnityEngine;

public class AmmoRefill : MonoBehaviour{
    Weapon w;

    void Start() {
        w = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            
            if(w.currentWeapon == "pistol" && w.pistolAmmo <= 8){
            w.pistolAmmo += 2;
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<CircleCollider2D>());
            GetComponent<ParticleSystem>().Play();
            Invoke("Destroy", 0.4f);
            }

            if(w.currentWeapon == "AK" && w.akAmmo <= 50){
            w.akAmmo += 10;
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<CircleCollider2D>());
            GetComponent<ParticleSystem>().Play();
            Invoke("Destroy", 0.4f);
            }
        }
    }
    void Destroy(){Destroy(gameObject);}
    void Update(){if(GameObject.Find("Player").GetComponent<PlayerMove>().alive == false){Destroy();}}
}
