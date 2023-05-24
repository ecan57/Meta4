using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    Vector2 direction; 
    Vector2 target;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunLight;

    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] ParticleSystem muzzellEfect;

    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;

    public bool isClose;

    [Header("Mode Rate")]
    [SerializeField] float easyRate;
    [SerializeField] float normalRate;
    [SerializeField] float hardRate;

    private void Start()
    {
        fireRate = HardenedScript.instance.HardenedLevel(fireRate, easyRate, normalRate, hardRate);
    }
    void Update()
    {
        GunDirection();
        GunLight();
        //if (Input.GetMouseButton(0))
        //{
        //    BulletSpawn();
        //} //GunLight() ekleyince kaldýrdýk
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
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
        else
            gunLight.GetComponent<SpriteRenderer>().color= Color.green;
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
