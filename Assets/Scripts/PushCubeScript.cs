using System;
using UnityEngine;

public class PushCubeScript : MonoBehaviour
{
    public Vector3 pushDirection;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(pushDirection != Vector3.zero)
        {
            
        }
    }
}
