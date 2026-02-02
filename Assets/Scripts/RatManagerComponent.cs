using UnityEngine;

public class RatManagerComponent : MonoBehaviour
{
    [SerializeField] GameObject RatPrefab;
    [SerializeField] Vector3 goalPosition;
    Vector3 finalPosition;


    void SpawnRat()
    {
        GameObject newRat =  Instantiate(RatPrefab);
        Rigidbody rb = newRat.GetComponent<Rigidbody>();

        newRat.transform.position = transform.position;

        newRat.GetComponent<RatScript>().endPosition = goalPosition;

        newRat.transform.parent = transform;
        
    }

    private void FixedUpdate()
    {
        SpawnRat();
    }

}
