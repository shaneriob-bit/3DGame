using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public bool spawn = true;
    public Vector2 squareSize = new Vector2(4.0f, 4.0f);
    public int debrisListSize = 1000;
    public int maxClusterSize = 16;
    public float maxScaleMultiplier = 3.0f;
    public float minScaleMultiplier = 1.0f;
    public float clusterFrequency = 1f;
    public float maxDebrisDistance = 100.0f;

    private List<GameObject> debrisList = new List<GameObject>();
    private float timeSinceCluster = 0.0f;

    int usedCount = 0;

    public void CreateDebris(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject clone = Instantiate(debrisPrefab);
            Vector2 randRectanglePosition = GetRandomPointOnRectangle(squareSize.x, squareSize.y);
            clone.transform.parent = transform;
            clone.transform.localPosition = new Vector3(randRectanglePosition.x, transform.position.y, randRectanglePosition.y);
            debrisList.Add(clone);
            clone.SetActive(false);
        }
    }

    public int GetActiveDebris()
    {
        int activeCount = 0;
        foreach(GameObject debris in debrisList)
        { 
            if(debris.activeSelf)
            {
                activeCount++;
            }
        }
        return activeCount;
    }
    public void ResetDebris(int index)
    {
        Vector2 randRectanglePosition = GetRandomPointOnRectangle(squareSize.x, squareSize.y);
        debrisList[index].transform.localPosition = new Vector3(randRectanglePosition.x, transform.position.y, randRectanglePosition.y);
        debrisList[index].transform.localScale = debrisPrefab.transform.localScale * Random.Range(minScaleMultiplier, maxScaleMultiplier);
        debrisList[index].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        debrisList[index].SetActive(true);
    }

    public void RainDebris(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ResetDebris(usedCount);
            usedCount++;

            if (usedCount >= debrisList.Count)
                usedCount = 0;
        }
    }

    private Vector2 GetRandomPointOnRectangle(float sizeX, float sizeY)
    {
        return new Vector2(Random.Range(-sizeX / 2, sizeX / 2), Random.Range(-sizeY / 2, sizeY / 2));
    }


    private void Awake()
    {
        CreateDebris(debrisListSize);
    }

    private void FixedUpdate()
    {
        timeSinceCluster += Time.deltaTime;


        if(spawn)
        {
            for(int i = 0; i < debrisList.Count; i++)
            {
                if(Vector3.Distance(debrisList[i].transform.position, transform.position) > maxDebrisDistance)
                {
                    debrisList[i].SetActive(false);
                }
            }


            if(timeSinceCluster >= clusterFrequency)
            {
                RainDebris(Random.Range(1, maxClusterSize)); //CreateDebris(Random.Range(1, 30));
                timeSinceCluster = 0;
            }
        }
    }
}
