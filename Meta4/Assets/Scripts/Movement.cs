using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;
    [SerializeField] float horizantalMove;
    [SerializeField] GameObject gameoverText;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    UIManager uiManager;
    Delay delayScript;
    PlayerHealth playerHealth;
    TrailRenderer tr;

    public static bool canDash = true;
    public static bool isDashing = false;
    [SerializeField] float dashAmount;
    [SerializeField] float dashCoolDown;
    [SerializeField] float dashTime;
    public static bool dashed;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        tr = GetComponent<TrailRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //inspector penceresinde playerýn rigidboysini alýyor oyunu çalýþtýrýnca
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizantalMove != 0)
        {
            StartCoroutine(Dash());
        }
        horizantalMove = Input.GetAxis("Horizontal");
        MovementAction();
        PlayerDestroyer();
    }
    void MovementAction()
    {
        if(isDashing)
        {
            return;
        }
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
            spriteRenderer.flipX = false; //saðsol yönü x ekseninde
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
            Movement.Cancel();
            soundManager.DeadByFallSound();
            //uiManager.GetComponent<Canvas>().enabled = true; //playerHealt.Lives ekleyince kaldýrdýk
            //levelManager.RespawnPlayer(); //DelayTime içinde yazdýðýmýzdan bunu kapattýk
        }
    }
    IEnumerator Dash() //fýrlama
    {
        canDash = false;
        isDashing = true;
        dashed = true;
        rb.gravityScale = 0;
        Jump.fallGravityScale = 0;
        tr.emitting = true;
        rb.velocity = new Vector2(horizantalMove * dashAmount, 0); //dash iþlemi yapýlýr
        yield return new WaitForSeconds(dashTime); //dashtime kadar bekle aþaðýdaki kodlara geç
        rb.gravityScale = 1;
        Jump.fallGravityScale = 15;
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCoolDown);
        dashed = false;
        Debug.Log("DASHING");
        canDash = true;

    }
    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
        dashed = false;
        Jump.fallGravityScale = 15;
    }

}
