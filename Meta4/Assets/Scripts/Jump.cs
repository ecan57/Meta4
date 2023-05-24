using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower; //sadece scriptin oldu�u yerden eri�ilebilmesini sa�l�yor inspectada de�i�tirilebilir hale getiriirli
    [SerializeField] float radius;
    public static float gravityScale = 1; //heryerden ul�abilmek i�in public static yapt�k //seriliezed field kald�rd���m�z i�in unityde g�remezdik o y�zden burada de�er verdik
    public static float fallGravityScale = 15; //heryerden ul�abilmek i�in public static yapt�k //seriliezed field kald�rd���m�z i�in unityde g�remezdik o y�zden burada de�er verdik
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;
    [SerializeField] SoundManager soundManager;
    [SerializeField] float startJumpTime;
    float jumpTime;
    bool isJumping;
    bool doubleJump;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAction();
        Gravity();
    }
    private bool IsGrounded() //dokunuyorsa true ya da false d�nd�recek dokunmazsa z�plamayacak //havada z�plmas�n� engelledik
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    void Gravity()
    {
        //Debug.Log("Rigidbody Velocity.Y" + rb.velocity.y);
        //Debug.Log("Rigidbody Velocity.X" + rb.velocity.x);
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
    void JumpAction()
    {
        if(Movement.isDashing)
        {
            return;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelManager.canMove)
        {
            isJumping = true;
            doubleJump = true;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //impulse: bi anda an�nda uygula
            jumpTime = startJumpTime;
            anim.SetBool("Jump", true);

            //soundManager.JumpSound();
            //soundManager.PlayAudio(SoundManager.instance.sounds[8]);
            //soundManager.PlayAudio(soundManager.sounds[8]);
            SoundManager.instance.PlayWithIndex(8);
        }
        if(Input.GetButtonDown("Jump") && doubleJump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJump = false;
        }
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime > 0)
            {
                //rb.velocity = Vector2.up * jumpPower;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force); //force: yava� yava� uygula
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        if(Mathf.Approximately(rb.velocity.y, 0) && anim.GetBool("Jump"))
        {
            anim.SetBool("Jump", true);
        }
        Gravity();
    }
}
