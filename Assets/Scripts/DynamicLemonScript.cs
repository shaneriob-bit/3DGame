using UnityEngine;

public class DynamicLemonScript : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    Vector3 finalPosition;

    bool toEnd = true; 

    public float moveSpeed = 10.0f;

    private void Start()
    {
        startPosition = transform.position;
        finalPosition = startPosition + endPosition;
    }

    private void FixedUpdate()
    {
        if (toEnd)
        {
            transform.position =  Vector3.Lerp(transform.position, finalPosition, moveSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, moveSpeed);
        }

        if (toEnd)
        {
            if (Vector3.Distance(transform.position, finalPosition) < 1)
            {
                toEnd = !toEnd;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, startPosition) < 1)
            {
                toEnd = !toEnd;
            }
        }
    }
}
