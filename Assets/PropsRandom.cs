using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRandom : MonoBehaviour
{
    public List<GameObject> propspawnpoints;
    public List<GameObject> propsPrefabs;
    
    void Start()
    {
        spawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnProps()
    {
        foreach (GameObject sp in propspawnpoints)
        {
            int rand = Random.Range(0, propsPrefabs.Count);
            GameObject prop = Instantiate(propsPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}