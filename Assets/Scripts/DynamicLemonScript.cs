using UnityEngine;

public class SideToSidePlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2.0f;
    public float distance = 3.0f;

    [Header("Direction Controls")]
    public bool moveVertical = false;
    public bool useZAxis = false;

    private Vector3 startPosition;
    private Vector3 previousPosition;
    private CharacterController playerController;

    void Start()
    {
        startPosition = transform.position;
        previousPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    // LateUpdate runs after all Update functions, ensuring the platform 
    // has finished moving before we move the player.
    void LateUpdate()
    {
        if (playerController != null)
        {
            // 1. Calculate how much the platform moved this frame
            Vector3 platformDelta = transform.position - previousPosition;

            // 2. Manually nudge the player by that same amount
            playerController.Move(platformDelta);
        }

        // Record position for the next frame's calculation
        previousPosition = transform.position;
    }

    void MovePlatform()
    {
        float movementOffset = Mathf.Sin(Time.time * speed) * distance;
        Vector3 newPosition = startPosition;

        if (moveVertical) newPosition.y += movementOffset;
        else if (useZAxis) newPosition.z += movementOffset;
        else newPosition.x += movementOffset;

        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Grab the CharacterController reference
            playerController = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = null;
        }
    }
}