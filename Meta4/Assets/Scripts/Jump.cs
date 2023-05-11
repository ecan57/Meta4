using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower; //sadece scriptin olduðu yerden eriþilebilmesini saðlýyor inspectada deðiþtirilebilir hale getiriirli
    [SerializeField] float radius;
    [SerializeField] float gravityScale;
    [SerializeField] float fallGravityScale;
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask layerMask;
    [SerializeField] SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAction();
        Gravity();
    }
    private bool IsGrounded() //dokunuyorsa true ya da false döndürecek dokunmazsa zýplamayacak //havada zýplmasýný engelledik
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
        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelManager.canMove)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            soundManager.JumpSound();
        }
    }
}
