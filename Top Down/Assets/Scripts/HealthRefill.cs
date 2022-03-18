using UnityEngine;

public class HealthRefill : MonoBehaviour{
    PlayerMove pm;
    void Start(){pm = GameObject.Find("Player").GetComponent<PlayerMove>();}
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(pm.health <= 90){
            pm.health += 10;
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<CircleCollider2D>());
            GetComponent<ParticleSystem>().Play();
            Invoke("Destroy", 0.4f);
            }
        }
    }
    void Destroy(){Destroy(gameObject);}
    void Update(){if(pm.alive == false){Destroy();}}
}
