using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    ParticleSystem firePPNormal;
    public TextMeshProUGUI ammoCount;
    Animator anim;
    Animator cameraAnim;
    CircleCollider2D playerCollider;

    float fireRate = 0.5f;
    bool isWaiting;
    public string currentWeapon;
    public int pistolAmmo;
    public int pistolTotalAmmo;
    public int akAmmo;
    public int akTotalAmmo;
    bool isReloading;
    
    
    void Start()
    {
        playerCollider = GameObject.Find("Player").GetComponent<CircleCollider2D>();
        firePoint = GameObject.Find("FirePoint").transform;
        firePPNormal = GameObject.Find("FirePPNormal").GetComponent<ParticleSystem>();
        //cameraAnim = Camera.main.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        isWaiting = false;
        currentWeapon = "pistol";
        pistolTotalAmmo = 30;
        pistolAmmo = 10;
        akTotalAmmo = 180;
        akAmmo = 60;
        isReloading = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isWaiting == false && isReloading == false && GameObject.Find("Player").GetComponent<PlayerMove>().alive == true) {
            Shoot();}

        if (currentWeapon == "pistol") {
            PistolSettings();
        }
        if (currentWeapon == "AK") {
            AKSettings();
        }
        if(GameObject.Find("Player").GetComponent<PlayerMove>().health <= 0)
        {
            pistolAmmo = 10;
            pistolTotalAmmo = 30;
            akAmmo = 60;
            akTotalAmmo = 180;
        }

        WeaponSwitching();
        Ammo();
    }
    void Shoot()
    {
        if((currentWeapon == "pistol" && pistolAmmo > 0) || (currentWeapon == "AK" && akAmmo > 0))
        {
            isWaiting = true;
            Invoke("StopWaiting", fireRate);
            firePPNormal.Play();

            if(currentWeapon == "pistol" && isReloading == false && pistolAmmo > 0)
            {
                pistolAmmo = pistolAmmo - 1;
                anim.Play("PistolRecoil");
                GetComponent<AudioSource>().Play();
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }

            if(currentWeapon == "AK" && isReloading == false && akAmmo > 0)
            {
                akAmmo = akAmmo - 1;
                anim.Play("AKRecoil");
                GetComponent<AudioSource>().Play();
                Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
            }            
        }

    }


    void WeaponSwitching()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = "pistol";
            anim.Play("AFKPistol");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = "AK";
            anim.Play("AFKAK");
        }
    }

    void PistolSettings()
    {
        transform.localPosition = new Vector2(0f, 0.9f);
        transform.localScale = new Vector3(0.2f, 0.5f, 1f);
        firePoint.localPosition = new Vector2(0f, 0.5f);
        fireRate = 0.5f; 
        ammoCount.text = pistolAmmo + "/" + pistolTotalAmmo;
        GameObject.Find("Player").GetComponent<PlayerMove>().moveSpeed = 5f;
    }

    void AKSettings()
    {   
        transform.localPosition = new Vector2(0f, 1.1f);
        transform.localScale = new Vector3(0.2f, 1f, 1f);
        firePoint.localPosition = new Vector2(0f, 0.5f);
        fireRate = 0.1f; 
        ammoCount.text = akAmmo + "/" + akTotalAmmo;
        GameObject.Find("Player").GetComponent<PlayerMove>().moveSpeed = 4f;
        
    }

    void Ammo()
    {
        if(currentWeapon == "pistol" && pistolAmmo <= 0 && pistolTotalAmmo > 0 && isReloading == false){
            isReloading = true;
            Invoke("ReloadPistol", 1f);
        }

        if(currentWeapon == "AK" && akAmmo <= 0 && akTotalAmmo > 0 && isReloading == false){
            isReloading = true;
            Invoke("ReloadAK", 2f);
        }
    }

    void ReloadPistol()
    {
        if(pistolTotalAmmo > 0)
        {
            pistolAmmo = 10;
            pistolTotalAmmo = pistolTotalAmmo - 10;
            
        }
        isReloading = false;
    }

    void ReloadAK()
    {
        if(akTotalAmmo > 0)
        {
            akAmmo = 60;
            akTotalAmmo = akTotalAmmo - 60;
            
        }
        isReloading = false;
    }

    void StopWaiting() {
        isWaiting = false;
    }

    void StopAnim()
    {
        anim.StopPlayback();
    }
}

