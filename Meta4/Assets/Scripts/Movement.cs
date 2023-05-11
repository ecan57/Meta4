using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;
    [SerializeField] GameObject gameoverText;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    UIManager uiManager;
    Delay delayScript;
    PlayerHealth playerHealth;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //inspector penceresinde player�n rigidboysini al�yor oyunu �al��t�r�nca
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
    }
    void MovementAction()
    {
        if(LevelManager.canMove)
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            //Debug.Log(horizontalMove);
            SpriteFlip(horizontalMove);
        }
    }

    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false; //sa�sol y�n� x ekseninde
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void PlayerDestroyer()
    {
        if (transform.position.y < playerYBoundry)
        {
            playerHealth.Lives();
            if (delayScript.delayTime == true)
            {
                delayScript.StartDelayTime();
            }
            Destroy(gameObject);
            soundManager.DeadByFallSound();
            //uiManager.GetComponent<Canvas>().enabled = true; //playerHealt.Lives ekleyince kald�rd�k
            //levelManager.RespawnPlayer(); //DelayTime i�inde yazd���m�zdan bunu kapatt�k
        }
    }

}
