using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    public GameObject Spider;
    public Transform[] spawningPoints;

    public void StartInstantiate()
    {
        Instantiate(Spider, spawningPoints[Random.Range(0, spawningPoints.Length)]);
    }
}
