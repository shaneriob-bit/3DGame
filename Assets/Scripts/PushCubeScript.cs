using System;
using UnityEngine;

public class PushCubeScript : MonoBehaviour
{
    private Vector3 pushDirection;
    
    private Rigidbody rb;

    const float directionResetTime = 0.1f;

    float pushForce = 2.0f;

    float timeSinceTouch = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Touch(float force, Vector3 dir)
    {
        Debug.Log("The cube has been pushed.");

        timeSinceTouch = 0.0f;
        pushForce = force;
        pushDirection = dir;
    }

    void FixedUpdate()
    {
        if(timeSinceTouch > directionResetTime)
        {
            pushDirection = Vector3.zero;
        }

        rb.linearVelocity = (pushDirection) * pushForce;

        timeSinceTouch += Time.deltaTime;
    }
}
