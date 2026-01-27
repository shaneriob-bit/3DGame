using UnityEngine;

/*
 * Useful information on Raycasting: https://gamedevbeginner.com/raycasts-in-unity-made-easy/
 */

public class PlayerPushScript : MonoBehaviour
{
    public GameObject pushCastOrigin;

    float rayDistance = 0.8f;
    public float pushForce = 3.0f;

    void FixedUpdate()
    {
        Ray ray = new Ray(pushCastOrigin.transform.position, pushCastOrigin.transform.forward);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, rayDistance))
        {
            GameObject hitObject = hitData.transform.gameObject;
            Rigidbody hitRigidbody = hitObject.GetComponent<Rigidbody>();

            if (hitRigidbody != null)
            {
                hitRigidbody.linearVelocity = (hitData.normal * -1) * pushForce; 
            }

            Debug.DrawRay(ray.origin, ray.direction * rayDistance);
            Debug.Log("Hit: " + hitData.normal);
        }
    }
}
