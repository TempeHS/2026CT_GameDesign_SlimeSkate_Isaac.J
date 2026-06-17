using UnityEngine;

public class SkateboardMovement : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 12f;
    public float groundStickForce = 20f;
    public float drag = 2f;
    public LayerMask groundMask;

    Rigidbody2D rb;
    float groundAngle;
    bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

void FixedUpdate()
{
    MoveAlongSlope_Fallback();

    ApplyDrag();
    ClampSpeed();
}


void UpdateGround()
{
    Vector2 origin = (Vector2)transform.position + Vector2.down * 0.2f;
    float rayLength = 1.5f;

    RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLength, groundMask);

    grounded = hit.collider != null;

    if (grounded)
        groundAngle = Vector2.SignedAngle(Vector2.up, hit.normal);
}

void MoveAlongSlope_Fallback()
{
    float input = Input.GetAxisRaw("Horizontal");

    Vector2 moveDir;

    if (!grounded)
    {
        moveDir = Vector2.right;
    }
    else
    {
        Vector2 slopeDirection = Quaternion.Euler(0, 0, groundAngle) * Vector2.right;
        moveDir = slopeDirection;
    }

    rb.AddForce(moveDir * input * moveForce);
}


    void MoveAlongSlope()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector2 slopeDirection = Quaternion.Euler(0, 0, groundAngle) * Vector2.right;

        rb.AddForce(slopeDirection * input * moveForce);
    }

    void StickToGround()
    {
        rb.AddForce(Vector2.down * groundStickForce);
    }

    void ApplyDrag()
    {
        rb.linearVelocity *= 1f - (drag * Time.fixedDeltaTime);
    }

    void ClampSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }
}
