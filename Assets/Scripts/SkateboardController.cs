using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 12f;

    public float jumpForce = 12f;

    bool grounded;
    bool isJumpingAnimationPlaying;

    public float tiltSpeed = 200f;
    public float resetHopForce = 5f;

    public Animator anim;

    Rigidbody2D rb;
    float input;

    // Ground check settings
    public Vector2 groundCheckSize = new Vector2(1.0f, 0.25f);
    public float groundCheckOffsetY = -0.9f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // FIX #3 — Ensure Animator reference is valid
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
            Debug.Log("Animator auto-assigned from child.");
        }
    }

    void Update()
    {
        UpdateGrounded();
        HandleJump();
        HandleTilt();
        HandleReset();
        UpdateAnimationState();
    }

    void FixedUpdate()
    {
        HandleMovement();
        ClampSpeed();
    }

    // -----------------------------
    // PERFECT GROUND CHECK
    // -----------------------------
    void UpdateGrounded()
    {
        Vector2 checkPos = (Vector2)transform.position + new Vector2(0, groundCheckOffsetY);
        grounded = Physics2D.OverlapBox(checkPos, groundCheckSize, 0f, LayerMask.GetMask("Default"));
    }

    // -----------------------------
    // Movement (A/D)
    // -----------------------------
    void HandleMovement()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * input * moveForce);
    }

    // -----------------------------
    // Jump (Space)
    // -----------------------------
    void HandleJump()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // -----------------------------
    // Air Tilt (Arrow Keys)
    // -----------------------------
    void HandleTilt()
    {
        if (!grounded)
        {
            float tilt = 0f;

            if (Input.GetKey(KeyCode.LeftArrow)) tilt = 1f;
            if (Input.GetKey(KeyCode.RightArrow)) tilt = -1f;

            if (tilt != 0f)
            {
                transform.Rotate(Vector3.forward * tilt * tiltSpeed * Time.deltaTime);
            }
        }
    }

    // -----------------------------
    // Reset (Shift)
    // -----------------------------
    void HandleReset()
    {
        if (grounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(Vector2.up * resetHopForce, ForceMode2D.Impulse);
            transform.rotation = Quaternion.identity;
        }
    }

    // -----------------------------
    // Animator State Machine (FIX #3)
    // -----------------------------
    void UpdateAnimationState()
    {
        bool walking = Mathf.Abs(input) > 0.1f;
        anim.SetFloat("walking", walking ? 1f : 0f);

        // FIX #3 — Fire jump trigger ONCE when leaving ground
        if (!grounded)
        {
            if (!isJumpingAnimationPlaying)
            {
                Debug.Log("JUMP TRIGGER FIRED");   // <--- CONFIRMATION
                anim.SetTrigger("jumpOnce");       // <--- MUST match Animator
                isJumpingAnimationPlaying = true;
            }
        }
        else
        {
            // Reset animation state when grounded
            isJumpingAnimationPlaying = false;
        }
    }

    // -----------------------------
    // Speed Clamp
    // -----------------------------
    void ClampSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }

    // -----------------------------
    // Draw ground check in Scene view
    // -----------------------------
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 checkPos = (Vector2)transform.position + new Vector2(0, groundCheckOffsetY);
        Gizmos.DrawWireCube(checkPos, groundCheckSize);
    }
}
