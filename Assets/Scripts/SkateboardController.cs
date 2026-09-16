using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    // Movement settings
    public float moveForce = 20f;
    public float maxSpeed = 12f;
    public float jumpForce = 12f;
    public float resetHopForce = 5f;
    public float tiltSpeed = 200f;

    // Visual objects
    public Transform boardVisual;   // rotates visually in air
    public Transform rider;         // follows boardVisual with offset

    Rigidbody2D rb;
    bool grounded;
    float groundAngle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectGround();
        HandleJump();
        HandleTilt();
        HandleReset();
        UpdateRider();
    }

    void FixedUpdate()
    {
        HandleMovement();
        ClampSpeed();
    }

    // -----------------------------
    // Ground Detection
    // -----------------------------
    void DetectGround()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 1.5f);

        grounded = hit.collider != null;

        if (grounded)
            groundAngle = Vector2.SignedAngle(Vector2.up, hit.normal);
    }

    // -----------------------------
    // Movement (WASD)
    // -----------------------------
    void HandleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector2 moveDir = grounded
            ? (Quaternion.Euler(0, 0, groundAngle) * Vector2.right)
            : Vector2.right;

        rb.AddForce(moveDir * input * moveForce);
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
    // Air Tilt (Left/Right Arrows)
    // -----------------------------
    void HandleTilt()
    {
        if (!grounded && boardVisual != null)
        {
            float tilt = 0f;

            if (Input.GetKey(KeyCode.LeftArrow)) tilt = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) tilt = 1f;

            boardVisual.Rotate(Vector3.forward * tilt * tiltSpeed * Time.deltaTime);
        }
    }

    // -----------------------------
    // Reset (Shift)
    // -----------------------------
    void HandleReset()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(Vector2.up * resetHopForce, ForceMode2D.Impulse);

            if (boardVisual != null)
                boardVisual.rotation = Quaternion.identity;
        }
    }

    // -----------------------------
    // Rider Follow (with Y+5 offset)
    // -----------------------------
    void UpdateRider()
    {
        if (rider != null && boardVisual != null)
        {
            Vector3 offset = new Vector3(0, 1.26f, 0);
            rider.position = boardVisual.position + offset;
            rider.rotation = boardVisual.rotation;
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
}
