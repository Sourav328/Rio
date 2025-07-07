using UnityEngine;

public class Parallax_Effect : MonoBehaviour
{
    private float length;         // Width of the background sprite
    private float startPosX;      // Initial x-position of the background
    public float parallaxFactor;  // Lower = slower parallax (0.2 to 0.8)

    public Camera cam;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float camX = cam.transform.position.x;

        // Calculate how far the camera has moved
        float distance = camX * parallaxFactor;

        // Set new parallaxed x-position
        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);

        // Repeat the background when it's out of view
        float temp = camX * (1 - parallaxFactor);
        if (temp > startPosX + length)
        {
            startPosX += length;
        }
        else if (temp < startPosX - length)
        {
            startPosX -= length;
        }
    }
}
