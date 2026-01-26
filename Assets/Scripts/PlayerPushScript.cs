using UnityEngine;

/*
 * Useful information on Raycasting: https://gamedevbeginner.com/raycasts-in-unity-made-easy/
 * Use RaycastHit.normal to find the face of the cube that the raycast hits.
 */

public class PlayerPushScript : MonoBehaviour
{
    public GameObject pushCastOrigin;

    Ray ray;
    RaycastHit hitData;

    float rayDistance = 4.0f;

    void FixedUpdate()
    {
        ray = new Ray(pushCastOrigin.transform.position, pushCastOrigin.transform.forward);

        if(Physics.Raycast(ray, out hitData, rayDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance);
            //Debug.Log("Hit: " + hitData.normal);
        }
    }
}
