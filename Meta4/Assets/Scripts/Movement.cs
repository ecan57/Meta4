using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //LevelManager levelManager;
    //SoundManager soundManager;
    //UIManager uiManager;
    Delay delayScript;
    PlayerHealth playerHealth;

    TrailRenderer tr;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;
    private float horizontalMove;

    public static bool canDash = true;
    public static bool isDashing = false;
    public static bool dashed;

    [SerializeField] GameObject gameoverText;
    [SerializeField] Animator anim;

    [SerializeField] float dashAmount;
    [SerializeField] float dashCoolDown;
    [SerializeField] float dashTime;
    [SerializeField] float playerYBoundry;


    private void Awake()
    {
        //levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        //soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        //uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //inspector penceresinde playerýn rigidboysini alýyor oyunu çalýþtýrýnca
        spriteRenderer = GetComponent<SpriteRenderer>();

        Cancel();
    }

    // Update is called once per frame
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
        StartDash();
    }

    void MovementAction()
    {
        if(isDashing)
            return;

        if(LevelManager.canMove)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            //Debug.Log(horizontalMove);
            SpriteFlip(horizontalMove);

            anim.SetFloat("Move", Mathf.Abs(horizontalMove));
        }
    }

    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
            spriteRenderer.flipX = false; //saðsol yönü x ekseninde
        else if (horizontalMove < 0)
            spriteRenderer.flipX = true;
    }

    void PlayerDestroyer()
    {
        if (transform.position.y < playerYBoundry)
        {
            playerHealth.Lives();

            if (delayScript.delayTime == true)
                delayScript.StartDelayTime();

            Destroy(gameObject);

            Movement.Cancel();

            //soundManager.DeadByFallSound();
            SoundManager.instance.PlayWithIndex(3);

            //uiManager.GetComponent<Canvas>().enabled = true; //playerHealt.Lives ekleyince kaldýrdýk
            //levelManager.RespawnPlayer(); //DelayTime içinde yazdýðýmýzdan bunu kapattýk
        }
    }

    void StartDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
            SoundManager.instance.PlayWithIndex(14);
        }
        horizontalMove = Input.GetAxis("Horizontal");
    }

    IEnumerator Dash() //fýrlama //sýralama önemli
    {
        canDash = false;
        isDashing = true;
        dashed = true;

        rb.gravityScale = 0;
        Jump.fallGravityScale = 0;

        tr.emitting = true;

        rb.velocity = new Vector2(horizontalMove * dashAmount, 0); //dash iþlemi yapýlýr

        yield return new WaitForSeconds(dashTime); //dashtime kadar bekle aþaðýdaki kodlara geç

        rb.gravityScale = 1;
        Jump.fallGravityScale = 15;

        isDashing = false;

        tr.emitting = false;

        yield return new WaitForSeconds(dashCoolDown);

        dashed = false;
        //Debug.Log("DASHING");
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
