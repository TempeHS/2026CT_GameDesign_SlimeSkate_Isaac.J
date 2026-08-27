using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Use the Z you want here
    public Vector3 offset = new Vector3(0f, 0f, -27.6f);

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
