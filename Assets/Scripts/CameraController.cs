using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;        // Player
    public float smoothSpeed = 0.15f;
    public Vector3 offset;          // Camera offset

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPos = target.position + offset;

        // Smoothly move camera toward target
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

        transform.position = smoothedPos;
    }
}
