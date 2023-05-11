using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    Vector2 direction; 
    Vector2 target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] GameObject gunLight;
    public bool isClose;
    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;
    [SerializeField] ParticleSystem muzzellEfect;
    void Update()
    {
        GunDirection();
        GunLight();
        //if (Input.GetMouseButton(0))
        //{
        //    BulletSpawn();
        //} //GunLight() ekleyince kald�rd�k
    }
    void GunDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            target = player.transform.position;
            direction = target - (Vector2)transform.position;
            transform.right = -direction;
        }
    }
    void BulletSpawn()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
        Instantiate(muzzellEfect, bulletSpawnPos.position, Quaternion.identity);
    }
    void GunLight()
    {
        if (isClose)
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gunLight.GetComponent<SpriteRenderer>().color= Color.green;
        }
    }
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletSpawn();
        }
    }
}