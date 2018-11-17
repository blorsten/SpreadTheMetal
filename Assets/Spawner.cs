using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toSpawn;
    public float spawnInterval = 1;
    public bool spawnOnStart = false;

    private float spawnTimer;

    // Use this for initialization
    void Start()
    {
        if (spawnOnStart)
            spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(toSpawn);
            spawnTimer = spawnInterval;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
