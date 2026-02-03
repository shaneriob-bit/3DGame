using UnityEngine;

public class DynamicLemonScript : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast the platform moves back and forth.")]
    public float speed = 2.0f;

    [Tooltip("How far the platform moves from its starting point.")]
    public float distance = 3.0f;

    [Header("Direction Controls")]
    [Tooltip("Check this to move Up/Down (Y Axis). This overrides the settings below.")]
    public bool moveVertical = false;

    [Tooltip("If Vertical is unchecked: Check this to move Forward/Back (Z Axis). Uncheck for Left/Right (X Axis).")]
    public bool useZAxis = false;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movementOffset = Mathf.Sin(Time.time * speed) * distance;
        Vector3 newPosition = startPosition;

        // Logic to determine which axis to apply the movement to
        if (moveVertical)
        {
            // Move Up/Down (Y)
            newPosition.y += movementOffset;
        }
        else if (useZAxis)
        {
            // Move Forward/Back (Z)
            newPosition.z += movementOffset;
        }
        else
        {
            // Move Left/Right (X) - Default
            newPosition.x += movementOffset;
        }

        transform.position = newPosition;
    }

    // --- Player stickiness logic included for convenience ---
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Exited Collider");
            collision.transform.SetParent(null);
        }
    }
}