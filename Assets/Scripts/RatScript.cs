using UnityEngine;
using System.Collections;

public class RatScript : MonoBehaviour
{
    // The total distance to move
    public float distanceToMove = 5f;
    // The time it takes to complete the movement
    public float duration = 2f;

    private Vector3 startPosition;
    public Vector3 endPosition;
    private float startTime;

    void Start()
    {
        // Set the start time when the movement begins
        startTime = Time.time;
        // The movement starts at the object's current position
        startPosition = transform.position;
        // The end position is current position + forward direction * distance
        endPosition = startPosition + transform.forward * distanceToMove;
    }

    void Update()
    {
        // Calculate the time elapsed since the movement started
        float timeElapsed = Time.time - startTime;
        // Calculate the interpolation value (0 to 1) using inverse lerp
        float t = Mathf.Clamp01(timeElapsed / duration);

        // Use Vector3.Lerp to smoothly move the object
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
    }
}
