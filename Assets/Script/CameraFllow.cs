using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    public Transform target;         // Your player
    public Vector3 offset;           // Offset from player
    public float smoothSpeed = 5f;   // Smoothing movement

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z); // Keep Z fixed
        }
    }
}
