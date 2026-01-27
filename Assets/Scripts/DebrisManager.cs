using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public float squareSize = 8.0f;
    public int debrisListSize = 1000;
    private List<GameObject> debrisList = new List<GameObject>();

    int usedCount = 0;

    public void CreateDebris(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject clone = Instantiate(debrisPrefab);
            clone.transform.parent = transform;
            clone.transform.position = new Vector3(Random.Range(-squareSize, squareSize), transform.position.y, Random.Range(-squareSize, squareSize));
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
        debrisList[index].transform.position = new Vector3(Random.Range(-squareSize, squareSize), transform.position.y, Random.Range(-squareSize, squareSize));
        debrisList[index].SetActive(true);
    }

    /*
    public void RainDebris(int count)
    {
        for(int i = 0; i < count; i++)
        {
            if(usedCount <= debrisList.Count)
            {
                Debug.Log(usedCount);
                ResetDebris(usedCount);
                usedCount++;
            }
            if(usedCount >= debrisList.Count)
            {
                usedCount = 0;
            }
        }
    }
    */

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


    private void Start()
    {
        CreateDebris(debrisListSize);
    }

    private void FixedUpdate()
    {

        if(Random.Range(0, 20) == 17)
        {
            RainDebris(Random.Range(1, 30)); //CreateDebris(Random.Range(1, 30));
        }
    }
}
