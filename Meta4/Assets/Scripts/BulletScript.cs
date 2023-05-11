using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Delay delayScript;
    PlayerHealth playerHealthScript;
    [SerializeField] float bulletSpeed;
    Rigidbody2D rb;
    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerParticle;
    [SerializeField] ParticleSystem playerHitParticle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealthScript = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(groundParticle, transform.position, Quaternion.identity);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Movement.Cancel();
            playerHealthScript.Lives();
            Instantiate(playerParticle, transform.position, Quaternion.identity);
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);
            if (delayScript.delayTime )
            {
                delayScript.StartDelayTime();
            }
        }
    }

}
