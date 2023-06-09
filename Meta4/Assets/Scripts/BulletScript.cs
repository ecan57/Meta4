using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    Delay delayScript;
    PlayerHealth playerHealthScript;

    [SerializeField] float bulletSpeed;

    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerParticle;
    [SerializeField] ParticleSystem playerHitParticle;
    [SerializeField] ParticleSystem playerBlockParticle;

    [SerializeField] GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealthScript = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null || CountManagerScript.instance.EndCount())
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Ground"))
            Instantiate(groundParticle, transform.position, Quaternion.identity);
        
        if (collision.gameObject.CompareTag("Player") && LevelManager.canMove && !Movement.bloking)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            LevelManager.canMove = false;
            anim.SetTrigger("Die");
            //Destroy(collision.gameObject);

            //Movement.Cancel();

            //playerHealthScript.Lives();

            Instantiate(playerParticle, transform.position, Quaternion.identity);
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);

            //if (delayScript.delayTime )
            //    delayScript.StartDelayTime();
        }
        else if(Movement.bloking)
        {
            Instantiate(playerBlockParticle, transform.position, Quaternion.identity);
        }
    }

}
