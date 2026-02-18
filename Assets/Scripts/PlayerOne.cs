using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerOne : MonoBehaviour
{
    public Transform childObject;

    public int speed;

    public float jumpPower;

    public float CheckWidth = 0.3f;

    public float CheckHeight = 0.3f;

    private Rigidbody2D rb;

    private Vector2 moveDirection;

    private bool isGrounded;

    private float coyoteTimer = 0.2f;

    private float coyoteTimerCounter;

    private float jumpTimer = 0.2f;

    private float jumpTimerCounter;

    private bool facingRight = true;

    private PlayerManager PlayerManagerer;

    public GameObject UIManager;

    public Animator animator;

    public AudioSource walking;

    public Transform GroundCheck;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManagerer = UIManager.GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        playerSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(CheckWidth, CheckHeight), CapsuleDirection2D.Vertical, 0, groundLayer);
        
        if (isGrounded)
        {
            coyoteTimerCounter = coyoteTimer;
        }
        else
        {
            coyoteTimerCounter -= Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Vertical"))
        {
            jumpTimerCounter = jumpTimer;
        }
        else
        {
            jumpTimerCounter -= Time.deltaTime;
        }
        
        if (PlayerManagerer.AllowMove)
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            if (moveDirection.x < 0 && facingRight)
            {
                Flip();
            }
            else if (moveDirection.x > 0 && !facingRight)
            {
                Flip();
            }
            if (jumpTimerCounter > 0f && coyoteTimerCounter > 0f)
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jumpPower));
                coyoteTimerCounter = 0f;
                jumpTimerCounter = 0f;
            }
        }
        else if (!PlayerManagerer.AllowMove) 
        {
            moveDirection.x = 0;
        }
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);
        
        if ((moveDirection.x != 0) && isGrounded)
        {
            if (!walking.isPlaying)
            {
                walking.Play();
            }
        }
        
        if (moveDirection.x == 0)
        {
            walking.Stop();
        }


    }
    private void playerSpawnPoint() 
    {
        transform.position = new Vector3(87, -9, 1);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        Vector3 childScale = childObject.localScale;
        childScale.x *= -1;
        childObject.localScale = childScale;
    }
}
