using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public float jumpForce;

    public Transform groundCheak;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheak.position, groundCheckRadius, groundLayer);

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        anim.SetBool("OnGround", isGrounded);
    }
}
