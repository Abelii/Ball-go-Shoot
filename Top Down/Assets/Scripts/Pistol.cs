using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    Weapon weapon;

    void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "AK")
        {
            transform.localScale = new Vector3(0.2f, 0.5f, 0f);
            Invoke("TagPistol", 0.1f);
        }
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "pistol")
        {
            transform.localScale = new Vector3(0.2f, 1f, 0f);
            Invoke("TagAK", 0.1f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "AK")
        {
            transform.localScale = new Vector3(0.2f, 0.5f, 0f);
            Invoke("TagPistol", 0.1f);
        }
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "pistol")
        {
            transform.localScale = new Vector3(0.2f, 1f, 0f);
            Invoke("TagAK", 0.1f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "AK")
        {
            transform.localScale = new Vector3(0.2f, 0.5f, 0f);
            Invoke("TagPistol", 0.1f);
        }
        if(Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && weapon.currentWeapon == "pistol")
        {
            transform.localScale = new Vector3(0.2f, 1f, 0f);
            Invoke("TagAK", 0.1f);
        }
    }

    void TagPistol()
    {
        gameObject.tag = "Pistol";
    }

    void TagAK()
    {
        gameObject.tag = "AK";
    }
}
