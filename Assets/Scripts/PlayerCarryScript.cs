using UnityEngine;

public class PlayerCarryScript : MonoBehaviour
{
    [SerializeField] private Transform holdPoint; // Drag your 'Hold Position' GameObject here in the Inspector
    [SerializeField] private float pickUpRange = 3f; // Range for raycast
    [SerializeField] private LayerMask pickableLayer; // Select the 'Pickable' Layer here in the Inspector
    [SerializeField] private Camera playerCamera;

    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press 'E' to interact
        {
            if (heldObject == null)
            {
                // Try to pick up object
                RaycastHit hit;
                Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 10);
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange, pickableLayer))
                {
                    PickUpObject(hit.collider.gameObject);
                }
            }
            else
            {
                // Drop object
                DropObject();
            }
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() != null)
        {
            heldObject = pickObj;
            heldObjectRb = pickObj.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false; // Disable gravity while held
            heldObjectRb.linearDamping = 10; // Increase drag for smoother movement

            // Parent the object to the hold point
            heldObject.transform.parent = holdPoint;
            heldObject.transform.position = holdPoint.transform.position;
        }
    }

    void DropObject()
    {
        heldObject.transform.parent = null; // Unparent the object
        heldObjectRb.useGravity = true; // Re-enable gravity
        heldObjectRb.linearDamping = 0; // Reset drag

        heldObject = null;
        heldObjectRb = null;
    }
}
