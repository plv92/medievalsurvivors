using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject batPrefab;
    public int numberOfBats = 5;

    void Start()
    {
        for (int i = 0; i < numberOfBats; i++)
        {
            float x = Random.Range(-40.0f, 40.0f);
            float y = Random.Range(-40.0f, 40.0f);
            Vector3 randomPosition = new Vector3(x, y, 0);

            Instantiate(batPrefab, randomPosition, Quaternion.identity);
        }
    }
}
