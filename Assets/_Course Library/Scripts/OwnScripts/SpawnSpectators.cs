using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpectators : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnSpectatorsObj;
    [SerializeField] private float minSpawnDelay = 1f; // Minimum delay in seconds
    [SerializeField] private float maxSpawnDelay = 3f; // Maximum delay in seconds

    private float nextSpawnTime; // Time for the next spawn

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the next spawn time
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to spawn
        if (Time.time >= nextSpawnTime)
        {
            //Pick A random obj
            int randomSpawnObj = Random.Range(0, SpawnSpectatorsObj.Count);

            // Spawn the object
            Instantiate(SpawnSpectatorsObj[randomSpawnObj], transform.position, Quaternion.identity);

            // Calculate the next spawn time
            SetNextSpawnTime();
        }
    }

    private void SetNextSpawnTime()
    {
        // Calculate a random spawn delay between minSpawnDelay and maxSpawnDelay
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

        // Set the next spawn time based on the current time and the spawn delay
        nextSpawnTime = Time.time + spawnDelay;
    }
}

