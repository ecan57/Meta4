using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem particle;
    [SerializeField] float destroyLimit;

    private Rigidbody2D rb;

    [Header("Mode Speed")]
    [SerializeField] float easySpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float hardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = HardenedScript.instance.HardenedLevel(moveSpeed, easySpeed, normalSpeed, hardSpeed);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyLimit)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            SoundManager.instance.PalyWithIndex(13);
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            PlayerHealth.instance.Lives();
            if(Delay.instance.delayTime) //býçakla ölüp gameover olunca tekrar canlanmayalým diye bu kontrolü yapýyoruz
            {
                Delay.instance.StartDelayTime();
            }
            Movement.Cancel();
            Destroy(gameObject);
        }
    }
}
