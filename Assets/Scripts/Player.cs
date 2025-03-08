using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private Rigidbody2D  rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public GameManager gameManager;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        isFacingRight = true;
    }

    private void Update()
    {
        horizontalInput  = Input.GetAxis("Horizontal");

        switch (isFacingRight)
        {
            case false when horizontalInput > 0:
            case true when horizontalInput < 0:
                FlipSprite();
                break;
        }
        
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }

        if (animator.GetFloat("yVelocity") == 0)
        {
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * movementSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity",  Math.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity",  rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 normal = collision.GetContact(0).normal;
            if (normal.y > 0.5f)
            {
                isGrounded = true;
                animator.SetBool("isJumping", !isGrounded);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            gameManager.appleCount++;
        }
    }
}
