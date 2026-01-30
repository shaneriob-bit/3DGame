using UnityEngine;

public class LemonCleanupGameScript : MonoBehaviour
{
    [SerializeField] private GameObject debrisManagerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DebrisManager debrisManagerComponent = debrisManagerObject.GetComponent<DebrisManager>();
        debrisManagerComponent.RainDebris(debrisManagerComponent.debrisListSize - 1);


    }

    
}
