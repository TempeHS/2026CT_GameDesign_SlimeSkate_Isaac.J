using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    Rigidbody2D rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Simple ground check
    void OnCollisionEnter2D(Collision2D col)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }
}
