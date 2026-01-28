using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class DebrisManager : MonoBehaviour
{
    public GameObject debrisPrefab;
    public bool spawn = true;
    public float squareSize = 8.0f;
    public int debrisListSize = 1000;
    public int maxClusterSize = 16;
    public float maxScaleMultiplier = 3.0f;
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
        debrisList[index].transform.position = transform.position + (new Vector3(Random.Range(-squareSize, squareSize), transform.position.y, Random.Range(-squareSize, squareSize)));
        debrisList[index].transform.localScale = debrisPrefab.transform.localScale * Random.Range(1.0f, maxScaleMultiplier);
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


    private void Start()
    {
        CreateDebris(debrisListSize);
    }

    private void FixedUpdate()
    {
        if(enabled)
        {
            for(int i = 0; i < debrisList.Count; i++)
            {
                if(Vector3.Distance(debrisList[i].transform.position, Vector3.zero) > 9999.0f)
                {
                    debrisList[i].SetActive(false);
                }
            }


            if(Random.Range(0, 20) == 17)
            {
                RainDebris(Random.Range(1, maxClusterSize)); //CreateDebris(Random.Range(1, 30));
            }
        }
    }
}
