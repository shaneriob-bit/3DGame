using UnityEngine;

public class PlayerPushScript : MonoBehaviour
{
    public GameObject pushCastOrigin;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = pushCastOrigin.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(pushCastOrigin.transform.position, fwd, out hit, 0.1f))
        {
            Debug.DrawLine(pushCastOrigin.transform.position, hit.point);
            print("Something is in front of the object!");
        }
    }
}
