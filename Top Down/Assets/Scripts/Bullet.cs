using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20f;
    Rigidbody2D rb;
    SpriteRenderer sRenderer;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "HF" && other.tag != "AF")
        {
            Invoke("DeRender", 0.02f);
            Invoke("Destroy", 0.1f);
        }
    }

    void OnBecameInvisible() {
        Invoke("Destroy", 2f);
    }

    void Destroy() {
        Destroy(gameObject);
    }

    void DeRender() {
        sRenderer.enabled = false;
    }
}
